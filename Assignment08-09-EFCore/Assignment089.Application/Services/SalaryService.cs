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

public class SalaryService : ISalaryService
{
	private readonly IRepository<Salary> _salaryRepository;
	private readonly IValidator<SalaryRequest> _salaryRequestValidator;
	public SalaryService(IRepository<Salary> salaryRepository, IValidator<SalaryRequest> salaryRequestValidator)
	{
		_salaryRepository = salaryRepository;
		_salaryRequestValidator = salaryRequestValidator;
	}

	public async Task<Result<List<SalaryResponse>>> GetAll()
	{
		var res = await _salaryRepository.SelectAsync(x=>x.ToResponse());
		return Result<List<SalaryResponse>>.SuccessWithBody(res.ToList());
	}

	public async Task<Result> GetById(Guid id)
	{
		var selectedEntity = await _salaryRepository.FirstOrDefaultAsync(x => x.Id == id);
		if (selectedEntity == null)
		{
			return Result.Error(HttpStatusCode.NotFound, MessageAlert.ObjectNotFound(id, "Salary"));
		}
		return Result<SalaryResponse>.SuccessWithBody(selectedEntity.ToResponse());
	}

	public async Task<Result> Add(SalaryRequest newSalary)
	{
		var validateResult = _salaryRequestValidator.Validate(newSalary);
		if (!validateResult.IsValid)
		{
			return Result.ErrorValidation(HttpStatusCode.BadRequest, validateResult.Errors.Select(x => x.ErrorMessage));
		}
		if (await _salaryRepository.AnyAsync(x=>x.EmployeeId == newSalary.EmployeeId))
		{
			return Result.Error(HttpStatusCode.BadRequest, MessageAlert.ObjectExisted(newSalary.EmployeeId, "Salary of employee"));
		}
		_salaryRepository.Add(newSalary.ToEntity());
		await _salaryRepository.SaveChangesAsync();
		return Result.SuccessWithMessage(MessageAlert.CreatedSuccessfully("Salary"));
	}

	public async Task<Result> Update(Guid id, SalaryRequest updatedSalary)
	{
		var validateResult = _salaryRequestValidator.Validate(updatedSalary);
		if (!validateResult.IsValid)
		{
			return Result.ErrorValidation(HttpStatusCode.BadRequest, validateResult.Errors.Select(x => x.ErrorMessage));
		}
		if (! await _salaryRepository.AnyAsync(x => x.Id == id))
		{
			return Result.Error(HttpStatusCode.NotFound, MessageAlert.ObjectNotFound(id, "Salary"));
		}
		if (!await _salaryRepository.AnyAsync(x => x.EmployeeId == updatedSalary.EmployeeId))
		{
			return Result.Error(HttpStatusCode.NotFound, MessageAlert.ObjectNotFound(updatedSalary.EmployeeId, "Salary of employee"));
		}
		var updatedEntity = updatedSalary.ToEntity();
		updatedEntity.Id = id;
		updatedEntity.UpdatedAt = DateTime.Now;
		_salaryRepository.Update(updatedEntity);
		await _salaryRepository.SaveChangesAsync();
		return Result.Success(MessageAlert.UpdatedSuccessfully(id, "Salary"), HttpStatusCode.Created);
	}

	public async Task<Result> Delete(Guid id)
	{
		var selectedEntity = await _salaryRepository.FirstOrDefaultAsync(x => x.Id == id);
		if (selectedEntity == null)
		{
			return Result.Error(HttpStatusCode.NotFound, MessageAlert.ObjectNotFound(id, "Salary"));
		}
		_salaryRepository.Delete(selectedEntity);
		await _salaryRepository.SaveChangesAsync();
		return Result.Success(MessageAlert.DeletedSuccessfully(id, "Salary"), HttpStatusCode.NoContent);
	}


}
