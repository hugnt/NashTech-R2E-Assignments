using Assignment089.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Domain.Entities;

public class Project : Entity, IAuditableEntity
{
    public string Name { get; set; }
	public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime UpdatedAt { get; set; }
}
