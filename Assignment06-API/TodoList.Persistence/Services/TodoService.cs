using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.Abstractions;
using TodoList.Application.Common;
using TodoList.Application.Dtos;
using TodoList.Application.RequestModel;
using TodoList.Application.Response;
using TodoList.Domain.Entities;

namespace TodoList.Persistence.Services;

public class TodoService : ITodoService
{
	private readonly ITodoRepository _todoRepository;

	public TodoService(ITodoRepository todoRepository)
    {
		_todoRepository = todoRepository;
	}

	public Result<List<TodoItemResponse>> GetAll()
	{
		var listTodoItems = _todoRepository.GetAll().Select(x=>new TodoItemResponse()
		{
			Id = x.Id,
			Title = x.Title,
			Status = x.Status
		});
		return Result<List<TodoItemResponse>>.SuccessWithBody(listTodoItems.ToList());
	}

	public Result<TodoItemResponse> GetById(int id)
	{
		var selectedEntity = _todoRepository.GetAll().FirstOrDefault(x => x.Id == id);
		if (selectedEntity == null) return Result<TodoItemResponse>.Error($"Todo with id={id} is not found", HttpStatusCode.NotFound);	
		var todoItem = new TodoItemResponse()
		{
			Id = selectedEntity.Id,
			Title = selectedEntity.Title,
			Status = selectedEntity.Status,
		};
		return Result<TodoItemResponse>.SuccessWithBody(todoItem);
	}

	public Result<bool> Add(TodoRequest newTodoItem)
	{
		var validateModel = IsValidTodo(new List<TodoRequest>() { newTodoItem });
		if (!validateModel.IsValid)
		{
			return Result<bool>.Error(validateModel.Message, HttpStatusCode.NotFound);
		}
		var todoEntity = new TodoItem()
		{
			Title = newTodoItem.Title,
			Status = newTodoItem.Status,
			CreatedAt = DateTime.Now,
			UpdatedAt = DateTime.Now
		};
		_todoRepository.Add(todoEntity);

		return Result<bool>.Success("Created Successfully!", HttpStatusCode.Created);

	}


	public Result<bool> Update(int id, TodoRequest todoItem)
	{
		var selectedEntity = _todoRepository.GetAll().FirstOrDefault(x => x.Id == id);
		if(selectedEntity == null) return Result<bool>.Error($"Todo with id={id} is not found", HttpStatusCode.NotFound);
		var validateModel = IsValidTodo(new List<TodoRequest>() { todoItem});
		if (!validateModel.IsValid)
		{
			return Result<bool>.Error(validateModel.Message, HttpStatusCode.NotFound);
		}
		selectedEntity.Title = todoItem.Title;
		selectedEntity.Status = todoItem.Status;
		_todoRepository.Update(selectedEntity);
		return Result<bool>.SuccessWithMesage("Updated successfully!");
	}


	
	public Result<bool> Delete(int id)
	{
		var selectedEntity = _todoRepository.GetAll().FirstOrDefault(x => x.Id == id);
		if (selectedEntity == null) return Result<bool>.Error($"Todo with id={id} is not found", HttpStatusCode.NotFound);
		_todoRepository.Delete(selectedEntity);
		return Result<bool>.SuccessWithMesage("Deleted successfully!");
	}

	public Result<bool> AddMany(List<TodoRequest> newListTodoItem)
	{
		if (newListTodoItem.Count() == 0) return Result<bool>.Error("The list of todo must not be empty!", HttpStatusCode.BadRequest);
		var validateModel = IsValidTodo(newListTodoItem);
		if (!validateModel.IsValid)
		{
			return Result<bool>.Error(validateModel.Message, HttpStatusCode.NotFound);
		}
		var newListTodoEntity = newListTodoItem.Select(x=> new TodoItem()
		{
			Title = x.Title,
			Status = x.Status,
			CreatedAt = DateTime.Now,
			UpdatedAt = DateTime.Now
		}).ToList();
		_todoRepository.AddMany(newListTodoEntity);
		return Result<bool>.Success("Created Successfully!", HttpStatusCode.Created);

	}
	public Result<bool> DeleteMany(List<int> listDeletedIds)
	{
		if (listDeletedIds.Count() == 0) return Result<bool>.Error("The list of id must not be empty!", HttpStatusCode.BadRequest);
		var validateModel = IsExisted(listDeletedIds);
		if (!validateModel.IsValid)
		{
			return Result<bool>.Error(validateModel.Message, HttpStatusCode.NotFound);
		}
		_todoRepository.DeleteMany(listDeletedIds);
		return Result<bool>.SuccessWithMesage("Deleted successfully!");
	}

	private ValidateModel IsExisted(List<int> listIds)
	{
		
		var allEntityIds = _todoRepository.GetAll().Select(x => x.Id).ToList();
		//var unexpectedId = listIds.FirstOrDefault(x=> !allEntityIds.Contains(x));
		foreach (var id in listIds)
		{
			if (!allEntityIds.Contains(id))
			{
				 return ValidateModel.InValid($"The todo with id={id} does not exist!");
			}
		}
		return ValidateModel.Valid();

	}

	private ValidateModel IsValidTodo(List<TodoRequest> listTodos)
	{
		var anyEmtyTitle = listTodos.Any(x => x.Title.Trim() == "");
		if (anyEmtyTitle) return ValidateModel.InValid($"The title must be not empty, please check!");
		else return ValidateModel.Valid();

	}





}
