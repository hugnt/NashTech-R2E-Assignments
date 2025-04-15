using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Models;
using Assignment04_05_MVC.Tests.TestData;
using Assignment04_05_MVC.ViewModels;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_05_MVC.Tests.Controllers.RookiesControllerTests.TestData;

public class IndexTestData : TheoryData<FilterModel, List<Person>, PersonViewModel>
{
	public IndexTestData()
	{
		var lstMockFilter0 = RepositoryData.ListPersonsTest();
		var lstMockFilter1 = lstMockFilter0.Where(x => x.Gender == Gender.Male).ToList();
		var lstMockFilter2 = lstMockFilter0.Where(x => x.DateOfBirth.Year > 2000).ToList();

		Add(new FilterModel()
		{
			PageSize = 0,
			PageNumber = 0,
		},
		lstMockFilter0,
		new PersonViewModel()
		{
			ListPerson = lstMockFilter0.Take(5).ToList(),
			PageSize = 5,
			PageNumber = 1,
		});

		Add(new FilterModel()
		{
			PageSize = 0,
			PageNumber = 0,
			Gender = Gender.Male
		},
		lstMockFilter1, 
		new PersonViewModel()
		{
			ListPerson = lstMockFilter1.Take(5).ToList(),
			PageSize = 5,
			PageNumber = 1,
		});

		Add(new FilterModel()
		{
			PageSize = 10,
			PageNumber = 2,
			BirthYear = 2000,
			BirthYearCompare = BirthYearCompare.Greater
		},
		lstMockFilter2,
		new PersonViewModel()
		{
			ListPerson = lstMockFilter2.Skip(10).Take(10).ToList(),
			PageSize = 10,
			PageNumber = 2,
		});

	
	}
}
