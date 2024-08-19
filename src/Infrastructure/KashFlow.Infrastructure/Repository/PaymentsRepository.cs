using AutoMapper;
using KashFlow.Domain.DTOs;
using KashFlow.Domain.Entities;
using KashFlow.Domain.Interfaces.Repositories;
using KashFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KashFlow.Infrastructure.Repository;

public class PaymentsRepository: IPaymentsRepository
{
    private readonly BaseContext _context;
    private readonly IMapper _mapper;

    public PaymentsRepository(BaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<PaymentDTO> GetAll()
    {
        var data = _context.Payments
            .AsNoTracking()
            .Include(x => x.Customer)
            .Include(x => x.Platform)
            .Include(x => x.Bill)
            .ToList();

        IEnumerable<PaymentDTO> PaymentDTOs = _mapper.Map<IEnumerable<PaymentDTO>>(data);
        return PaymentDTOs;
    }

    public Payment GetById(int id)
    {
        var data = _context.Payments
            .AsNoTracking()
            .Include(x => x.Customer)
            .Include(x => x.Platform)
            .Include(x => x.Bill)
            .FirstOrDefault(x => x.Id == id);

        return data;
    }

    public Payment Create(Payment data)
    {
        _context.Payments.Add(data);

        // Save changes to the database
        _context.SaveChanges();
        return data;
    }

    // public PaymentDTO Update(int id, PaymentDTO Payment)
    // {
    //     // Find the existing entity by ID
    //     var existingPayment = _context.Payments.Find(id);
    //     if (existingPayment == null) return null;

    //     // Update entity properties with data from DTO
    //     existingPayment.Name = Payment.Name;
    //     // Add other property updates as necessary

    //     // Save updated entity to the database
    //     _context.Payments.Update(existingPayment);
    //     _context.SaveChanges();

    //     return existingPayment;
    // }

    public int Delete(int id)
    {
        // Find the entity by ID
        var PaymentEntity = _context.Payments.Find(id);
        if (PaymentEntity == null) return 0;

        // Remove entity from the database
        _context.Payments.Remove(PaymentEntity);
        return _context.SaveChanges();
    }
}
