using Assignment089.Application.Models.Requests;
using Assignment089.Application.Models.Responses;
using Assignment089.Application.Shared;
using Assignment089.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Application.Services.Interfaces;

public interface IEmployeeService
{
	public Task<Result<List<EmployeeDepartmentResponse>>> GetAllEmployeeWithDepartment();
	public Task<Result<List<EmployeeProjectsResponse>>> GetAllEmployeeWithProjects();
	public Task<Result<List<EmployeeFilterResponse>>> FilterEmployee(EmployeeFilterRequest filterRequest);
	public Task<Result<List<EmployeeResponse>>> GetAll();
	public Task<Result> GetById(Guid id);
	public Task<Result> Add(EmployeeRequest newEmployee);
	public Task<Result> UpdateProjectList(Guid id, ListProjectRequest projects);
	public Task<Result> Update(Guid id, EmployeeRequest updatedEmployee);
	public Task<Result> Delete(Guid id);

	public Task<Result<List<EmployeeDepartmentResponse>>> GetAllEmployeeWithDepartmentRawQuery();
	public Task<Result<List<EmployeeProjectsResponse>>> GetAllEmployeeWithProjectsRawQuery();
	public Task<Result<List<EmployeeFilterResponse>>> FilterEmployeeRawQuery(EmployeeFilterRequest filterRequest);

}
