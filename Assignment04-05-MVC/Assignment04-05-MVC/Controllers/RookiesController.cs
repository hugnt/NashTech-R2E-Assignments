using Assignment04_05_MVC.Helper;
using Assignment04_05_MVC.Services;
using Assignment04_05_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assignment04_05_MVC.Controllers;

public class RookiesController : Controller
{
    private readonly IPersonService _personService;
    public RookiesController(IPersonService personService)
    {
        _personService = personService;
    }

    public IActionResult Index(FilterModel filter)
    {
        var listPerson = _personService.GetByFilter(filter);

		var pageSize = filter.PageSize == 0 ? 5 : filter.PageSize;
		var pageNumber = filter.PageNumber == 0 ? 1 : filter.PageNumber;
		var skip = pageNumber * pageSize - pageSize;

		var personVM =  new PersonViewModel()
        {
            ListPerson = listPerson.Skip(skip).Take(pageSize).ToList(),
			DisplayFields = filter.DisplayFields,

			PageCount = listPerson.Count(),
			PageSize = pageSize,
			TotalPages = (int)Math.Ceiling((decimal)listPerson.Count() / pageSize),
			PageNumber = pageNumber,

            BirthYear = filter.BirthYear,
            BirthYearCompare = filter.BirthYearCompare,
            Gender = filter.Gender

		};
        return View(personVM);
    }

  

    
}
