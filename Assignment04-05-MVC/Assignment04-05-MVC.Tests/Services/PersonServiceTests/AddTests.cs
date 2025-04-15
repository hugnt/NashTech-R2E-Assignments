using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Models;
using Assignment04_05_MVC.Repositories;
using Assignment04_05_MVC.Services;
using Assignment04_05_MVC.Tests.Services.PersonServiceTest.TestData;
using Assignment04_05_MVC.Tests.TestData;
using Assignment04_05_MVC.Validators;
using DocumentFormat.OpenXml.EMMA;
using FluentAssertions;
using FluentValidation;
using FluentValidation.TestHelper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_05_MVC.Tests.Services.PersonServiceTest;

public class AddTests
{

	private readonly Mock<IPersonRepository> _mockPersonRepository;
	private readonly PersonValidator _personValidator;
	private readonly PersonService _personService;
	public AddTests()
	{
		_mockPersonRepository = new Mock<IPersonRepository>();
		_personValidator = new PersonValidator();
		_personService = new PersonService(_mockPersonRepository.Object, _personValidator);
	}

	[Theory]
	[ClassData(typeof(PersonFailedValidateTestData))]
	public void Add_InvalidPerson_ReturnErrorValidation(Person person, Result expectedResult)
	{
		var result = _personService.Add(person);

		result.Should().BeOfType<Result>();
		result.IsSuccess.Should().Be(expectedResult.IsSuccess);
		result.StatusCode.Should().Be(expectedResult.StatusCode);
		result.ErrorCode.Should().Be(expectedResult.ErrorCode);
	}

	[Theory]
	[ClassData(typeof(PersonPhoneNumberExistedAddTestData))]
	public void Add_PhoneNumberExisted_ReturnErrorResult(Person person, Result expectedResult)
	{
		var data = RepositoryData.ListPersonsTest().AsQueryable();
		_mockPersonRepository.Setup(r => r.GetAllQueryAble()).Returns(data);

		var result = _personService.Add(person);

		result.Should().BeOfType<Result>();
		result.IsSuccess.Should().Be(expectedResult.IsSuccess);
		result.StatusCode.Should().Be(expectedResult.StatusCode);
	}

	[Theory]
	[ClassData(typeof(PersonValidTestData))]
	public void Add_ValidPerson_ReturnsSuccessResult(Person person, Result expectedResult)
	{
		var data = RepositoryData.ListPersonsTest().AsQueryable();
		_mockPersonRepository.Setup(r => r.GetAllQueryAble()).Returns(data);

		var result = _personService.Add(person);

		result.Should().BeOfType<Result>();
		result.IsSuccess.Should().Be(expectedResult.IsSuccess);
		result.StatusCode.Should().Be(expectedResult.StatusCode);

		_mockPersonRepository.Verify(r => r.Add(person), Times.Once());
	}
}
