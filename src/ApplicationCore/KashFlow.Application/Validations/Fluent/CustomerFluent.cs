using FluentValidation;
using KashFlow.Domain.DTOs.Setters;

namespace KashFlow.Application.Validations.Fluent;

public class CustomerFluent: AbstractValidator<CustomerCreateDTO>
{
  public CustomerFluent ()
  {
    RuleFor(x => x.Name)
      .NotEmpty();

    RuleFor(x => x.Document)
      .NotEmpty();

    RuleFor(x => x.Phone)
      .NotEmpty();

    RuleFor(x => x.Email)
      .NotEmpty()
      .EmailAddress();

    RuleFor(x => x.DocumentType)
      .NotEmpty();
  }
}