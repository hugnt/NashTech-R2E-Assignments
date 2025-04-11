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

public class ProjectService : IProjectService
{
	private readonly IRepository<Project> _projectRepository;
	private readonly IValidator<ProjectRequest> _projectRequestValidator;
	public ProjectService(IRepository<Project> projectRepository, IValidator<ProjectRequest> projectRequestValidator)
	{
		_projectRepository = projectRepository;
		_projectRequestValidator = projectRequestValidator;
	}

	public async Task<Result<List<ProjectResponse>>> GetAll()
	{
		var res = await _projectRepository.SelectAsync(x=>x.ToResponse());
		return Result<List<ProjectResponse>>.SuccessWithBody(res.ToList());
	}

	public async Task<Result> GetById(Guid id)
	{
		var selectedEntity = await _projectRepository.FirstOrDefaultAsync(x => x.Id == id);
		if (selectedEntity == null)
		{
			return Result.Error(HttpStatusCode.NotFound, MessageAlert.ObjectNotFound(id, "Project"));
		}
		return Result<ProjectResponse>.SuccessWithBody(selectedEntity.ToResponse());
	}

	public async Task<Result> Add(ProjectRequest newProject)
	{
		var validateResult = _projectRequestValidator.Validate(newProject);
		if (!validateResult.IsValid)
		{
			return Result.ErrorValidation(HttpStatusCode.BadRequest, validateResult.Errors.Select(x => x.ErrorMessage));
		}
		_projectRepository.Add(newProject.ToEntity());
		await _projectRepository.SaveChangesAsync();
		return Result.SuccessWithMessage(MessageAlert.CreatedSuccessfully("Project"));
	}

	public async Task<Result> Update(Guid id, ProjectRequest updatedProject)
	{
		var validateResult = _projectRequestValidator.Validate(updatedProject);
		if (!validateResult.IsValid)
		{
			return Result.ErrorValidation(HttpStatusCode.BadRequest, validateResult.Errors.Select(x => x.ErrorMessage));
		}
		var isExisted = await _projectRepository.AnyAsync(x=>x.Id == id);
		if (!isExisted)
		{
			return Result.Error(HttpStatusCode.NotFound, MessageAlert.ObjectNotFound(id, "Project"));
		}
		var updatedEntity = updatedProject.ToEntity();
		updatedEntity.Id = id;
		updatedEntity.UpdatedAt = DateTime.Now;
		_projectRepository.Update(updatedEntity);
		await _projectRepository.SaveChangesAsync();
		return Result.Success(MessageAlert.UpdatedSuccessfully(id, "Project"), HttpStatusCode.Created);
	}

	public async Task<Result> Delete(Guid id)
	{
		var selectedEntity = await _projectRepository.FirstOrDefaultAsync(x => x.Id == id);
		if (selectedEntity == null)
		{
			return Result.Error(HttpStatusCode.NotFound, MessageAlert.ObjectNotFound(id, "Project"));
		}
		_projectRepository.Delete(selectedEntity);
		await _projectRepository.SaveChangesAsync();
		return Result.Success(MessageAlert.DeletedSuccessfully(id, "Project"), HttpStatusCode.NoContent);
	}


}
