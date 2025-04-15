using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Common.Enums;
using Assignment04_05_MVC.Models;
using Assignment04_05_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_05_MVC.Tests.Controllers.RookiesControllerTests.TestData;

public class DetailsTestData : TheoryData<FormRequestModel, Result<Person> ,PersonDetailsViewModel>
{
	public DetailsTestData()
	{
		var mockPersonData1 = new Person()
		{
			Id = 1,
			FirstName = "John",
			LastName = "Smith",
			Gender = Gender.Male,
			DateOfBirth = new DateTime(1985, 6, 15),
			PhoneNumber = "0123456789",
			BirthPlace = "New York",
			IsGraduated = true
		};

		var mockPersonData2 = new Person()
		{
			Id = 2,
			FirstName = "Emma",
			LastName = "Johnson",
			Gender = Gender.Female,
			DateOfBirth = new DateTime(1990, 3, 22),
			PhoneNumber = "0987654321",
			BirthPlace = "Los Angeles",
			IsGraduated = false
		};

		Add(
			new FormRequestModel()
			{
				Id = 1,
				FormMode = FormMode.Detail
			},
			Result<Person>.SuccessWithBody(mockPersonData1),
			new PersonDetailsViewModel()
			{
				FormMode = FormMode.Detail,
				Person = mockPersonData1
			}
		);

		Add(
			new FormRequestModel()
			{
				Id = 2,
				FormMode = FormMode.Update
			},
			Result<Person>.SuccessWithBody(mockPersonData2),
			new PersonDetailsViewModel()
			{
				FormMode = FormMode.Update,
				Person = mockPersonData2,
				RouteAction = "/Rookies/Update?id=2",
				Method = "PUT"
			}
		);
	}
}
