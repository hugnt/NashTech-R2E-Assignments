using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_05_MVC.Tests.TestData;

public class ServiceData
{
	public static IEnumerable<FilterModel> GetFilterDataGenderNull()
	{
		yield return new FilterModel {Gender = null, BirthYearCompare = BirthYearCompare.Lower };
		yield return new FilterModel {};
	}
}
