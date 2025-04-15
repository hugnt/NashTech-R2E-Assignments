using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Controllers;
using Assignment04_05_MVC.Models;
using Assignment04_05_MVC.Repositories;
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

public class IndexTests
{
	private readonly Mock<IPersonService> _mockPersonService;
	private readonly RookiesController _rookiesController;
	public IndexTests()
	{
		_mockPersonService = new Mock<IPersonService>();
		_rookiesController = new RookiesController(_mockPersonService.Object);
	}

	[Theory]
	[ClassData(typeof(IndexTestData))]
	public void Index_Filter_ReturnViewWithViewModel(FilterModel filter, List<Person> mockData, PersonViewModel expectedResult)
	{
		_mockPersonService.Setup(x => x.GetByFilter(filter)).Returns(mockData);

		var result = _rookiesController.Index(filter);

		var viewResult = result.Should().BeOfType<ViewResult>().Subject;
		var viewModel = viewResult.Model.Should().BeOfType<PersonViewModel>().Subject;

		viewModel.ListPerson.Should().HaveCount(expectedResult.ListPerson.Count);
		viewModel.PageSize.Should().Be(expectedResult.PageSize);
		viewModel.PageNumber.Should().Be(expectedResult.PageNumber);

	}
}
