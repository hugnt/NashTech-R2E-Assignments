using Assignment089.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Domain.Entities;

public class Salary : Entity, IAuditableEntity
{
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public DateTime UpdatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
