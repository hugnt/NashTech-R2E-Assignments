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

public class RemoveTests
{
	private readonly PersonRepository _personRepository;
	public RemoveTests()
	{
		_personRepository = new PersonRepository();
	}

	[Fact]
	public void Remove_ExistingPerson_PersonRemovedFromList()
	{
		_personRepository.MockData(RepositoryData.ListPersonsTest());
		var person = _personRepository.GetMockData().FirstOrDefault(x => x.Id == 1);

		_personRepository.Remove(person!);

		_personRepository.GetMockData().Should().HaveCount(9);
		_personRepository.GetMockData().Should().NotContain(x => x.Id == 1);
	}
}
