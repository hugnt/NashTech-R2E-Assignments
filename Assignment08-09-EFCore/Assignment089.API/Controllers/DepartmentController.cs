using Assignment089.Application.Models.Requests;
using Assignment089.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment089.API.Controllers
{
	[Route("api/department")]
	[ApiController]
	public class DepartmentController : ControllerBase
	{
		private readonly IDepartmentService _departmentService;
		public DepartmentController(IDepartmentService departmentService)
		{
			_departmentService = departmentService;

		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var res = await _departmentService.GetAll();
			return Ok(res);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var res = await _departmentService.GetById(id);
			return Ok(res);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] DepartmentRequest newDepartment)
		{
			var res = await _departmentService.Add(newDepartment);
			return Ok(res);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] DepartmentRequest updatedDepartment)
		{
			var res = await _departmentService.Update(id, updatedDepartment);
			return Ok(res);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var res = await _departmentService.Delete(id);
			return Ok(res);
		}
	}
}
