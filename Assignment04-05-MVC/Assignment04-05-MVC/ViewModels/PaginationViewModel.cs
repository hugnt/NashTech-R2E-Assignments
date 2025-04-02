namespace Assignment04_05_MVC.ViewModels;

public class PaginationViewModel
{
	public int PageCount { get; set; }
	public int PageSize { get; set; }
	public int TotalPages { get; set; }
	public int PageNumber { get; set; }

	public PaginationViewModel(int pageCount, int pageSize, int totalPages, int pageNumber)
	{
		PageCount = pageCount;
		PageSize = pageSize;
		TotalPages = totalPages;
		PageNumber = pageNumber;
	}
}
