using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Application.Models.Responses;

public class SalaryResponse
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
	public decimal Amount { get; set; }
}
