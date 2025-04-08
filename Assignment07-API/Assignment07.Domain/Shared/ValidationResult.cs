using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment07.Domain.Shared;

public class ValidationResult
{
    public bool IsValid { get; set; }
	public string Message { get; set; } = "";
}
