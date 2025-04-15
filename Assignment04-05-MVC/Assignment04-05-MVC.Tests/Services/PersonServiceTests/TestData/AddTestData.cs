using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Models;
using System.Net;

namespace Assignment04_05_MVC.Tests.Services.PersonServiceTest.TestData;

public class PersonFailedValidateTestData : TheoryData<Person, Result>
{
	public PersonFailedValidateTestData()
	{
		Add(new Person(), new Result { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest, ErrorCode = ErrorCode.Validation});
		Add(new Person()
		{
			FirstName ="Test",
			LastName = "Last 2",
			BirthPlace = "",
			DateOfBirth = DateTime.Now,
			PhoneNumber = ""
		}, new Result { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest, ErrorCode = ErrorCode.Validation });
		Add(new Person()
		{
			FirstName = "Test",
			LastName = "Last 2",
			BirthPlace = "",
			DateOfBirth = DateTime.Now.AddYears(4),
			PhoneNumber = "0946928815"
		}, new Result { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest, ErrorCode = ErrorCode.Validation });
	}
}

public class PersonPhoneNumberExistedAddTestData : TheoryData<Person, Result>
{
	public PersonPhoneNumberExistedAddTestData()
	{
		Add(
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

		Add(new Person()
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

public class PersonValidTestData : TheoryData<Person, Result>
{
	public PersonValidTestData()
	{
		Add(new Person()
		{
			FirstName = "Hung",
			LastName = "Nguyen",
			BirthPlace = "Ha noi",
			DateOfBirth = new DateTime(2003, 12, 2),
			PhoneNumber = "0946928815",
			Gender = Gender.Male,
			IsGraduated = true
		}, new Result { IsSuccess = true, StatusCode = HttpStatusCode.Created });

		Add(new Person()
		{
			FirstName = "Khanh",
			LastName = "Tran",
			BirthPlace = "Ho chi minh",
			DateOfBirth = new DateTime(2002, 1, 1),
			PhoneNumber = "0787394895",
			Gender = Gender.Female,
			IsGraduated = false
		}, new Result { IsSuccess = true, StatusCode = HttpStatusCode.Created });
	}
}

