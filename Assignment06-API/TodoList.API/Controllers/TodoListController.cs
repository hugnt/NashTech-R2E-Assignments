using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Application.Abstractions;
using TodoList.Application.RequestModel;

namespace TodoList.API.Controllers
{
	[Route("api/todo-list")]
	[ApiController]
	public class TodoListController : ControllerBase
	{
		private readonly ITodoService _todoService;

		public TodoListController(ITodoService todoService)
        {
			_todoService = todoService;

		}

		[HttpPost]
		public IActionResult CreateTask([FromBody] TodoRequest todoRequest)
		{
			return Ok(_todoService.Add(todoRequest));
		}

		[HttpGet]
		public IActionResult GetAllTasks()
		{
			return Ok(_todoService.GetAll());
		}


		[HttpGet("{id}")]
		public IActionResult GetTaskById(int id)
		{
			return Ok(_todoService.GetById(id));
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			return Ok(_todoService.Delete(id));
		}

		[HttpPut("{id}")]
		public IActionResult Edit(int id, [FromBody] TodoRequest updatedTodo)
		{
			return Ok(_todoService.Update(id, updatedTodo));
		}

		[HttpPost("multiple-tasks")]
		public IActionResult AddMultipleTask([FromBody] List<TodoRequest> listnewTodo)
		{
			return Ok(_todoService.AddMany(listnewTodo));
		}

		[HttpDelete("multiple-tasks")]
		public IActionResult DeleteMultipleTask([FromBody] List<int> listDeletedTodo)
		{
			return Ok(_todoService.DeleteMany(listDeletedTodo));
		}
	}
}
