using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.Entities;

public class TodoItem
{
    public int Id { get; set; }
	public required string Title { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedAt { get; set; }
	public DateTime UpdatedAt { get; set; }
}
