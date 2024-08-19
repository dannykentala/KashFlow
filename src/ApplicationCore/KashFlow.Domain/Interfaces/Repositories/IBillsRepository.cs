using KashFlow.Domain.DTOs;
using KashFlow.Domain.Entities;

namespace KashFlow.Domain.Interfaces.Repositories;

public interface IBillsRepository
{
    IEnumerable<BillDTO> GetAll();
    BillDTO GetById(int id);
    Bill GetByCode(string name);
    
    // BillDTO Create(BillDTO bill);
    // BillDTO Update(int id, BillDTO bill);
    int Delete(int id);
}
