using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Application.Models.Requests;

public class ProjectEmployeeRequest
{
	public Guid ProjectId { get; set; }
	public Guid EmployeeId { get; set; }
	public bool Enable { get; set; }
}

