using KashFlow.Domain.DTOs;
using KashFlow.Domain.DTOs.Setters;
using KashFlow.Domain.Entities;

namespace KashFlow.Application.Utils.Cleaners;

public static class BaseCleaner
{
  public static PaymentCreateDTO CleanPayment(PaymentCreateDTO payment)
  {
    payment.BillCode = payment.BillCode.ToLower();
    payment.PlatformName = payment.PlatformName.ToLower();
    return payment;
  }
}