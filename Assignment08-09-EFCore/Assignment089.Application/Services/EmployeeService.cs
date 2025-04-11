using Assignment089.Application.Models.Mapping;
using Assignment089.Application.Models.Requests;
using Assignment089.Application.Models.Responses;
using Assignment089.Application.Services.Interfaces;
using Assignment089.Application.Shared;
using Assignment089.Domain.Entities;
using Assignment089.Domain.Primitives;
using Assignment089.Domain.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net;

namespace Assignment089.Application.Services;

public class EmployeeService : IEmployeeService
{
	private readonly IEmployeeRepository _employeeRepository;
	private readonly IRepository<Department> _departmentRepository;
	private readonly IRepository<ProjectEmployee> _projectEmployeeRepository;
	private readonly IValidator<EmployeeRequest> _employeeRequestValidator;
	public EmployeeService(IEmployeeRepository employeeRepository, IValidator<EmployeeRequest> employeeRequestValidator, IRepository<Department> departmentRepository, IRepository<ProjectEmployee> projectEmployeeRepository)
	{
		_employeeRepository = employeeRepository;
		_employeeRequestValidator = employeeRequestValidator;
		_departmentRepository = departmentRepository;
		_projectEmployeeRepository = projectEmployeeRepository;
	}

	public async Task<Result<List<EmployeeResponse>>> GetAll()
	{
		var res = await _employeeRepository.SelectAsync(x => x.ToResponse());
		return Result<List<EmployeeResponse>>.SuccessWithBody(res.ToList());
	}

	public async Task<Result<List<EmployeeDepartmentResponse>>> GetAllEmployeeWithDepartment()
	{
		var res = await _employeeRepository.JoinAsync<Department, Guid, EmployeeDepartmentResponse>(
											e=>e.DepartmentId, d=>d.Id, 
											(e, d)=> new EmployeeDepartmentResponse()
											{
												Id = e.Id,
												Name = e.Name,
												JoinedDate = e.JoinedDate,
												DepartmentName = d.Name
											});
		return Result<List<EmployeeDepartmentResponse>>.SuccessWithBody(res.ToList());
	}

	public async Task<Result<List<EmployeeProjectsResponse>>> GetAllEmployeeWithProjects()
	{
		var res = await _employeeRepository.GetAllEmployeesWithProjects(g => new EmployeeProjectsResponse()
		{
			Id = g.Key.Id,
			Name = g.Key.Name,
			JoinedDate = g.Key.JoinedDate,
			Projects = g.Where(x=>x.Project!=null).Select(x=> new ProjectEmployeeDetailsResponse()
			{
				ProjectName = x.Project!.Name,
				Enable = x.ProjectEmployee!.Enable
			}).ToList()

		});
		return Result<List<EmployeeProjectsResponse>>.SuccessWithBody(res.ToList());
	}

	public async Task<Result<List<EmployeeFilterResponse>>> FilterEmployee(EmployeeFilterRequest filterRequest)
	{
		var res = await _employeeRepository.SelectAsync(selectQuery: x => x.ToFilterResponse(),
												  predicate: x => (filterRequest.MinSalary.HasValue ? x.Salary.Amount > filterRequest.MinSalary.Value : true)
												  && (filterRequest.MinJoinedDate.HasValue ? x.JoinedDate >= DateOnly.FromDateTime(filterRequest.MinJoinedDate.Value) : true),
												  navigationProperties: x=>x.Salary);

		return Result<List<EmployeeFilterResponse>>.SuccessWithBody(res.ToList());
	}



	public async Task<Result> GetById(Guid id)
	{
		var selectedEntity = await _employeeRepository.FirstOrDefaultAsync(x => x.Id == id);
		if (selectedEntity == null)
		{
			return Result.Error(HttpStatusCode.NotFound, MessageAlert.ObjectNotFound(id, "Employee"));
		}
		return Result<EmployeeResponse>.SuccessWithBody(selectedEntity.ToResponse());
	}

	public async Task<Result> Add(EmployeeRequest newEmployee)
	{
		var validateResult = _employeeRequestValidator.Validate(newEmployee);
		if (!validateResult.IsValid)
		{
			return Result.ErrorValidation(HttpStatusCode.BadRequest, validateResult.Errors.Select(x => x.ErrorMessage));
		}
		if(!await _departmentRepository.AnyAsync(x => x.Id == newEmployee.DepartmentId))
		{
			return Result.Error(HttpStatusCode.NotFound, MessageAlert.ObjectNotFound(newEmployee.DepartmentId, "Department"));
		}
		_employeeRepository.Add(newEmployee.ToEntity());
		await _employeeRepository.SaveChangesAsync();
		return Result.SuccessWithMessage(MessageAlert.CreatedSuccessfully("Employee"));
	}

