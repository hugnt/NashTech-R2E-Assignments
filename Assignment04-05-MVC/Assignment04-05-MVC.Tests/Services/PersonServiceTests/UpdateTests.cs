using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Models;
using Assignment04_05_MVC.Repositories;
using Assignment04_05_MVC.Services;
using Assignment04_05_MVC.Tests.Services.PersonServiceTest.TestData;
using Assignment04_05_MVC.Tests.TestData;
using Assignment04_05_MVC.Validators;
using DocumentFormat.OpenXml.Office2010.Excel;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_05_MVC.Tests.Services.PersonServiceTest;

public class UpdateTests
{
	private readonly Mock<IPersonRepository> _mockPersonRepository;
	private readonly PersonValidator _personValidator;
	private readonly PersonService _personService;
	public UpdateTests()
	{
		_mockPersonRepository = new Mock<IPersonRepository>();
		_personValidator = new PersonValidator();
		_personService = new PersonService(_mockPersonRepository.Object, _personValidator);
	}

	[Theory]
	[InlineData(11)]
	[InlineData(12)]
	[InlineData(13)]
	public void Update_NotExistedId_ReturnNotFound(int id)
	{
		var data = RepositoryData.ListPersonsTest().AsQueryable();
		_mockPersonRepository.Setup(r => r.GetAllQueryAble()).Returns(data);

		var result = _personService.Update(id, It.IsAny<Person>());

		result.IsSuccess.Should().BeFalse();
		result.StatusCode.Should().Be(HttpStatusCode.NotFound);
	}

	[Theory]
	[ClassData(typeof(PersonInValidUpdateTestData))]
	public void Update_InvalidPerson_ReturnErrorValidation(int id, Person person, Result expectedResult)
	{
		var data = RepositoryData.ListPersonsTest().AsQueryable();
		_mockPersonRepository.Setup(r => r.GetAllQueryAble()).Returns(data);

		var result = _personService.Update(id, person);

		result.IsSuccess.Should().Be(expectedResult.IsSuccess);
		result.StatusCode.Should().Be(expectedResult.StatusCode);
		result.ErrorCode.Should().Be(expectedResult.ErrorCode);
	}

	[Theory]
	[ClassData(typeof(PersonPhoneNumberExistedUpdateTestData))]
	public void Update_PhoneNumberExisted_ReturnErrorResult(int id, Person person, Result expectedResult)
	{
		var data = RepositoryData.ListPersonsTest().AsQueryable();
		_mockPersonRepository.Setup(r => r.GetAllQueryAble()).Returns(data);

		var result = _personService.Update(id, person);

		result.IsSuccess.Should().Be(expectedResult.IsSuccess);
		result.StatusCode.Should().Be(expectedResult.StatusCode);
	}

	[Theory]
	[ClassData(typeof(PersonValidUpdateTestData))]
	public void Update_ValidPerson_ReturnResultSuccess(int id, Person person, Result expectedResult)
	{
		var data = RepositoryData.ListPersonsTest().AsQueryable();
		_mockPersonRepository.Setup(r => r.GetAllQueryAble()).Returns(data);

		var result = _personService.Update(id, person);

		result.IsSuccess.Should().Be(expectedResult.IsSuccess);
		result.StatusCode.Should().Be(expectedResult.StatusCode);

		_mockPersonRepository.Verify(x => x.Update(It.IsAny<Person>()), Times.Once);
	}
}
