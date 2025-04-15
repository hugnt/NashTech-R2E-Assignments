using Assignment04_05_MVC.Common;

namespace Assignment04_05_MVC.Tests.Services.PersonServiceTest.TestData;

public class FilterLimitTestData : TheoryData<FilterModel, int>
{
    public FilterLimitTestData()
    {
        Add(
            new FilterModel(){ Limit = 8 }, 
            8
        );
		Add(
			new FilterModel() { Limit = 1 },
			1
		);
		Add(
			new FilterModel() { BirthYearCompare = BirthYearCompare.Greater, BirthYear = 2000, OrderBy = "DateOfBirth", IsReverse = true, Limit = 8},
			3
		);
	}
}
