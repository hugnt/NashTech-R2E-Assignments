using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.Abstractions;
using TodoList.Application.Dtos;
using TodoList.Application.RequestModel;
using TodoList.Domain.Entities;

namespace TodoList.Persistence.Repositories
{
	public class TodoRepository : ITodoRepository
	{
		private readonly List<TodoItem> _listTodo = new List<TodoItem>()
		{
			new TodoItem { Id = 1, Title = "Hoàn thành báo cáo", Status = false, CreatedAt = new DateTime(2025, 3, 20), UpdatedAt = new DateTime(2025, 3, 21) },
			new TodoItem { Id = 2, Title = "Mua thực phẩm", Status = true, CreatedAt = new DateTime(2025, 3, 25), UpdatedAt = new DateTime(2025, 3, 26) },
			new TodoItem { Id = 3, Title = "Gọi điện cho khách hàng", Status = false, CreatedAt = new DateTime(2025, 3, 28), UpdatedAt = new DateTime(2025, 3, 28) },
			new TodoItem { Id = 4, Title = "Tập gym", Status = true, CreatedAt = new DateTime(2025, 4, 1), UpdatedAt = new DateTime(2025, 4, 2) },
			new TodoItem { Id = 5, Title = "Học C#", Status = false, CreatedAt = new DateTime(2025, 3, 15), UpdatedAt = new DateTime(2025, 3, 16) },
			new TodoItem { Id = 6, Title = "Viết blog", Status = true, CreatedAt = new DateTime(2025, 3, 30), UpdatedAt = new DateTime(2025, 4, 1) },
			new TodoItem { Id = 7, Title = "Sửa lỗi phần mềm", Status = false, CreatedAt = new DateTime(2025, 4, 2), UpdatedAt = new DateTime(2025, 4, 2) },
			new TodoItem { Id = 8, Title = "Gặp nhóm dự án", Status = true, CreatedAt = new DateTime(2025, 3, 27), UpdatedAt = new DateTime(2025, 3, 28) },
			new TodoItem { Id = 9, Title = "Đi khám sức khỏe", Status = false, CreatedAt = new DateTime(2025, 3, 22), UpdatedAt = new DateTime(2025, 3, 23) },
			new TodoItem { Id = 10, Title = "Cập nhật hồ sơ", Status = true, CreatedAt = new DateTime(2025, 3, 29), UpdatedAt = new DateTime(2025, 3, 30) },
			new TodoItem { Id = 11, Title = "Chuẩn bị thuyết trình", Status = false, CreatedAt = new DateTime(2025, 4, 1), UpdatedAt = new DateTime(2025, 4, 1) },
			new TodoItem { Id = 12, Title = "Dọn dẹp nhà cửa", Status = true, CreatedAt = new DateTime(2025, 3, 31), UpdatedAt = new DateTime(2025, 4, 1) },
			new TodoItem { Id = 13, Title = "Kiểm tra email", Status = false, CreatedAt = new DateTime(2025, 3, 26), UpdatedAt = new DateTime(2025, 3, 26) },
			new TodoItem { Id = 14, Title = "Đặt vé máy bay", Status = true, CreatedAt = new DateTime(2025, 3, 24), UpdatedAt = new DateTime(2025, 3, 25) },
			new TodoItem { Id = 15, Title = "Họp với sếp", Status = false, CreatedAt = new DateTime(2025, 4, 3), UpdatedAt = new DateTime(2025, 4, 3) },
			new TodoItem { Id = 16, Title = "Nộp thuế", Status = true, CreatedAt = new DateTime(2025, 3, 18), UpdatedAt = new DateTime(2025, 3, 19) },
			new TodoItem { Id = 17, Title = "Đọc sách", Status = false, CreatedAt = new DateTime(2025, 3, 23), UpdatedAt = new DateTime(2025, 3, 24) },
			new TodoItem { Id = 18, Title = "Tham gia hội thảo", Status = true, CreatedAt = new DateTime(2025, 3, 21), UpdatedAt = new DateTime(2025, 3, 22) },
			new TodoItem { Id = 19, Title = "Kiểm tra hệ thống", Status = false, CreatedAt = new DateTime(2025, 3, 19), UpdatedAt = new DateTime(2025, 3, 20) },
			new TodoItem { Id = 20, Title = "Tưới cây", Status = true, CreatedAt = new DateTime(2025, 4, 2), UpdatedAt = new DateTime(2025, 4, 3) }
		};
		public void Add(TodoItem newTodoItem)
		{
			var newId = _listTodo.Count()==0?1: _listTodo.Max(x => x.Id) + 1;
			newTodoItem.Id = newId;
			_listTodo.Add(newTodoItem);
		}


		public void Delete(TodoItem newTodoItem)
		{
			_listTodo.Remove(newTodoItem);
		}



		public IQueryable<TodoItem> GetAll()
		{
			return _listTodo.AsQueryable();
		}

		public void Update(TodoItem todoItem)
		{
			var index = _listTodo.FindIndex(x => x.Id == todoItem.Id);
			_listTodo[index] = todoItem;
		}

		public void AddMany(List<TodoItem> newTodoItem)
		{
			var newId = _listTodo.Count() == 0 ? 1 : _listTodo.Max(x => x.Id) + 1;
			foreach (var item in newTodoItem)
			{
				item.Id = newId;
				newId++;
			}
			_listTodo.AddRange(newTodoItem);
		}

		public void DeleteMany(List<int> deletedIds)
		{
			_listTodo.RemoveAll(x=>deletedIds.Contains(x.Id));
		}

		//public IEnumerable<TodoItem> Get(Expression<Func<TodoItem, bool>>? filter = null, Func<IQueryable<TodoItem>, IOrderedQueryable<TodoItem>>? order = null, string? search = null, int limit = 10, int offSet = 0)
		//{
		//	var dbSet = _listTodo.AsQueryable();
		//	if (filter != null)
		//	{
		//		dbSet = dbSet.Where(filter);
		//	}

		//	if (search != null)
		//	{
		//		Search(dbSet, search);
		//	}

		//	if (order != null)
		//	{
		//		dbSet = order(dbSet);
		//	}

		//	dbSet = dbSet.Skip(offSet).Take(limit);
		//	return dbSet.ToList();
		//}

		//public void Search(IQueryable<TodoItem> query, string search)
		//{
		//	query = query.Where(c => c.Title.Contains(search));
		//}
	}
}
