using KashFlow.Domain.DTOs;
using KashFlow.Domain.Entities;

namespace KashFlow.Domain.Interfaces.Repositories;

public interface IPaymentsRepository
{
    IEnumerable<PaymentDTO> GetAll();
    Payment GetById(int id);
    Payment Create(Payment payment);
    // PaymentDTO Update(int id, PaymentDTO payment);
    int Delete(int id);
}