	public async Task<Result> Update(Guid id, EmployeeRequest updatedEmployee)
	{
		var validateResult = _employeeRequestValidator.Validate(updatedEmployee);
		if (!validateResult.IsValid)
		{
			return Result.ErrorValidation(HttpStatusCode.BadRequest, validateResult.Errors.Select(x => x.ErrorMessage));
		}
		var isExisted = await _employeeRepository.AnyAsync(x=>x.Id == id);
		if (!isExisted)
		{
			return Result.Error(HttpStatusCode.NotFound, MessageAlert.ObjectNotFound(id, "Employee"));
		}
		if (!await _departmentRepository.AnyAsync(x => x.Id == updatedEmployee.DepartmentId))
		{
			return Result.Error(HttpStatusCode.NotFound, MessageAlert.ObjectNotFound(updatedEmployee.DepartmentId, "Department"));
		}
		var updatedEntity = updatedEmployee.ToEntity();
		updatedEntity.Id = id;
		updatedEntity.UpdatedAt = DateTime.Now;
		_employeeRepository.Update(updatedEntity);
		await _employeeRepository.SaveChangesAsync();
		return Result.Success(MessageAlert.UpdatedSuccessfully(id, "Employee"), HttpStatusCode.Created);
	}

	public async Task<Result> Delete(Guid id)
	{
		var selectedEntity = await _employeeRepository.FirstOrDefaultAsync(x => x.Id == id);
		if (selectedEntity == null)
		{
			return Result.Error(HttpStatusCode.NotFound, MessageAlert.ObjectNotFound(id, "Employee"));
		}
		_employeeRepository.Delete(selectedEntity);
		await _employeeRepository.SaveChangesAsync();
		return Result.Success(MessageAlert.DeletedSuccessfully(id, "Employee"), HttpStatusCode.NoContent);
	}

	public async Task<Result<List<EmployeeDepartmentResponse>>> GetAllEmployeeWithDepartmentRawQuery()
	{
		var resRaw = await _employeeRepository.GetAllEmployeeWithDepartmentRawQuery();
		var res = resRaw.Select(x => new EmployeeDepartmentResponse()
		{
			Id = x.Id,
			Name = x.Name,
			JoinedDate = x.JoinedDate,
			DepartmentName = x.DepartmentName
		});
		return Result<List<EmployeeDepartmentResponse>>.SuccessWithBody(res.ToList());
	}

	public async Task<Result<List<EmployeeProjectsResponse>>> GetAllEmployeeWithProjectsRawQuery()
	{
		var resRaw = await _employeeRepository.GetAllEmployeesWithProjectsRawQuery();

		var res = new List<EmployeeProjectsResponse>();
		foreach (var employee in resRaw)
		{
			if (!res.Any(x => x.Id == employee.Id))
			{
				res.Add(new EmployeeProjectsResponse()
				{
					Id = employee.Id,
					JoinedDate = employee.JoinedDate,
					Name = employee.Name,
					Projects = new List<ProjectEmployeeDetailsResponse>()
				});
			}
			else
			{
				var index = res.FindIndex(x => x.Id == employee.Id);
				if (employee.ProjectName != null && employee.Enable != null)
				{
					res[index].Projects.Add(new ProjectEmployeeDetailsResponse()
					{
						ProjectName = employee.ProjectName,
						Enable = employee.Enable??false
					});
				}
			}

		}
		return Result<List<EmployeeProjectsResponse>>.SuccessWithBody(res);
	}


	public async  Task<Result<List<EmployeeFilterResponse>>> FilterEmployeeRawQuery(EmployeeFilterRequest filterRequest)
	{
		var resRaw = await _employeeRepository.FilterEmployeeRawQuery(filterRequest.MinSalary, filterRequest.MinJoinedDate);
		var res = resRaw.Select(x => new EmployeeFilterResponse()
		{
			Id = x.Id,
			Name = x.Name,
			JoinedDate = x.JoinedDate??new DateOnly()
		});
		return Result<List<EmployeeFilterResponse>>.SuccessWithBody(res.ToList());
	}

	public async Task<Result> UpdateProjectList(Guid id, ListProjectRequest projects)
	{
		if (projects == null || projects.Projects == null || projects.Projects.Count == 0)
		{
			return Result.Error(HttpStatusCode.BadRequest, "projects must not be empty!");
		}
		var selectedEntity = await _employeeRepository.FirstOrDefaultAsync(x => x.Id == id);
		if (selectedEntity == null)
		{
			return Result.Error(HttpStatusCode.NotFound, MessageAlert.ObjectNotFound(id, "Employee"));
		}

		try
		{
			await _employeeRepository.BeginTransactionAsync();
			await _projectEmployeeRepository.ExecuteDeleteAsync(x => x.EmployeeId == id);
			var newEmployeeProjects = new List<ProjectEmployee>();
			foreach (var details in projects.Projects)
			{
				newEmployeeProjects.Add(new ProjectEmployee()
				{
					EmployeeId = id,
					ProjectId = details.ProjectId,
					Enable = details.Enable
				});

			}
			await _projectEmployeeRepository.AddRangeAsync(newEmployeeProjects);
			await _employeeRepository.SaveChangesAsync();

			await _employeeRepository.CommitAsync();
		}
		catch (Exception)
		{
			await _employeeRepository.RollbackAsync();
			return Result.Error(HttpStatusCode.InternalServerError, MessageAlert.ServerError());
		}


		return Result.Success(MessageAlert.UpdatedSuccessfully(id, "Employee"), HttpStatusCode.Created);
	}

}
