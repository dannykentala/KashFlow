using KashFlow.Domain.DTOs;
using KashFlow.Domain.Entities;
using KashFlow.Domain.Interfaces.Repositories;

namespace KashFlow.Application.Generators;

public class PaymentGenerator
{
  private readonly IPaymentsRepository _paymentsRepository;

  public PaymentGenerator(IPaymentsRepository paymentsRepository)
  {
    _paymentsRepository = paymentsRepository;
  }

  public Payment AddDefaults(Payment payment)
  {
    payment.Date = Date();
    payment.TransactionCode = PaymentCode();
    return payment;
  }

  //----- Default data -----//

  private DateTime Date()
  {
    return DateTime.Now;
  }

  private string PaymentCode()
  {
    IEnumerable<PaymentDTO> payments = _paymentsRepository.GetAll();
    int currentPayments = payments.Count();
    return $"PC{currentPayments}";
  }

  //----- Others -----//
}