using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Application.RequestModel;

public class TodoRequest
{
	public required string Title { get; set; }
	public bool Status { get; set; }
}
