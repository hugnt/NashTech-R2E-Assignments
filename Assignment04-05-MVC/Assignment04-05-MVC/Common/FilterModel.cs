using Assignment04_05_MVC.Models;

namespace Assignment04_05_MVC.Common;

public enum BirthYearCompare
{
    Greater,
    Equal,
    Lower,
    None
}
public class FilterModel
{
    public Gender? Gender { get; set; }

    public int PageSize { get; set; }
    public int PageNumber { get; set; }

    public int Limit { get; set; } = -1;
    public string OrderBy { get; set; } = "";
    public bool IsReverse { get; set; }

    public string DisplayFields { get; set; } = "*";

    public int BirthYear { get; set; } = -1;
    public BirthYearCompare BirthYearCompare { get; set; } = BirthYearCompare.None;
}
