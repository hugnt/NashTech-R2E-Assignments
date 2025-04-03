using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Application.Common;

public class ValidateModel
{
    public bool IsValid { get; set; }
	public string Message { get; set; } = "";

	public static ValidateModel Valid()=> new ValidateModel() { IsValid=true, Message="Valid"};
	public static ValidateModel InValid(string messsage) => new ValidateModel() { IsValid = false, Message = messsage };
}
