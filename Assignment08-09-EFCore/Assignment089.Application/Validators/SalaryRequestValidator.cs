using Assignment089.Application.Models.Requests;
using FluentValidation;

namespace Assignment089.Application.Validators;

public class SalaryRequestValidator : AbstractValidator<SalaryRequest>
{
	public SalaryRequestValidator()
	{
		RuleFor(x => x.Amount)
			.NotNull().WithMessage("Amount of Salary can not be null")
			.GreaterThan(0).WithMessage("Amount of Salary must be grater than 0");
	}
}
