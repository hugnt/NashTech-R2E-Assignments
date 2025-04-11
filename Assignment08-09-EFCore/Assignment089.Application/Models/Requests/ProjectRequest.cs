using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Application.Models.Requests;

public class ProjectRequest
{
	public string Name { get; set; }
	public List<Guid> EmployeeIds { get; set; } = [];
}
