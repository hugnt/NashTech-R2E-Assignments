using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Repositories;
using Assignment04_05_MVC.Services;
using Assignment04_05_MVC.Tests.Services.PersonServiceTest.ExpectedResultModel;
using Assignment04_05_MVC.Tests.Services.PersonServiceTest.TestData;
using Assignment04_05_MVC.Tests.TestData;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_05_MVC.Tests.Services.PersonServiceTest;

public class GetByFilterTests
{
	private readonly Mock<IPersonRepository> _mockPersonRepository;
	private readonly PersonService _personService;
	public GetByFilterTests()
	{
		_mockPersonRepository = new Mock<IPersonRepository>();
		_personService = new PersonService(_mockPersonRepository.Object, null);
	}

	[Fact]
	public void GetByFilter_NoFilter_ReturnsAllRecords()
	{
		var filter = new FilterModel();
		var data = RepositoryData.ListPersonsTest().AsQueryable();
		_mockPersonRepository.Setup(r => r.GetAllQueryAble()).Returns(data);

		var result = _personService.GetByFilter(filter);

		result.Should().HaveCount(RepositoryData.ListPersonsTest().Count);
	}


	[Theory]
	[ClassData(typeof(FilterGenderTestData))]
	public void GetByFilter_GenderFilter_ReturnsFilteredRecords(FilterModel filterModel, FilterGenderExpectedModel expectedModel)
	{
		var data = RepositoryData.ListPersonsTest().AsQueryable();
		_mockPersonRepository.Setup(r => r.GetAllQueryAble()).Returns(data);

		var result = _personService.GetByFilter(filterModel);

		result.Should().HaveCount(expectedModel.Count);
		result.Should().OnlyContain(p => p.Gender == expectedModel.Gender);
	}

	[Theory]
	[ClassData(typeof(FilterBirthYearGreaterTestData))]
	public void GetByFilter_BirthYearGreater_ReturnsFilteredRecords(FilterModel filterModel, FilterBirthYearExpectedModel expectedModel)
	{
		var data = RepositoryData.ListPersonsTest().AsQueryable();
		_mockPersonRepository.Setup(r => r.GetAllQueryAble()).Returns(data);

		var result = _personService.GetByFilter(filterModel);

		result.Should().HaveCount(expectedModel.Count);
		result.Should().OnlyContain(p => p.DateOfBirth.Year > expectedModel.Year);
	}

	[Theory]
	[ClassData(typeof(FilterBirthYearEqualTestData))]
	public void GetByFilter_BirthYearEqual_ReturnsFilteredRecords(FilterModel filterModel, FilterBirthYearExpectedModel expectedModel)
	{
		var data = RepositoryData.ListPersonsTest().AsQueryable();
		_mockPersonRepository.Setup(r => r.GetAllQueryAble()).Returns(data);

		var result = _personService.GetByFilter(filterModel);

		result.Should().HaveCount(expectedModel.Count);
		result.Should().OnlyContain(p => p.DateOfBirth.Year == expectedModel.Year);
	}

	[Theory]
	[ClassData(typeof(FilterBirthYearLowerTestData))]
	public void GetByFilter_BirthYearLower_ReturnsFilteredRecords(FilterModel filterModel, FilterBirthYearExpectedModel expectedModel)
	{
		var data = RepositoryData.ListPersonsTest().AsQueryable();
		_mockPersonRepository.Setup(r => r.GetAllQueryAble()).Returns(data);

		var result = _personService.GetByFilter(filterModel);

		result.Should().HaveCount(expectedModel.Count);
		result.Should().OnlyContain(p => p.DateOfBirth.Year < expectedModel.Year);
	}

	[Theory]
	[ClassData(typeof(FilterOrderByAscTestData))]
	public void GetByFilter_OrderByAsc_ReturnsSortedRecords(FilterModel filterModel, List<int> expectedListIds)
	{
		var data = RepositoryData.ListPersonsTest().AsQueryable();
		_mockPersonRepository.Setup(r => r.GetAllQueryAble()).Returns(data);

		var result = _personService.GetByFilter(filterModel);
		result.Select(x => x.Id).Should().HaveCount(expectedListIds.Count).And.ContainInOrder(expectedListIds);
	}

	[Theory]
	[ClassData(typeof(FilterOrderByDescTestData))]
	public void GetByFilter_OrderByDesc_ReturnsSortedRecords(FilterModel filterModel, List<int> expectedListIds)
	{
		var data = RepositoryData.ListPersonsTest().AsQueryable();
		_mockPersonRepository.Setup(r => r.GetAllQueryAble()).Returns(data);

		var result = _personService.GetByFilter(filterModel);
		result.Select(x => x.Id).Should().HaveCount(expectedListIds.Count).And.ContainInOrder(expectedListIds);
	}

	[Theory]
	[ClassData(typeof(FilterLimitTestData))]
	public void GetByFilter_Limit_ReturnsLimitedRecords(FilterModel filterModel, int expectedCount)
	{
		var data = RepositoryData.ListPersonsTest().AsQueryable();
		_mockPersonRepository.Setup(r => r.GetAllQueryAble()).Returns(data);

		var result = _personService.GetByFilter(filterModel);

		result.Should().HaveCount(expectedCount);
	}

	[Theory]
	[ClassData(typeof(FilterCombinedTestData))]
	public void GetByFilter_CombinedFilters_ReturnsCorrectRecords(FilterModel filterModel, List<int> expectedListIds)
	{
		var data = RepositoryData.ListPersonsTest().AsQueryable();
		_mockPersonRepository.Setup(r => r.GetAllQueryAble()).Returns(data);

		var result = _personService.GetByFilter(filterModel);
		result.Select(x => x.Id).Should().HaveCount(expectedListIds.Count).And.ContainInOrder(expectedListIds);
	}

}
