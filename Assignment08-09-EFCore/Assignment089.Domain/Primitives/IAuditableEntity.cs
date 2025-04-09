using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Domain.Primitives;

public interface IAuditableEntity
{
	public DateTime CreatedAt { get; set; }
	public DateTime UpdatedAt { get; set; }
}
