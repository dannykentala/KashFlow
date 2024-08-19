using KashFlow.Domain.DTOs;

namespace KashFlow.Domain.Interfaces.Repositories;

public interface IEmployeesRepository
{
    IEnumerable<EmployeeDTO> GetAll();
    EmployeeDTO GetById(int id);
    EmployeeDTO GetByEmail(string email);
    EmployeeDTO Create(EmployeeDTO employee);
    // EmployeeDTO Update(int id, EmployeeDTO employee);
    int Delete(int id);
}
