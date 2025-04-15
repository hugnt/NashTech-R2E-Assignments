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

public class AddTests
{
	private readonly PersonRepository _personRepository;
	public AddTests()
	{
		_personRepository = new PersonRepository();
	}

	[Fact]
	public void Add_ValidPerson_PersonAddedInList()
	{
		var person = new Person
		{
			FirstName = "Elon",
			LastName = "Musk",
			Gender = Gender.Female,
			DateOfBirth = new DateTime(1990, 3, 22),
			PhoneNumber = "0987658321",
			BirthPlace = "Los Angeles",
			IsGraduated = false
		};
		_personRepository.MockData(RepositoryData.ListPersonsTest());

		_personRepository.Add(person);

		_personRepository.GetMockData().Should().HaveCount(11);
		person.Id.Should().Be(11);
	}
}
