using Assignment089.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Domain.Entities;

public class Department : Entity, IAuditableEntity
{
    public string Name { get; set; }
	public ICollection<Employee> Employees { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime UpdatedAt { get; set; }
}
