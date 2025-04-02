using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Common.Enums;
using Assignment04_05_MVC.Common.Helper;
using Assignment04_05_MVC.Models;
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


    public IActionResult Details(FormRequestModel formRequest)
    {
        var personDetailsViewModel = new PersonDetailsViewModel();
		personDetailsViewModel.FormMode = formRequest.FormMode;
		
		if (formRequest.FormMode == FormMode.Detail||formRequest.FormMode == FormMode.Update)
		{
			var selectedPerson = _personService.GetById(formRequest.Id);
			personDetailsViewModel.Title = (formRequest.FormMode) switch
			{
				FormMode.Detail => $"Details about {selectedPerson.Metadata.FullName}",
				FormMode.Update => $"Update {selectedPerson.Metadata.FullName}"
			};
			personDetailsViewModel.Person = selectedPerson.Metadata;
			
			if (formRequest.FormMode == FormMode.Update)
			{
				personDetailsViewModel.RouteAction = $"/Rookies/Update?id={formRequest.Id}";
				personDetailsViewModel.Method = "PUT";
			}
		}
		else if (formRequest.FormMode == FormMode.Add)
		{
			personDetailsViewModel.RouteAction = $"/Rookies/AddNew";
			personDetailsViewModel.Method = "POST";
			personDetailsViewModel.Title = "Add new rookies";
			personDetailsViewModel.Person = new Person()
			{
				DateOfBirth = new DateTime(2000, 1, 1)
			};
		}
		return View(personDetailsViewModel);
    }


    [HttpPost]
    public IActionResult ExportToExcel(string displayFields, [FromBody]List<Person> lstPersons)
    {
        var exportedResult = FileExport.ExportToExcel<Person>(lstPersons, displayFields);
		return new FileContentResult(exportedResult, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
		{
			FileDownloadName = "ExportData.xlsx"
		};
	}

	[HttpPost]
	public IActionResult AddNew([FromBody]Person person)
	{
		var result = _personService.Add(person);
		return Json(result);
	}

	[HttpPut]
	public IActionResult Update(int id, [FromBody] Person person)
	{
		var result = _personService.Update(id, person);
		return Json(result);
	}

	[HttpDelete]
	public IActionResult Delete(int id)
	{
		return Json(_personService.Delete(id));
	}




}
