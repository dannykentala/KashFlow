using KashFlow.Domain.DTOs.Setters;
using KashFlow.Domain.Entities;
using KashFlow.Domain.Interfaces.Repositories;

namespace KashFlow.Application.Validations.Interators;
public class PaymentInterator: BaseIterator<Payment>
{
  private readonly ICustomersRepository _customersRepository;
  private readonly IPlatformsRepository _platformsRepository;
  private readonly IBillsRepository _billsRepository;
  private PaymentCreateDTO _paymentCreateDTO;

  public PaymentInterator
  (
    ICustomersRepository customersRepository,
    IPlatformsRepository platformsRepository,
    IBillsRepository billsRepository
  )
  {
    _customersRepository = customersRepository;
    _platformsRepository = platformsRepository;
    _billsRepository = billsRepository;
  }

  public PaymentInterator Init(Payment payment, PaymentCreateDTO paymentDTO)
  {
    _paymentCreateDTO = paymentDTO;
    Data = payment;
    return this;
  }

  // public void Validate()
  // {
  //   ValidCustomer();
  //   ValidPlatform();
  // }

  public PaymentInterator ValidCustomer()
  {
    string customerEmail = _paymentCreateDTO.CustomerEmail;
    var customer = _customersRepository.GetByEmail(customerEmail);

    if(customer == null)
    {
      Errors.Add(new Error()
      {
        ErrorName = $"User with email '{customerEmail}' doesn't exist"
      });

      return this;
    }

    Data.CustomerId = customer.Id;
    return this;
  }

  public PaymentInterator ValidPlatform()
  {
    string platfromName = _paymentCreateDTO.PlatformName;
    var platform = _platformsRepository.GetByName(platfromName);

    if(platform == null)
    {
      Errors.Add(new Error()
      {
        ErrorName = $"platform with name '{platfromName}' doesn't exist"
      });

      return this;
    }

    Data.PlatformId = platform.Id;
    return this;
  }

  public PaymentInterator ValidBill()
  {
    string billCode = _paymentCreateDTO.BillCode;
    var bill = _billsRepository.GetByCode(billCode);

    if(bill == null)
    {
      Errors.Add(new Error()
      {
        ErrorName = $"bill with code '{billCode}' doesn't exist"
      });

      return this;
    }

    Data.BillId = bill.Id;
    return this;
  }
}