using Assignment089.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Domain.Entities;

public class ProjectEmployee
{
    public Guid ProjectId { get; set; }
	public Project Project { get; set; }

	public Guid EmployeeId { get; set; }
	public Employee Employee { get; set; }

	public bool Enable { get; set; }
}
