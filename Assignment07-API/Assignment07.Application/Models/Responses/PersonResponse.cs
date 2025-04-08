using Assignment07.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment07.Application.Models.Responses;

public class PersonResponse
{
	public Guid Id { get; set; }
	public string FirstName { get; set; } = "";
	public string LastName { get; set; } = "";
	public DateTime DateOfBirth { get; set; }
	public Gender Gender { get; set; }
	public string BirthPlace { get; set; } = "";
}
