using Assignment07.Application.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment07.Application.Validators;

public class PersonRequestValidator : AbstractValidator<PersonRequest>
{
	public PersonRequestValidator()
	{
		RuleFor(x=>x.FirstName)
			.NotNull().WithMessage("FirstName can not be null")
			.NotEmpty().WithMessage("FirstName can not be empty")
			.Matches(@"^[^0-9]*$").WithMessage("FirstName cannot contain numbers");
		RuleFor(x => x.LastName)
			.NotNull().WithMessage("LastName can not be null")
			.NotEmpty().WithMessage("LastName can not be empty")
			.Matches(@"^[^0-9]*$").WithMessage("LastName cannot contain numbers"); ;
		RuleFor(x => x.Gender)
			  .NotNull().WithMessage("Gender can not be null")
			  .IsInEnum().WithMessage("Gender is not existed");
	}
}
