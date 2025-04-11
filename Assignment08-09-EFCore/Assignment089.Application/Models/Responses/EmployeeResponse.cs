using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Application.Models.Responses;

public class EmployeeResponse
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public DateOnly JoinedDate { get; set; }
}


public class EmployeeDepartmentResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
	public DateOnly JoinedDate { get; set; }
	public string DepartmentName { get; set; }
}

public class EmployeeProjectsResponse
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public DateOnly JoinedDate { get; set; }
	public List<ProjectEmployeeDetailsResponse> Projects { get; set; }
}

public class EmployeeFilterResponse
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public DateOnly JoinedDate { get; set; }
	public decimal Amount { get; set; }
}
