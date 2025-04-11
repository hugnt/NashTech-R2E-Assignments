using Assignment089.Application.Models.Requests;
using Assignment089.Application.Models.Responses;
using Assignment089.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Application.Services.Interfaces;

public interface IProjectEmployeeService
{
	public Task<Result<List<ProjectEmployeeResponse>>> GetAll();
	public Task<Result> GetById(Guid projectId, Guid employeeId);
	public Task<Result> Add(ProjectEmployeeRequest newProjectEmployee);
	public Task<Result> Update(Guid projectId, Guid employeeId, ProjectEmployeeRequest projectEmployeeRequest);
	public Task<Result> Delete(Guid projectId, Guid employeeId);
}
