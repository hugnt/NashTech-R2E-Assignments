using Assignment089.Application.Models.Requests;
using Assignment089.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment089.API.Controllers
{
	[Route("api/project")]
	[ApiController]
	public class ProjectController : ControllerBase
	{
		private readonly IProjectService _projectService;
		public ProjectController(IProjectService projectService)
		{
			_projectService = projectService;

		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var res = await _projectService.GetAll();
			return Ok(res);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var res = await _projectService.GetById(id);
			return Ok(res);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] ProjectRequest newProject)
		{
			var res = await _projectService.Add(newProject);
			return Ok(res);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] ProjectRequest updatedProject)
		{
			var res = await _projectService.Update(id, updatedProject);
			return Ok(res);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var res = await _projectService.Delete(id);
			return Ok(res);
		}
	}
}
