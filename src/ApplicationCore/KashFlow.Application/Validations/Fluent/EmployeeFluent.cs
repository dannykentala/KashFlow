using FluentValidation;
using KashFlow.Domain.DTOs.Setters;

namespace KashFlow.Application.Validations.Fluent;

public class EmployeeFluent: AbstractValidator<EmployeeCreateDTO>
{
  public EmployeeFluent ()
  {
    RuleFor(x => x.Email)
      .NotEmpty()
      .EmailAddress();

    RuleFor(x => x.Password)
      .NotEmpty()
      .MinimumLength(8).WithMessage("Password must be greater than 8 characters");
  }
}