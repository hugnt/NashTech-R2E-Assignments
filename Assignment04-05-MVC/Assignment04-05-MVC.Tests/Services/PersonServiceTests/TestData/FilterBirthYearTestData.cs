using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Models;
using Assignment04_05_MVC.Tests.Services.PersonServiceTest.ExpectedResultModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_05_MVC.Tests.Services.PersonServiceTest.TestData;

public class FilterBirthYearGreaterTestData : TheoryData<FilterModel, FilterBirthYearExpectedModel>
{
    public FilterBirthYearGreaterTestData()
    {
        Add(
            new FilterModel(){ BirthYearCompare = BirthYearCompare.Greater, BirthYear = 2000 }, 
            new FilterBirthYearExpectedModel() {Year = 2000, Count = 3}
        );
		Add(
			new FilterModel() { BirthYearCompare = BirthYearCompare.Greater, BirthYear = 1980 },
			new FilterBirthYearExpectedModel() { Year = 1980, Count = 9 }
		);

        Add(
            new FilterModel(){ BirthYearCompare = BirthYearCompare.Greater, BirthYear = 2000, Gender = Gender.Male}, 
            new FilterBirthYearExpectedModel() {Year = 2000, Count = 0}
        );
		Add(
			new FilterModel() { BirthYearCompare = BirthYearCompare.Greater, BirthYear = 2000, Gender = Gender.Female },
			new FilterBirthYearExpectedModel() { Year = 2000, Count = 3 }
		);
	}
}


public class FilterBirthYearEqualTestData : TheoryData<FilterModel, FilterBirthYearExpectedModel>
{
	public FilterBirthYearEqualTestData()
	{
		Add(
			new FilterModel() { BirthYearCompare = BirthYearCompare.Equal, BirthYear = 2000 },
			new FilterBirthYearExpectedModel() { Year = 2000, Count = 0 }
		);
		Add(
			new FilterModel() { BirthYearCompare = BirthYearCompare.Equal, BirthYear = 2003 },
			new FilterBirthYearExpectedModel() { Year = 2003, Count = 2 }
		);

		Add(
			new FilterModel() { BirthYearCompare = BirthYearCompare.Equal, BirthYear = 2000, Gender = Gender.Male },
			new FilterBirthYearExpectedModel() { Year = 2000, Count = 0 }
		);
		Add(
			new FilterModel() { BirthYearCompare = BirthYearCompare.Equal, BirthYear = 2003, Gender = Gender.Female },
			new FilterBirthYearExpectedModel() { Year = 2003, Count = 2 }
		);
	}
}
public class FilterBirthYearLowerTestData : TheoryData<FilterModel, FilterBirthYearExpectedModel>
{
	public FilterBirthYearLowerTestData()
	{
		Add(
			new FilterModel() { BirthYearCompare = BirthYearCompare.Lower, BirthYear = 2000 },
			new FilterBirthYearExpectedModel() { Year = 2000, Count = 7 }
		);
		Add(
			new FilterModel() { BirthYearCompare = BirthYearCompare.Lower, BirthYear = 2003 },
			new FilterBirthYearExpectedModel() { Year = 2003, Count = 8 }
		);
		Add(
			new FilterModel() { BirthYearCompare = BirthYearCompare.Lower, BirthYear = 2000, Gender = Gender.Male },
			new FilterBirthYearExpectedModel() { Year = 2000, Count = 5 }
		);
		Add(
			new FilterModel() { BirthYearCompare = BirthYearCompare.Lower, BirthYear = 2003, Gender = Gender.Female },
			new FilterBirthYearExpectedModel() { Year = 2003, Count = 3 }
		);
	}
}


