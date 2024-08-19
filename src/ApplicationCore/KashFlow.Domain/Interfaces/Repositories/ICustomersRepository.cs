using KashFlow.Domain.DTOs;
using KashFlow.Domain.Entities;

namespace KashFlow.Domain.Interfaces.Repositories;

public interface ICustomersRepository
{
    IEnumerable<CustomerDTO> GetAll();
    Customer GetById(int id);
    Customer GetByEmail(string email);
    // CustomerDTO Create(CustomerDTO customer);
    // CustomerDTO Update(int id, CustomerDTO customer);
    int Delete(int id);
}
