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

public class FilterGenderTestData : TheoryData<FilterModel, FilterGenderExpectedModel>
{
    public FilterGenderTestData()
    {
        Add(
            new FilterModel(){ Gender = Gender.Male }, 
            new FilterGenderExpectedModel() {Gender = Gender.Male, Count = 5}
        );
		Add(
			new FilterModel() { Gender = Gender.Female },
			new FilterGenderExpectedModel() { Gender = Gender.Female, Count = 5 }
		);
	}
}
