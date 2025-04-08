using Assignment07.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment07.Application.Models.Requests;

public class PersonRequest
{
	public string FirstName { get; set; } = "";
	public string LastName { get; set; } = "";
	public DateTime DateOfBirth { get; set; }
	public Gender Gender { get; set; }
	public string BirthPlace { get; set; } = "";
}
