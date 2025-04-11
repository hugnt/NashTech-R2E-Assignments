using Assignment089.Application.Models.Requests;
using Assignment089.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment089.API.Controllers
{
	[Route("api/employee")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeService _employeeService;
		public EmployeeController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;

		}

		[HttpGet("employees-with-departments")]
		public async Task<IActionResult> GetAllEmployeeWithDepartment()
		{
			var res = await _employeeService.GetAllEmployeeWithDepartment();
			return Ok(res);
		}

		[HttpGet("employees-with-projects")]
		public async Task<IActionResult> GetAllEmployeeWithProjects()
		{
			var res = await _employeeService.GetAllEmployeeWithProjects();
			return Ok(res);
		}

		[HttpGet("filter")]
		public async Task<IActionResult> FilterEmployee([FromQuery] EmployeeFilterRequest filterRequest)
		{
			var res = await _employeeService.FilterEmployee(filterRequest);
			return Ok(res);
		}


		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var res = await _employeeService.GetAll();
			return Ok(res);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var res = await _employeeService.GetById(id);
			return Ok(res);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] EmployeeRequest newEmployee)
		{
			var res = await _employeeService.Add(newEmployee);
			return Ok(res);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] EmployeeRequest updatedEmployee)
		{
			var res = await _employeeService.Update(id, updatedEmployee);
			return Ok(res);
		}

		[HttpPut("{id}/update-project")]
		public async Task<IActionResult> UpdateProjectList(Guid id, [FromBody] ListProjectRequest projects)
		{
			var res = await _employeeService.UpdateProjectList(id, projects);
			return Ok(res);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var res = await _employeeService.Delete(id);
			return Ok(res);
		}


		[HttpGet("v2/employees-with-departments")]
		public async Task<IActionResult> GetAllEmployeeWithDepartmentRaw()
		{
			var res = await _employeeService.GetAllEmployeeWithDepartmentRawQuery();
			return Ok(res);
		}

		[HttpGet("v2/employees-with-projects")]
		public async Task<IActionResult> GetAllEmployeeWithProjectsRaw()
		{
			var res = await _employeeService.GetAllEmployeeWithProjectsRawQuery();
			return Ok(res);
		}

		[HttpGet("v2/filter")]
		public async Task<IActionResult> FilterEmployeeRaw([FromQuery] EmployeeFilterRequest filterRequest)
		{
			var res = await _employeeService.FilterEmployeeRawQuery(filterRequest);
			return Ok(res);
		}
	}
}
