using Assignment04_05_MVC.Common.Helper;
using Assignment04_05_MVC.Controllers;
using Assignment04_05_MVC.Services;
using Assignment04_05_MVC.Tests.TestData;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_05_MVC.Tests.Controllers.RookiesControllerTests;

public class ExportToExcelTests
{

	private readonly Mock<IPersonService> _mockPersonService;
	private readonly RookiesController _rookiesController;
	public ExportToExcelTests()
	{
		_mockPersonService = new Mock<IPersonService>();
		_rookiesController = new RookiesController(_mockPersonService.Object);
	}

	[Fact]
	public void ExportToExcel_ValidInput_ReturnsFileResult()
	{
		var displayFields = "*";
		var persons = RepositoryData.ListPersonsTest();

		var result = _rookiesController.ExportToExcel(displayFields, persons);

		var fileResult = result.Should().BeOfType<FileContentResult>().Subject;
		fileResult.ContentType.Should().Be("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
	}



}
