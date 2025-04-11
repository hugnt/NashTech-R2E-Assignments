using Assignment089.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Application.Models.Requests;

public class EmployeeRequest
{
    public string Name { get; set; }
	public DateTime JoinedDate { get; set; }
	public Guid DepartmentId { get; set; }
}

public class ListProjectRequest
{
    public List<ProjectDetailsRequest> Projects { get; set; }
}
public class ProjectDetailsRequest
{
    public Guid ProjectId { get; set; }
    public bool Enable { get; set; }
}