using Assignment04_05_MVC.Models;
using Assignment04_05_MVC.Repositories;
using Assignment04_05_MVC.Tests.TestData;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_05_MVC.Tests.Repositories.PersonRepositoryTests;

public class UpdateTests
{
	private readonly PersonRepository _personRepository;
	public UpdateTests()
	{
		_personRepository = new PersonRepository();
	}

	[Fact]
	public void Update_ExistingPerson_PersonUpdatedInList()
	{
		var updatedPerson = new Person
		{
			Id = 1,
			FirstName = "John",
			LastName = "Smith",
			Gender = Gender.Male,
			DateOfBirth = new DateTime(1985, 6, 15),
			PhoneNumber = "0123456789",
			BirthPlace = "Ha Noi",
			IsGraduated = true
		};
		_personRepository.MockData(RepositoryData.ListPersonsTest());
		

		_personRepository.Update(updatedPerson);

		_personRepository.GetMockData()
		.Should().ContainSingle(x => x.Id == 1)
		.Which.Should().BeEquivalentTo(updatedPerson);
		
	}
}
