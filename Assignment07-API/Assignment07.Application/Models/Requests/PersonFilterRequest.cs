using Assignment07.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment07.Application.Models.Requests;

public class PersonFilterRequest
{
	public string Name { get; set; } = "";
	public Gender? Gender { get; set; }
	public string BirthPlace { get; set; } = "";

}
