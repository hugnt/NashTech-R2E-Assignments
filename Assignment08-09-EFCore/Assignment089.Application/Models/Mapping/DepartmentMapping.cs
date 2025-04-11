using Assignment089.Application.Models.Requests;
using Assignment089.Application.Models.Responses;
using Assignment089.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Application.Models.Mapping;

public static class DepartmentMapping
{
	public static Department ToEntity(this DepartmentRequest departmentRequest) => new()
	{
		Name = departmentRequest.Name,
	};

	public static DepartmentResponse ToResponse(this Department department) => new()
	{
		Id = department.Id,
		Name = department.Name,
	};
}
