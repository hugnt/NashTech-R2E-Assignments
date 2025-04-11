using Assignment089.Application.Models.Requests;
using Assignment089.Application.Models.Responses;
using Assignment089.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Application.Models.Mapping;

public static class ProjectEmployeeMapping
{
	public static ProjectEmployee ToEntity(this ProjectEmployeeRequest projectEmployeeRequest) => new()
	{
		EmployeeId = projectEmployeeRequest.EmployeeId,
		ProjectId = projectEmployeeRequest.ProjectId,
		Enable = projectEmployeeRequest.Enable
	};

	public static ProjectEmployeeResponse ToResponse(this ProjectEmployee projectEmployee) => new()
	{
		EmployeeId = projectEmployee.EmployeeId,
		ProjectId = projectEmployee.ProjectId,
		Enable = projectEmployee.Enable
	};
}
