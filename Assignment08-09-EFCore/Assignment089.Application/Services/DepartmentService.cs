using Assignment089.Application.Models.Mapping;
using Assignment089.Application.Models.Requests;
using Assignment089.Application.Models.Responses;
using Assignment089.Application.Services.Interfaces;
using Assignment089.Application.Shared;
using Assignment089.Domain.Entities;
using Assignment089.Domain.Primitives;
using FluentValidation;
using System.Net;

namespace Assignment089.Application.Services;

public class DepartmentService : IDepartmentService
{
	private readonly IRepository<Department> _departmentRepository;
	private readonly IRepository<Employee> _employeeRepository;
	private readonly IRepository<Salary> _salaryRepository;
	private readonly IValidator<DepartmentRequest> _departmentRequestValidator;
	public DepartmentService(IRepository<Department> departmentRepository, IValidator<DepartmentRequest> departmentRequestValidator, IRepository<Employee> employeeRepository, IRepository<Salary> salaryRepository)
	{
		_departmentRepository = departmentRepository;
		_departmentRequestValidator = departmentRequestValidator;
		_employeeRepository = employeeRepository;
		_salaryRepository = salaryRepository;
	}

	public async Task<Result<List<DepartmentResponse>>> GetAll()
	{
		var res = await _departmentRepository.SelectAsync(x=>x.ToResponse());
		return Result<List<DepartmentResponse>>.SuccessWithBody(res.ToList());
	}

	public async Task<Result> GetById(Guid id)
	{
		var selectedEntity = await _departmentRepository.FirstOrDefaultAsync(x => x.Id == id);
		if (selectedEntity == null)
		{
			return Result.Error(HttpStatusCode.NotFound, MessageAlert.ObjectNotFound(id, "Department"));
		}
		return Result<DepartmentResponse>.SuccessWithBody(selectedEntity.ToResponse());
	}

	public async Task<Result> Add(DepartmentRequest newDepartment)
	{
		var validateResult = _departmentRequestValidator.Validate(newDepartment);
		if (!validateResult.IsValid)
		{
			return Result.ErrorValidation(HttpStatusCode.BadRequest, validateResult.Errors.Select(x => x.ErrorMessage));
		}
		_departmentRepository.Add(newDepartment.ToEntity());
		await _departmentRepository.SaveChangesAsync();
		return Result.SuccessWithMessage(MessageAlert.CreatedSuccessfully("Department"));
	}

	public async Task<Result> Update(Guid id, DepartmentRequest updatedDepartment)
	{
		var validateResult = _departmentRequestValidator.Validate(updatedDepartment);
		if (!validateResult.IsValid)
		{
			return Result.ErrorValidation(HttpStatusCode.BadRequest, validateResult.Errors.Select(x => x.ErrorMessage));
		}
		var isExisted = await _departmentRepository.AnyAsync(x=>x.Id == id);
		if (!isExisted)
		{
			return Result.Error(HttpStatusCode.NotFound, MessageAlert.ObjectNotFound(id, "Department"));
		}
		var updatedEntity = updatedDepartment.ToEntity();
		updatedEntity.Id = id;
		updatedEntity.UpdatedAt = DateTime.Now;
		_departmentRepository.Update(updatedEntity);
		await _departmentRepository.SaveChangesAsync();
		return Result.Success(MessageAlert.UpdatedSuccessfully(id, "Department"), HttpStatusCode.Created);
	}

	public async Task<Result> Delete(Guid id)
	{
		var selectedEntity = await _departmentRepository.FirstOrDefaultAsync(x => x.Id == id);
		if (selectedEntity == null)
		{
			return Result.Error(HttpStatusCode.NotFound, MessageAlert.ObjectNotFound(id, "Department"));
		}
		_departmentRepository.Delete(selectedEntity);
		await _departmentRepository.SaveChangesAsync();

		return Result.Success(MessageAlert.DeletedSuccessfully(id, "Department"), HttpStatusCode.NoContent);
	}


}
