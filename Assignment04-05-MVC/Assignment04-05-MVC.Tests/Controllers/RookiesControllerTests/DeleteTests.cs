using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Controllers;
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

public class DeleteTests
{
	private readonly Mock<IPersonService> _mockPersonService;
	private readonly RookiesController _rookiesController;
	public DeleteTests()
	{
		_mockPersonService = new Mock<IPersonService>();
		_rookiesController = new RookiesController(_mockPersonService.Object);
	}

	[Fact]
	public void Delete_NonExistentPerson_ReturnsJsonResult()
	{
		var personId = 999;
		var serviceResult = new Result
		{
			IsSuccess = false,
			StatusCode = HttpStatusCode.NotFound
		};
		_mockPersonService.Setup(s => s.Delete(personId)).Returns(serviceResult);

		var result = _rookiesController.Delete(personId);

		var jsonResult = result.Should().BeOfType<JsonResult>().Subject;
		var jsonDeserialized = jsonResult.Value.Should().BeOfType<Result>().Subject;
		jsonDeserialized.Should().NotBeNull();
		jsonDeserialized.IsSuccess.Should().BeFalse();
		jsonDeserialized.StatusCode.Should().Be(HttpStatusCode.NotFound);
	}

	[Fact]
	public void Delete_ValidPerson_ReturnsJsonResult()
	{
		var personId = 1;
		var serviceResult = new Result
		{
			IsSuccess = true,
			StatusCode = HttpStatusCode.NoContent
		};
		_mockPersonService.Setup(s => s.Delete(personId)).Returns(serviceResult);

		var result = _rookiesController.Delete(personId);

		var jsonResult = result.Should().BeOfType<JsonResult>().Subject;
		var jsonDeserialized = jsonResult.Value.Should().BeOfType<Result>().Subject;
		jsonDeserialized.Should().NotBeNull();
		jsonDeserialized.IsSuccess.Should().BeTrue();
		jsonDeserialized.StatusCode.Should().Be(HttpStatusCode.NoContent);
	}
}
