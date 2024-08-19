using KashFlow.Domain.DTOs;
using KashFlow.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KashFlow.App.Controllers.Employees
{
  [Route("api/employees")]
  [ApiController]
  public class EmployeesCreateController: ControllerBase
  {
    private readonly IEmployeesRepository _employeesRepository;
    public EmployeesCreateController(IEmployeesRepository employeesRepository)
    {
      _employeesRepository = employeesRepository;
    }

    [HttpPost]
    public EmployeeDTO Create(EmployeeDTO employee)
    {
      return  _employeesRepository.Create(employee);
    }
  }
}