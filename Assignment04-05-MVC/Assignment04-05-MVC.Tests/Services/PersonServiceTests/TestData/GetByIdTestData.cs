using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Models;
using System.Net;

namespace Assignment04_05_MVC.Tests.Services.PersonServiceTest.TestData;

public class ValidIdGetByIdTestData : TheoryData<int, Result<Person>>
{
	public ValidIdGetByIdTestData()
	{
		Add(
			1, 
			Result<Person>.SuccessWithBody(new Person
			{
				Id = 1,
				FirstName = "John",
				LastName = "Smith",
				Gender = Gender.Male,
				DateOfBirth = new DateTime(1985, 6, 15),
				PhoneNumber = "0123456789",
				BirthPlace = "New York",
				IsGraduated = true
			})
		);

		Add(
			2,
			Result<Person>.SuccessWithBody(new Person
			{
				Id = 2,
				FirstName = "Emma",
				LastName = "Johnson",
				Gender = Gender.Female,
				DateOfBirth = new DateTime(1990, 3, 22),
				PhoneNumber = "0987654321",
				BirthPlace = "Los Angeles",
				IsGraduated = false
			})
		);


	}
}
