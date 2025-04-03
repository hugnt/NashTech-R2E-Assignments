using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.Dtos;
using TodoList.Application.RequestModel;
using TodoList.Application.Response;

namespace TodoList.Application.Abstractions;

public interface ITodoService
{
	public Result<List<TodoItemResponse>> GetAll();

	public Result<TodoItemResponse> GetById(int id);
	public Result<bool> Add(TodoRequest newTodoItem);
	public Result<bool> Update(int id, TodoRequest newTodoItem);
	public Result<bool> Delete(int id);

	public Result<bool> AddMany(List<TodoRequest> newListTodoItem);
	public Result<bool> DeleteMany(List<int> listDeletedIds);

}
