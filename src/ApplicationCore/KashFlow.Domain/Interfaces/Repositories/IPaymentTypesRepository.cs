using KashFlow.Domain.DTOs;

namespace KashFlow.Domain.Interfaces.Repositories;

public interface IPaymentTypesRepository
{
    IEnumerable<PaymentTypeDTO> GetAll();
    PaymentTypeDTO GetById(int id);
    // PaymentTypeDTO Create(PaymentTypeDTO paymentType);
    // PaymentTypeDTO Update(int id, PaymentTypeDTO paymentType);
    int Delete(int id);
}
