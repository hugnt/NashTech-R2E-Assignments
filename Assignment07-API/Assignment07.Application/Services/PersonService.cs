using Assignment07.Application.Common;
using Assignment07.Application.Models.Mapping;
using Assignment07.Application.Models.Requests;
using Assignment07.Application.Models.Responses;
using Assignment07.Domain.Entities;
using Assignment07.Application.Common.Exceptions;
using Assignment07.Domain.Repositories;
using Assignment07.Domain.Shared;
using FluentValidation;
using System.Net;
using Assignment07.Persistence;
using System.Linq.Expressions;

namespace Assignment07.Application.Services;

public class PersonService : IPersonService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IPersonRepository _personRepository;
	private readonly IValidator<PersonRequest> _personRequestValidator;
	public PersonService(IPersonRepository personRepository, IUnitOfWork unitOfWork, IValidator<PersonRequest> personRequestValidator)
    {
		_personRepository = personRepository;
		_personRequestValidator = personRequestValidator;
		_unitOfWork = unitOfWork;
	}
    public Result Add(PersonRequest newPerson)
	{
		var validateResult = _personRequestValidator.Validate(newPerson);
		if (!validateResult.IsValid) throw new Common.Exceptions.ValidationException(validateResult.Errors.Select(x => x.ErrorMessage));
		var newEntity = newPerson.ToEntity();
		newEntity.CreatedAt = DateTime.Now;
		_personRepository.Add(newEntity);
		_unitOfWork.SaveChanges();
		return Result.Success(MessageAlert.CreatedSuccessfully("Person"), HttpStatusCode.Created);
	}

	public Result Delete(Guid id)
	{
		var selectedEntity = _personRepository.GetAll().FirstOrDefault(x => x.Id == id);
		if (selectedEntity == null) throw new ObjectNotExistedException(MessageAlert.ObjectNotFound(id, "Person"));
		_personRepository.Delete(selectedEntity);
		_unitOfWork.SaveChanges();
		return Result.Success(MessageAlert.DeletedSuccessfully(id,"Person"), HttpStatusCode.NoContent); 
	}

	public Result Update(Guid id, PersonRequest updatedPerson)
	{
		var validateResult = _personRequestValidator.Validate(updatedPerson);
		if (!validateResult.IsValid) throw new Common.Exceptions.ValidationException(validateResult.Errors.Select(x => x.ErrorMessage));
		if (!_personRepository.GetAll().Any(x=>x.Id==id)) throw new ObjectNotExistedException(MessageAlert.ObjectNotFound(id, "Person"));
		var updatedEntity = updatedPerson.ToEntity();
		updatedEntity.Id = id;
		updatedEntity.UpdatedAt = DateTime.Now;
		_personRepository.Update(updatedEntity);
		_unitOfWork.SaveChanges();
		return Result.Success(MessageAlert.UpdatedSuccessfully(id, "Person"), HttpStatusCode.Created);
		
	}

	public Result<List<PersonResponse>> Filter(PersonFilterRequest filterModel)
	{
		var query = _personRepository.GetAll();

		//Name
		if (!String.IsNullOrEmpty(filterModel.Name))
		{
			query = query.Where(x => x.FirstName.Contains(filterModel.Name.Trim())|| x.LastName.Contains(filterModel.Name.Trim()));
		}

		//Gender
		if (filterModel.Gender != null)
		{
			query = query.Where(x => x.Gender == filterModel.Gender);
		}

		//Birth place
		if (!String.IsNullOrEmpty(filterModel.BirthPlace))
		{
			query = query.Where(x => x.BirthPlace.Contains(filterModel.BirthPlace.Trim()));
		}

		var res = query.Select(x => x.ToResponse()).ToList();
		return Result<List<PersonResponse>>.SuccessWithBody(res);
	}
}
