using Assignment04_05_MVC.Models;
using FluentValidation;

namespace Assignment04_05_MVC.Validators;

public class PersonValidator : AbstractValidator<Person>
{
	public PersonValidator()
	{
		RuleFor(x => x.FirstName)
			.NotNull().WithMessage("First name cannot be null")
			.NotEmpty().WithMessage("First name cannot be empty")
			.Length(2, 50).WithMessage("First name must be between 2 and 50 characters")
			.Matches(@"^[a-zA-Z\s]+$").WithMessage("First name can only contain letters and spaces");

		RuleFor(x => x.LastName)
			.NotNull().WithMessage("Last name cannot be null")
			.NotEmpty().WithMessage("Last name cannot be empty")
			.Length(2, 50).WithMessage("Last name must be between 2 and 50 characters")
			.Matches(@"^[a-zA-Z\s]+$").WithMessage("Last name can only contain letters and spaces");

		RuleFor(x => x.Gender)
			.IsInEnum().WithMessage("Gender must be a valid value (Male or Female)");

		RuleFor(x => x.DateOfBirth)
			.NotEmpty().WithMessage("Date of birth cannot be empty")
			.Must(date => date.Year >= 1900 && date <= DateTime.Now)
			.WithMessage("Date of birth must be between 1900 and today");

		RuleFor(x => x.PhoneNumber)
			.NotNull().WithMessage("Phone number cannot be null")
			.NotEmpty().WithMessage("Phone number cannot be empty")
			.Matches(@"^\d{10}$").WithMessage("Phone number must be exactly 10 digits");

		RuleFor(x => x.BirthPlace)
			.NotNull().WithMessage("Birth place cannot be null")
			.NotEmpty().WithMessage("Birth place cannot be empty")
			.Length(2, 100).WithMessage("Birth place must be between 2 and 100 characters")
			.Matches(@"^[a-zA-Z\s]+$").WithMessage("Birth place can only contain letters and spaces");
	}
}

