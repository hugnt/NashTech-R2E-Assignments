using Assignment089.Application.Models.Requests;
using Assignment089.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment089.API.Controllers
{
	[Route("api/project-employee")]
	[ApiController]
	public class ProjectEmployeeController : ControllerBase
	{
		private readonly IProjectEmployeeService _projectEmployeeService;
		public ProjectEmployeeController(IProjectEmployeeService projectEmployeeService)
		{
			_projectEmployeeService = projectEmployeeService;

		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var res = await _projectEmployeeService.GetAll();
			return Ok(res);
		}

		[HttpGet("{projectId}/{employeeId}")]
		public async Task<IActionResult> GetById(Guid projectId, Guid employeeId)
		{
			var res = await _projectEmployeeService.GetById(projectId, employeeId);
			return Ok(res);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] ProjectEmployeeRequest newProjectEmployee)
		{
			var res = await _projectEmployeeService.Add(newProjectEmployee);
			return Ok(res);
		}

		[HttpPut("{projectId}/{employeeId}")]
		public async Task<IActionResult> Update(Guid projectId, Guid employeeId, [FromBody] ProjectEmployeeRequest updatedProjectEmployee)
		{
			var res = await _projectEmployeeService.Update(projectId, employeeId, updatedProjectEmployee);
			return Ok(res);
		}

		[HttpDelete("{projectId}/{employeeId}")]
		public async Task<IActionResult> Delete(Guid projectId, Guid employeeId)
		{
			var res = await _projectEmployeeService.Delete(projectId, employeeId);
			return Ok(res);
		}
	}
}
