using Assignment089.Application.Models.Requests;
using Assignment089.Application.Models.Responses;
using Assignment089.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Application.Models.Mapping;

public static class SalaryMapping
{
	public static Salary ToEntity(this SalaryRequest salaryRequest) => new()
	{
		EmployeeId = salaryRequest.EmployeeId,
		Amount = salaryRequest.Amount,
	};

	public static SalaryResponse ToResponse(this Salary salary) => new()
	{
		Id = salary.Id,
		EmployeeId = salary.EmployeeId,
		Amount = salary.Amount,
	};
}
