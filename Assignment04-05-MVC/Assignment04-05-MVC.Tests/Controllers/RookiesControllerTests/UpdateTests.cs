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

public class UpdateTests
{
	private readonly Mock<IPersonService> _mockPersonService;
	private readonly RookiesController _rookiesController;
	public UpdateTests()
	{
		_mockPersonService = new Mock<IPersonService>();
		_rookiesController = new RookiesController(_mockPersonService.Object);
	}

	[Fact]
	public void Update_ValidData_ReturnsJsonResult()
	{
		var personId = 1;
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
			StatusCode = HttpStatusCode.NoContent,
			Message = "Success",
			Errors = [],
			ErrorCode = ErrorCode.NoError
		};
		_mockPersonService.Setup(s => s.Update(personId, person)).Returns(serviceResult);

		var result = _rookiesController.Update(personId, person);

		var jsonResult = result.Should().BeOfType<JsonResult>().Subject;
		var jsonDeserialized = jsonResult.Value.Should().BeOfType<Result>().Subject;
		jsonDeserialized.Should().NotBeNull();
		jsonDeserialized.IsSuccess.Should().BeTrue();
		jsonDeserialized.StatusCode.Should().Be(HttpStatusCode.NoContent);
	}
}
