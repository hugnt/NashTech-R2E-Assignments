using Assignment089.Application.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Application.Validators;

public class EmployeeRequestValidator : AbstractValidator<EmployeeRequest>
{
	public EmployeeRequestValidator()
	{
		RuleFor(x => x.Name)
			.NotNull().WithMessage("Name can not be null")
			.NotEmpty().WithMessage("Name can not be empty")
			.Matches(@"^[^0-9]*$").WithMessage("Name cannot contain numbers");

		RuleFor(x => x.JoinedDate.Year)
			.NotNull().WithMessage("Joined date can not be null")
			.GreaterThan(1990).WithMessage("Joined date must be greater than 1990");
	}
}
