using Assignment089.Application.Models.Requests;
using Assignment089.Application.Models.Responses;
using Assignment089.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Application.Models.Mapping;

public static class ProjectMapping
{
	public static Project ToEntity(this ProjectRequest projectRequest) => new()
	{
		Name = projectRequest.Name,
	};

	public static ProjectResponse ToResponse(this Project project) => new()
	{
		Id = project.Id,
		Name = project.Name
	};
}
