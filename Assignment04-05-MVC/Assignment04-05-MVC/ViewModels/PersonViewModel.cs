using Assignment04_05_MVC.Helper;
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
}
