using Assignment089.Application.Models.Requests;
using Assignment089.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment089.API.Controllers
{
	[Route("api/salary")]
	[ApiController]
	public class SalaryController : ControllerBase
	{
		private readonly ISalaryService _salaryService;
		public SalaryController(ISalaryService salaryService)
		{
			_salaryService = salaryService;

		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var res = await _salaryService.GetAll();
			return Ok(res);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var res = await _salaryService.GetById(id);
			return Ok(res);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] SalaryRequest newSalary)
		{
			var res = await _salaryService.Add(newSalary);
			return Ok(res);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] SalaryRequest updatedSalary)
		{
			var res = await _salaryService.Update(id, updatedSalary);
			return Ok(res);
		}

	}
}
