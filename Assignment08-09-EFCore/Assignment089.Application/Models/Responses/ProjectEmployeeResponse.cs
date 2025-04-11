using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Application.Models.Responses;

public class ProjectEmployeeResponse
{
	public Guid ProjectId { get; set; }
	public Guid EmployeeId { get; set; }
	public bool Enable { get; set; }
}


public class ProjectEmployeeDetailsResponse
{
	public string ProjectName { get; set; }
	public bool Enable { get; set; }
}