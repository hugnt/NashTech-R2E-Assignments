using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Common.Enums;
using Assignment04_05_MVC.Controllers;
using Assignment04_05_MVC.Models;
using Assignment04_05_MVC.Services;
using Assignment04_05_MVC.Tests.Controllers.RookiesControllerTests.TestData;
using Assignment04_05_MVC.ViewModels;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_05_MVC.Tests.Controllers.RookiesControllerTests;

public class DetailsTests
{
	private readonly Mock<IPersonService> _mockPersonService;
	private readonly RookiesController _rookiesController;
	public DetailsTests()
	{
		_mockPersonService = new Mock<IPersonService>();
		_rookiesController = new RookiesController(_mockPersonService.Object);
	}

	[Theory]
	[ClassData(typeof(DetailsTestData))]
	public void Details_FormRequestWithModeDetailOrUpdate_ReturnViewWithViewModel(FormRequestModel formRequest, Result<Person> mockData, PersonDetailsViewModel expectedResult)
	{
		_mockPersonService.Setup(x => x.GetById(formRequest.Id)).Returns(mockData);

		var result = _rookiesController.Details(formRequest);

		var viewResult = result.Should().BeOfType<ViewResult>().Subject;
		var viewModel = viewResult.Model.Should().BeOfType<PersonDetailsViewModel>().Subject;

		viewModel.FormMode.Should().Be(expectedResult.FormMode);
		viewModel.RouteAction.Should().Be(expectedResult.RouteAction);
		viewModel.Method.Should().Be(expectedResult.Method);
		viewModel.Person.Should().Be(expectedResult.Person);
	}

	[Fact]
	public void Details_FormRequestWithModeAdd_ReturnViewWithViewModel()
	{
		var formRequest = new FormRequestModel()
		{
			FormMode = FormMode.Add
		};

		var result = _rookiesController.Details(formRequest);

		var viewResult = result.Should().BeOfType<ViewResult>().Subject;
		var viewModel = viewResult.Model.Should().BeOfType<PersonDetailsViewModel>().Subject;

		viewModel.FormMode.Should().Be(FormMode.Add);
		viewModel.RouteAction.Should().Be("/Rookies/AddNew");
		viewModel.Method.Should().Be("POST");
		viewModel.Title.Should().Be("Add new rookies");
		viewModel.Person.DateOfBirth.Should().BeSameDateAs(new DateTime(2000, 1, 1));
	}
}
