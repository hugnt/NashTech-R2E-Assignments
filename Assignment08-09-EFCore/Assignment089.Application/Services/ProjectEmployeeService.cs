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

public class ProjectEmployeeService : IProjectEmployeeService
{
	private readonly IRepository<ProjectEmployee> _projectEmployeeRepository;
	private readonly IRepository<Project> _projectRepository;
	private readonly IRepository<Employee> _employeeRepository;
	public ProjectEmployeeService(IRepository<ProjectEmployee> projectEmployeeRepository, IRepository<Project> projectRepository, IRepository<Employee> employeeRepository)
	{
		_projectEmployeeRepository = projectEmployeeRepository;
		_projectRepository = projectRepository;
		_employeeRepository = employeeRepository;
	}

	public async Task<Result<List<ProjectEmployeeResponse>>> GetAll()
	{
		var res = await _projectEmployeeRepository.SelectAsync(x=>x.ToResponse());
		return Result<List<ProjectEmployeeResponse>>.SuccessWithBody(res.ToList());
	}

	public async Task<Result> GetById(Guid projectId,Guid employeeId)
	{
		var selectedEntity = await _projectEmployeeRepository.FirstOrDefaultAsync(x => x.ProjectId == projectId && x.EmployeeId == employeeId);
		if (selectedEntity == null)
		{
			return Result.Error(HttpStatusCode.NotFound, MessageAlert.ObjectNotFound(projectId, employeeId, "Project", "Employee"));
		}
		return Result<ProjectEmployeeResponse>.SuccessWithBody(selectedEntity.ToResponse());
	}

	public async Task<Result> Add(ProjectEmployeeRequest newProjectEmployee)
	{
		if (!await _projectRepository.AnyAsync(x => x.Id == newProjectEmployee.ProjectId))
		{
			return Result.Error(HttpStatusCode.NotFound, MessageAlert.ObjectNotFound(newProjectEmployee.ProjectId, "Project"));
		}
		if (!await _employeeRepository.AnyAsync(x => x.Id == newProjectEmployee.EmployeeId))
		{
			return Result.Error(HttpStatusCode.NotFound, MessageAlert.ObjectNotFound(newProjectEmployee.EmployeeId, "Employee"));
		}
		if (await _projectEmployeeRepository.AnyAsync(x=>x.ProjectId == newProjectEmployee.ProjectId && x.EmployeeId == newProjectEmployee.EmployeeId))
		{
			return Result.Error(HttpStatusCode.BadGateway, MessageAlert.ObjectExisted(newProjectEmployee.ProjectId, newProjectEmployee.EmployeeId, "Project", "Employee"));
		}
		_projectEmployeeRepository.Add(newProjectEmployee.ToEntity());
		await _projectEmployeeRepository.SaveChangesAsync();
		return Result.SuccessWithMessage(MessageAlert.CreatedSuccessfully("ProjectEmployee"));
	}

	public async Task<Result> Update(Guid projectId, Guid employeeId, ProjectEmployeeRequest projectEmployeeRequest)
	{
		
		var selectedEntity = await _projectEmployeeRepository.FirstOrDefaultAsync(x => x.ProjectId == projectId && x.EmployeeId == employeeId);
		if (selectedEntity == null)
		{
			return Result.Error(HttpStatusCode.NotFound, MessageAlert.ObjectNotFound(projectId, employeeId, "Project", "Employee"));
		}
		selectedEntity.Enable = projectEmployeeRequest.Enable;
		_projectEmployeeRepository.Update(selectedEntity);
		await _projectEmployeeRepository.SaveChangesAsync();
		return Result.Success(MessageAlert.UpdatedSuccessfully("ProjectEmployee"), HttpStatusCode.Created);
	}

	public async Task<Result> Delete(Guid projectId, Guid employeeId)
	{
		var selectedEntity = await _projectEmployeeRepository.FirstOrDefaultAsync(x => x.ProjectId == projectId && x.EmployeeId == employeeId);
		if (selectedEntity == null)
		{
			return Result.Error(HttpStatusCode.NotFound, MessageAlert.ObjectNotFound(projectId, employeeId, "Project", "Employee"));
		}
		_projectEmployeeRepository.Delete(selectedEntity);
		await _projectEmployeeRepository.SaveChangesAsync();
		return Result.Success(MessageAlert.DeletedSuccessfully("ProjectEmployee"), HttpStatusCode.NoContent);
	}

}
