using FluentValidation;
using KashFlow.Domain.DTOs.Setters;

namespace KashFlow.Application.Validations.Fluent;

public class PaymentFluent: AbstractValidator<PaymentCreateDTO>
{
  public PaymentFluent ()
  {
    RuleFor(x => x.Amount)
      .NotEmpty();

    RuleFor(x => x.Status)
      .NotEmpty();

    //-- Regla de negocio, debe estar en las plataformas especificadas, pero me toca
    // que hacer una query
    RuleFor(x => x.BillCode)
      .NotEmpty();

    RuleFor(x => x.CustomerEmail)
      .NotEmpty()
      .EmailAddress();

    RuleFor(x => x.PlatformName)
      .NotEmpty();
  }
}