using AutoMapper;
using KashFlow.Application.Generators;
using KashFlow.Application.Utils.Cleaners;
using KashFlow.Application.Validations.Interators;
using KashFlow.Domain.DTOs;
using KashFlow.Domain.DTOs.Setters;
using KashFlow.Domain.Entities;
using KashFlow.Domain.Interfaces.Repositories;

namespace KashFlow.Application.Managers;

public class PaymentManager
{
  private readonly IPaymentsRepository _paymentsRepository;
  private readonly PaymentGenerator _paymentGenerator;
  private readonly PaymentInterator _paymentInterator;
  private readonly IMapper _mapper;

  public PaymentManager
  (
    IPaymentsRepository paymentsRepository,
    PaymentGenerator paymentGenerator,
    PaymentInterator paymentInterator,
    IMapper mapper 
  )
  {
    _paymentsRepository = paymentsRepository;
    _paymentGenerator = paymentGenerator;
    _paymentInterator = paymentInterator;
    _mapper = mapper;
  }


  /*
    ## Logic flow

    * Clean: First normalize data
    * Map: Mapping data between models
    * Validate: Validations base in Business Rules
    * AddDefaults: Add default data
    * Repository: Add data to persistence
    * Response: 
  */
  public Payment Create(PaymentCreateDTO paymentDTO)
  {
    paymentDTO = BaseCleaner.CleanPayment(paymentDTO);

    Payment payment = _mapper.Map<Payment>(paymentDTO);

    _paymentInterator.Init(payment, paymentDTO)
      .ValidCustomer()
      .ValidPlatform()
      .ValidBill();

    if(!_paymentInterator.Succeded)
    {
      // --> TODO: Add errors, make a personalize response
      return null;
    }
    else
    {
      payment = _paymentInterator.Data;
    }

    payment = _paymentGenerator.AddDefaults(payment);
    _paymentsRepository.Create(payment);

    return payment;
  }

  public IEnumerable<PaymentDTO> GetAll()
  {
    return _paymentsRepository.GetAll();
  }
}