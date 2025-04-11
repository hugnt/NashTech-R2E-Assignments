using Assignment089.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Domain.Models;

public class EmployeeProjectKey
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public DateOnly JoinedDate { get; set; }
}

public class EmployeeProjectElement
{
	public Project? Project { get; set; }
	public ProjectEmployee? ProjectEmployee { get; set; }
}
