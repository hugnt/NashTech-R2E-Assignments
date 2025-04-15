using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Models;

namespace Assignment04_05_MVC.Tests.Services.PersonServiceTest.TestData;

public class FilterOrderByAscTestData : TheoryData<FilterModel, List<int>>
{
    public FilterOrderByAscTestData()
    {
		Add(
			new FilterModel() { OrderBy = "DateOfBirth" },
			new List<int>() { 3, 5, 1, 2, 7, 4, 9, 6, 8, 10 }
		);
		Add(
			new FilterModel() { OrderBy = "Gender" },
			new List<int>() { 1, 3, 5, 7, 9, 2, 4, 6, 8, 10 }
		);
		Add(
			new FilterModel() { Gender = Gender.Male, BirthYearCompare = BirthYearCompare.Greater, BirthYear = 1990, OrderBy = "DateOfBirth" },
			new List<int>() { 7,9 }
		);
	}
}

public class FilterOrderByDescTestData : TheoryData<FilterModel, List<int>>
{
	public FilterOrderByDescTestData()
	{
		Add(
			new FilterModel() { OrderBy = "DateOfBirth", IsReverse = true },
			new List<int>() { 10, 8, 6, 9, 4, 7, 2, 1, 5, 3 }
		);
		Add(
			new FilterModel() { OrderBy = "Gender", IsReverse = true },
			new List<int>() { 2, 4, 6, 8, 10, 1, 3, 5, 7, 9 }
		);
		Add(
			new FilterModel() { Gender = Gender.Male, BirthYearCompare = BirthYearCompare.Greater, BirthYear = 1990, OrderBy = "DateOfBirth", IsReverse = true },
			new List<int>() { 9, 7 }
		);
	}
}

