using Assignment089.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Domain.Entities;

public class Employee : Entity, IAuditableEntity
{
    public string Name { get; set; }
    public Guid DepartmentId { get; set; }
	public Department Department { get; set; }
	
    public Salary Salary { get; set; }
	public ICollection<ProjectEmployee> ProjectEmployees { get; set; }

	public DateOnly JoinedDate { get; set; }
    public DateTime CreatedAt { get; set; }
	public DateTime UpdatedAt { get; set; }
}
