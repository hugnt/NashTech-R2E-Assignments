﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Domain.Models;

public class EmployeeProjectQueryResult
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public DateOnly JoinedDate { get; set; }
	public string? ProjectName { get; set; }
	public bool? Enable { get; set; }
}
