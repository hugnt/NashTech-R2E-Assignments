using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Models;
using Assignment04_05_MVC.Repositories;
using Assignment04_05_MVC.Services;
using Assignment04_05_MVC.Tests.Services.PersonServiceTest.TestData;
using Assignment04_05_MVC.Tests.TestData;
using Assignment04_05_MVC.Validators;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_05_MVC.Tests.Services.PersonServiceTest;

public class GetByIdTest
{
	private readonly Mock<IPersonRepository> _mockPersonRepository;
	private readonly PersonService _personService;
	public GetByIdTest()
	{
		_mockPersonRepository = new Mock<IPersonRepository>();
		_personService = new PersonService(_mockPersonRepository.Object, null);
	}

	[Theory]
	[InlineData(11)]
	[InlineData(12)]
	[InlineData(13)]
	public void GetById_NotExistedId_ReturnNotFound(int id)
	{
		var data = RepositoryData.ListPersonsTest().AsQueryable();
		_mockPersonRepository.Setup(r => r.GetAllQueryAble()).Returns(data);

		var result = _personService.GetById(id);

		result.Should().BeOfType<Result<Person>>();
		result.IsSuccess.Should().BeFalse();
		result.StatusCode.Should().Be(HttpStatusCode.NotFound);
	}

	[Theory]
	[ClassData(typeof(ValidIdGetByIdTestData))]
	public void GetById_ValidId_ReturnPerson(int id, Result<Person> expectedResult)
	{
		var data = RepositoryData.ListPersonsTest().AsQueryable();
		_mockPersonRepository.Setup(r => r.GetAllQueryAble()).Returns(data);

		var result = _personService.GetById(id);

		result.Should().BeOfType<Result<Person>>();
		result.IsSuccess.Should().BeTrue();
		result.StatusCode.Should().Be(expectedResult.StatusCode);
		result.Metadata.Should().NotBeNull();
		result.Metadata.Id.Should().Be(expectedResult.Metadata!.Id);
		result.Metadata.PhoneNumber.Should().Be(expectedResult.Metadata!.PhoneNumber);
	}

}
