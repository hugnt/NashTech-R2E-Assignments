using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Models;
using Assignment04_05_MVC.Repositories;
using DocumentFormat.OpenXml.Office2010.Excel;
using FluentValidation;
using System.Linq.Expressions;
using System.Net;

namespace Assignment04_05_MVC.Services;

public class PersonService:IPersonService
{
    private readonly IPersonRepository _personRepository;
	private readonly IValidator<Person> _personValidator;
	public PersonService(IPersonRepository personRepository, IValidator<Person> personValidator)
	{
		_personRepository = personRepository;
		_personValidator = personValidator;
	}

	public List<Person> GetByFilter(FilterModel filter)
    {

		var query = _personRepository.GetAllQueryAble();

		//Gender
		if (filter.Gender != null)
		{
			query = query.Where(x => x.Gender == filter.Gender);
		}

		//Birth Year
		if (filter.BirthYearCompare != BirthYearCompare.None)
		{
			switch (filter.BirthYearCompare)
			{
				case BirthYearCompare.Greater:
					query = query.Where(x => x.DateOfBirth.Year > filter.BirthYear);
					break;
				case BirthYearCompare.Equal:
					query = query.Where(x => x.DateOfBirth.Year == filter.BirthYear);
					break;
				case BirthYearCompare.Lower:
					query = query.Where(x => x.DateOfBirth.Year < filter.BirthYear);
					break;
			}
		}

		//Age
		if (!string.IsNullOrEmpty(filter.OrderBy))
		{
			var parameter = Expression.Parameter(typeof(Person), "x");
			var property = Expression.Property(parameter, filter.OrderBy);

			// Explicitly cast the property to 'object' for the lambda expression
			var lambda = Expression.Lambda<Func<Person, object>>(Expression.Convert(property, typeof(object)), parameter);

			if (filter.IsReverse)
			{
				query = query.OrderByDescending(lambda);
			}
			else
			{
				query = query.OrderBy(lambda);
			}
		}

		if(filter.Limit != -1) query = query.Take(filter.Limit);

		return query.ToList();
    }

	public Result<Person> GetById(int id)
	{
		var selectedPerson = _personRepository.GetAllQueryAble().FirstOrDefault(x => x.Id == id);
		if (selectedPerson == null) return Result<Person>.Error(HttpStatusCode.NotFound,"Person is not existed!")
;		return Result<Person>.SuccessWithBody(selectedPerson);
	}

	public Result Add(Person person)
	{
		var validateResult = _personValidator.Validate(person);
		if (!validateResult.IsValid)
		{
			return Result.ErrorValidation(HttpStatusCode.BadRequest, validateResult.Errors.Select(x => x.ErrorMessage));
		}
		if (_personRepository.GetAllQueryAble().Any(x => x.PhoneNumber == person.PhoneNumber))
		{
			return Result.Error(HttpStatusCode.BadRequest, "Phone number is existed!");
		}
		_personRepository.Add(person);
		return Result.Success("Created Successfullt", HttpStatusCode.Created);
	}

	public Result Delete(int id)
	{
		var selectedPerson = _personRepository.GetAllQueryAble().FirstOrDefault(x => x.Id == id);
		if (selectedPerson==null) return Result.Error(HttpStatusCode.NotFound,"Person is not existed!");
		_personRepository.Remove(selectedPerson);
		return Result.SuccessNoContent();
	}

	public Result Update(int id, Person person)
	{
		if(!_personRepository.GetAllQueryAble().Any(x=> x.Id == id)) return Result.Error(HttpStatusCode.NotFound, "Person is not existed!");
		var validateResult = _personValidator.Validate(person);
		if (!validateResult.IsValid)
		{
			return Result.ErrorValidation(HttpStatusCode.BadRequest, validateResult.Errors.Select(x => x.ErrorMessage));
		}
		if (_personRepository.GetAllQueryAble().Any(x => x.PhoneNumber == person.PhoneNumber))
		{
			return Result.Error(HttpStatusCode.BadRequest, "Phone number is existed!");
		}
		//Check phone number existed
		person.Id = id;
		_personRepository.Update(person);
		return Result.SuccessNoContent();
	}

}
