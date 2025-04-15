using Assignment04_05_MVC.Repositories;
using Assignment04_05_MVC.Services;
using Assignment04_05_MVC.Tests.TestData;
using Assignment04_05_MVC.Validators;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_05_MVC.Tests.Repositories.PersonRepositoryTests;

public class GetAllQueryAbleTests
{
	private readonly PersonRepository _personRepository;
	public GetAllQueryAbleTests()
	{
		_personRepository = new PersonRepository();
	}

	[Fact]
	public void GetAllQueryAble_ReturnAllData()
	{
		_personRepository.MockData(RepositoryData.ListPersonsTest());
		
		var result = _personRepository.GetAllQueryAble();

		result.Should().HaveCount(RepositoryData.ListPersonsTest().Count);
	}
}
