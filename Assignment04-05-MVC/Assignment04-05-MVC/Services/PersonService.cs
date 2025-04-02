using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Models;
using Assignment04_05_MVC.Repositories;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Linq.Expressions;
using System.Net;

namespace Assignment04_05_MVC.Services;

public class PersonService:IPersonService
{
    private readonly IPersonRepository _personRepository;
    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
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

	public ResultModel<Person> GetById(int id)
	{
		var selectedPerson = _personRepository.GetAllQueryAble().FirstOrDefault(x => x.Id == id);
		if (selectedPerson == null) return ResultModel<Person>.Error("Person is not existed!", HttpStatusCode.NotFound)
;		return ResultModel<Person>.SuccessWithBody(selectedPerson);
	}

	public ResultModel<Person> Add(Person person)
	{
		_personRepository.Add(person);
		return ResultModel<Person>.SuccessWithBody(person);
	}

	public ResultModel<bool> Delete(int id)
	{
		var selectedPerson = _personRepository.GetAllQueryAble().FirstOrDefault(x => x.Id == id);
		if (selectedPerson==null) return ResultModel<bool>.Error("Person is not existed!", HttpStatusCode.NotFound);
		_personRepository.Remove(selectedPerson);
		return ResultModel<bool>.SuccessNoContent();
	}

	public ResultModel<Person> Update(int id, Person person)
	{
		if(!_personRepository.IsExist(id)) return ResultModel<Person>.Error("Person is not existed!", HttpStatusCode.NotFound);
		person.Id = id;
		_personRepository.Update(person);
		return ResultModel<Person>.SuccessWithBody(person);
	}

}
