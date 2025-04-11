using Assignment089.Application.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Application.Validators;

public class DepartmentRequestValidator : AbstractValidator<DepartmentRequest>
{
	public DepartmentRequestValidator()
	{
		RuleFor(x => x.Name)
			.NotNull().WithMessage("Name can not be null")
			.NotEmpty().WithMessage("Name can not be empty")
			.Matches(@"^[^0-9]*$").WithMessage("Name cannot contain numbers");
	}
}
