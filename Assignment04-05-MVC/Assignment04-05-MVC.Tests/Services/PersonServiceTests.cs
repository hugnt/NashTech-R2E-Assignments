using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Models;
using Assignment04_05_MVC.Repositories;
using Assignment04_05_MVC.Services;
using Assignment04_05_MVC.Tests.ExpectedResultModel;
using Assignment04_05_MVC.Tests.TestData;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_05_MVC.Tests.Services;

public class PersonServiceTests
{
	private readonly Mock<IPersonRepository> _mockPersonRepository;
	private readonly PersonService _personService;
	public PersonServiceTests()
    {
		_mockPersonRepository = new Mock<IPersonRepository>();
		_personService = new PersonService(_mockPersonRepository.Object);
	}


	[Fact]
	public void GetByFilter_NoFilter_ReturnsAllRecords()
	{
		// Arrange
		var filter = new FilterModel();
		var data = RepositoryData.ListPersonsTest().AsQueryable();
		_mockPersonRepository.Setup(r => r.GetAllQueryAble()).Returns(data);

		// Act
		var result = _personService.GetByFilter(filter);

		// Assert
		result.Should().HaveCount(10);
	}


	[Theory]
	[ClassData(typeof(FilterGenderTestData))]
	public void GetByFilter_GenderFilter_ReturnsFilteredRecords(FilterModel filterModel, FilterGenderExpectedModel expectedModel)
	{
		//Arrange
		var data = RepositoryData.ListPersonsTest().AsQueryable();
		_mockPersonRepository.Setup(r => r.GetAllQueryAble()).Returns(data);

		//Act
		var result = _personService.GetByFilter(filterModel);

		//Assert
		result.Should().HaveCount(expectedModel.Count);
		result.Should().OnlyContain(p => p.Gender == expectedModel.Gender);
	}

	[Fact]
	public void GetByFilter_BirthYearGreater_ReturnsFilteredRecords()
	{
		
	}

	[Fact]
	public void GetByFilter_BirthYearEqual_ReturnsFilteredRecords()
	{
		
	}

	[Fact]
	public void GetByFilter_BirthYearLower_ReturnsFilteredRecords()
	{

	}

	[Fact]
	public void GetByFilter_OrderByNameAsc_ReturnsSortedRecords()
	{

	}

	[Fact]
	public void GetByFilter_OrderByNameDesc_ReturnsSortedRecords()
	{

	}

	[Fact]
	public void GetByFilter_Limit_ReturnsLimitedRecords()
	{
		
	}

	[Fact]
	public void GetByFilter_CombinedFilters_ReturnsCorrectRecords()
	{
		
	}
}
