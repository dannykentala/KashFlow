using KashFlow.Application.Managers;
using KashFlow.Domain.DTOs;
using KashFlow.Domain.DTOs.Setters;
using KashFlow.Domain.Entities;
using KashFlow.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KashFlow.Api.Controllers.Payments
{
  [Route("api/payments")]
  [ApiController]
  // Remember that in works in onion (this is level 1, repository is level 2), so
  // others classes, don't know about this one
  public class PaymentsController: ControllerBase
  {
    private readonly PaymentManager _paymentManager;
    public PaymentsController(PaymentManager paymentManager)
    {
      _paymentManager = paymentManager;
    }

    [HttpGet]
    public IEnumerable<PaymentDTO> GetAll()
    {
      return _paymentManager.GetAll();
    }

    [HttpPost]
    public Payment Create([FromBody] PaymentCreateDTO employee)
    {
      return  _paymentManager.Create(employee);
    }

    // [HttpGet("{Id}")]
    // public Payment GetById(int Id)
    // {
    //   return _paymentManager.GetById(Id);
    // }
  }
}