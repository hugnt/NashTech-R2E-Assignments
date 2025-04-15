using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_05_MVC.Tests.Services.PersonServiceTest.TestData;

public class PersonInValidUpdateTestData : TheoryData<int, Person, Result>
{
	public PersonInValidUpdateTestData()
	{
		Add(1,
			new Person()
			{
				FirstName = "",
				LastName = "",
				DateOfBirth = new DateTime(2002,10,10),
				BirthPlace = "Ha noi",
				Gender = Gender.Male,
				PhoneNumber = "0946928815",
				IsGraduated = false,
			},
			new Result 
			{ 
				IsSuccess = false, 
				StatusCode = HttpStatusCode.BadRequest, 
				ErrorCode = ErrorCode.Validation 
			});

		Add(2,
			new Person()
			{
				FirstName = "Nguyen",
				LastName = "Hung",
				DateOfBirth = DateTime.Now.AddYears(2),
				BirthPlace = "Ha noi",
				Gender = Gender.Male,
				PhoneNumber = "0946928815",
				IsGraduated = false,
			},
			new Result
			{
				IsSuccess = false,
				StatusCode = HttpStatusCode.BadRequest,
				ErrorCode = ErrorCode.Validation
			});
	}
}

public class PersonPhoneNumberExistedUpdateTestData : TheoryData<int, Person, Result>
{
	public PersonPhoneNumberExistedUpdateTestData()
	{
		Add(1,
			new Person()
			{
				FirstName = "Nguyen",
				LastName = "Hung",
				DateOfBirth = new DateTime(2002, 10, 10),
				BirthPlace = "Ha noi",
				Gender = Gender.Male,
				PhoneNumber = "0876543210",
				IsGraduated = false,
			},
			new Result
			{
				IsSuccess = false,
				StatusCode = HttpStatusCode.BadRequest,
			});

		Add(2,
			new Person()
			{
				FirstName = "Doan",
				LastName = "Duc",
				DateOfBirth = new DateTime(2003, 2, 2),
				BirthPlace = "Ha noi",
				Gender = Gender.Male,
				PhoneNumber = "0654321098",
				IsGraduated = false,
			},
			new Result
			{
				IsSuccess = false,
				StatusCode = HttpStatusCode.BadRequest
			});
	}
}


public class PersonValidUpdateTestData : TheoryData<int, Person, Result>
{
	public PersonValidUpdateTestData()
	{
		Add(
			1,
			new Person()
			{
				FirstName = "Hug",
				LastName = "Nguyen",
				DateOfBirth = new DateTime(2002, 10, 10),
				BirthPlace = "Ha noi",
				Gender = Gender.Male,
				PhoneNumber = "0946928815",
				IsGraduated = false,
			},
			new Result
			{
				IsSuccess = true,
				StatusCode = HttpStatusCode.NoContent,
			}
		);

		Add(
			2,
			new Person()
			{
				FirstName = "Nguyen",
				LastName = "Hung",
				DateOfBirth = new DateTime(2003, 1, 1),
				BirthPlace = "Ha noi",
				Gender = Gender.Male,
				PhoneNumber = "0946928867",
				IsGraduated = false,
			},
			new Result
			{
				IsSuccess = true,
				StatusCode = HttpStatusCode.NoContent
			}
		);
	}
}
