using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.Dtos;
using TodoList.Application.RequestModel;
using TodoList.Domain.Entities;

namespace TodoList.Application.Abstractions;

public interface ITodoRepository
{
	//public IEnumerable<TodoItem> Get(Expression<Func<TodoItem, bool>>? filter = null,
	//									Func<IQueryable<TodoItem>, IOrderedQueryable<TodoItem>>? order = null,
	//									string? search = null,
	//									int limit = 10,
	//									int offSet = 0
	//									);
	//public abstract void Search(IQueryable<TodoItem> query, string search);

	public IQueryable<TodoItem> GetAll();
	public void Add(TodoItem newTodoItem);
	public void Update(TodoItem todoItem);
	public void Delete(TodoItem todoItem);

	public void AddMany(List<TodoItem> newTodoItem);
	public void DeleteMany(List<int> deletedIds);
}
