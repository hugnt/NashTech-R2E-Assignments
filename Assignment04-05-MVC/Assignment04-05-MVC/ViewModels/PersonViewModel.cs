using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Models;

namespace Assignment04_05_MVC.ViewModels;

public class PersonViewModel
{
    public List<Person> ListPerson { get; set; }

	public int PageCount { get; set; }
	public int PageSize { get; set; }
	public int TotalPages { get; set; }
	public int PageNumber { get; set; }


	public Gender? Gender { get; set; }
	public int BirthYear { get; set; } = -1;
	public BirthYearCompare BirthYearCompare { get; set; }


	public string DisplayFields { get; set; } = "*";

	public string GenderParsedData =>  (Gender) switch
	{
		Models.Gender.Male => "0",
		Models.Gender.Female => "1",
		_ => ""
	};

	public string BirthYearCompareParsedData => (BirthYearCompare) switch
	{
		BirthYearCompare.Greater => "0",
		BirthYearCompare.Equal => "1",
		BirthYearCompare.Lower => "2",
		_ => "4",
	};


}
