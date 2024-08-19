using KashFlow.Domain.DTOs;
using KashFlow.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KashFlow.App.Controllers.Employees
{
  [Route("api/employees")]
  [ApiController]
  public class EmployeesController: ControllerBase
  {
    private readonly IEmployeesRepository _employeesRepository;
    public EmployeesController(IEmployeesRepository employeesRepository)
    {
      _employeesRepository = employeesRepository;
    }

    [HttpGet]
    public IEnumerable<EmployeeDTO> GetAll()
    {
      return  _employeesRepository.GetAll();
    }
  }
}