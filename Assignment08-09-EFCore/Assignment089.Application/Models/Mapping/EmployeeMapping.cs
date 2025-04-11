using Assignment089.Application.Models.Requests;
using Assignment089.Application.Models.Responses;
using Assignment089.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Application.Models.Mapping;

public static class EmployeeMapping
{
	public static Employee ToEntity(this EmployeeRequest employeeRequest) => new()
	{
		Name = employeeRequest.Name,
		JoinedDate = DateOnly.FromDateTime(employeeRequest.JoinedDate),
		DepartmentId = employeeRequest.DepartmentId,
	};

	public static EmployeeResponse ToResponse(this Employee employee) => new()
	{
		Id = employee.Id,
		Name = employee.Name,
		JoinedDate = employee.JoinedDate,
	};

	public static EmployeeFilterResponse ToFilterResponse(this Employee employee) => new()
	{
		Id = employee.Id,
		Name = employee.Name,
		JoinedDate = employee.JoinedDate,
		Amount = employee.Salary?.Amount??0
	};
}
