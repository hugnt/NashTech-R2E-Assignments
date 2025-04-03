using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Application.Dtos;

public class TodoItemResponse
{
	public int Id { get; set; }
	public required string Title { get; set; }
	public bool Status { get; set; }
}
