using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Controllers;
using Assignment04_05_MVC.Models;
using Assignment04_05_MVC.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_05_MVC.Tests.Controllers.RookiesControllerTests;

public class AddNewTests
{

	private readonly Mock<IPersonService> _mockPersonService;
	private readonly RookiesController _rookiesController;
	public AddNewTests()
	{
		_mockPersonService = new Mock<IPersonService>();
		_rookiesController = new RookiesController(_mockPersonService.Object);
	}

	[Fact]
	public void AddNew_ValidPerson_ReturnsJsonResult()
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
		var serviceResult = new Result
		{
			IsSuccess = true,
			StatusCode = HttpStatusCode.Created,
			Message = "Success",
			Errors = [],
			ErrorCode = ErrorCode.NoError
		};
		_mockPersonService.Setup(s => s.Add(person)).Returns(serviceResult);

		var result = _rookiesController.AddNew(person);

		var jsonResult = result.Should().BeOfType<JsonResult>().Subject;
		var jsonDeserialized = jsonResult.Value.Should().BeOfType<Result>().Subject;
		jsonDeserialized.Should().NotBeNull();
		jsonDeserialized.IsSuccess.Should().BeTrue();
		jsonDeserialized.StatusCode.Should().Be(HttpStatusCode.Created);
	}

	[Fact]
	public void AddNew_InvalidPerson_ReturnsJsonError()
	{
		var person = new Person
		{
			FirstName = "",
			LastName = "Johnson",
			Gender = Gender.Female,
			DateOfBirth = new DateTime(1990, 3, 22),
			PhoneNumber = "0987658321",
			BirthPlace = "Los Angeles",
			IsGraduated = false
		};
		var serviceResult = new Result
		{
			IsSuccess = false,
			StatusCode = HttpStatusCode.BadRequest,
			ErrorCode = ErrorCode.Validation,
			Errors = new List<string>() { "First name cannot be empty" }
		};
		_mockPersonService.Setup(s => s.Add(person)).Returns(serviceResult);

		var result = _rookiesController.AddNew(person);

		var jsonResult = result.Should().BeOfType<JsonResult>().Subject;
		var jsonDeserialized = jsonResult.Value.Should().BeOfType<Result>().Subject;
		jsonDeserialized.Should().NotBeNull();
		jsonDeserialized.IsSuccess.Should().BeFalse();
		jsonDeserialized.StatusCode.Should().Be(HttpStatusCode.BadRequest);
		jsonDeserialized.ErrorCode.Should().Be(ErrorCode.Validation);
	}
}
