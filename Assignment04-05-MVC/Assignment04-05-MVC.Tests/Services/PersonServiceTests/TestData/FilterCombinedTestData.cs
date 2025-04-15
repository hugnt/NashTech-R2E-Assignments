using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_05_MVC.Tests.Services.PersonServiceTest.TestData;

public class FilterCombinedTestData : TheoryData<FilterModel, List<int>>
{
    public FilterCombinedTestData()
    {
		Add(
			new FilterModel()
			{
				Gender = Gender.Male,
				BirthYearCompare = BirthYearCompare.Greater,
				BirthYear = 1990,
				OrderBy = "DateOfBirth",
				IsReverse = true,
				Limit = 3
			},
			new List<int>() { 9, 7 }
		);
		Add(
			new FilterModel()
			{
				Gender = Gender.Female,
				BirthYearCompare = BirthYearCompare.Lower,
				BirthYear = 1995,
				OrderBy = "DateOfBirth",
				IsReverse = false,
				Limit = 2
			},
			new List<int>() { 2 }
		);
		Add(
			new FilterModel()
			{
				Gender = Gender.Male,
				BirthYearCompare = BirthYearCompare.Greater,
				BirthYear = 1980,
				OrderBy = "DateOfBirth",
				IsReverse = true,
				Limit = 4
			},
			new List<int>() { 9, 7, 1, 5 }
		);
		Add(
			new FilterModel()
			{
				Gender = Gender.Female,
				BirthYearCompare = BirthYearCompare.Greater,
				BirthYear = 2000,
				OrderBy = "DateOfBirth",
				IsReverse = false,
				Limit = 3
			},
			new List<int>() { 6, 8, 10 }
		);
		Add(
			new FilterModel()
			{
				Gender = Gender.Male,
				BirthYearCompare = BirthYearCompare.Lower,
				BirthYear = 1990,
				OrderBy = "DateOfBirth",
				IsReverse = false,
				Limit = 2
			},
			new List<int>() { 3, 5 }
		);
	}
}

