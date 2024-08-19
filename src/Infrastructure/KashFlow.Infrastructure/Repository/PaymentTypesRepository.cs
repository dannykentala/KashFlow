using AutoMapper;
using KashFlow.Domain.DTOs;
using KashFlow.Domain.Entities;
using KashFlow.Domain.Interfaces.Repositories;
using KashFlow.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace KashFlow.Infrastructure.Repository;

public class PaymentTypesRepository: IPaymentTypesRepository
{
    private readonly BaseContext _context;
    private readonly IMapper _mapper;

    public PaymentTypesRepository(BaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<PaymentTypeDTO> GetAll()
    {
        var data = _context.PaymentTypes.ToList();
        IEnumerable<PaymentTypeDTO> PaymentTypeDTOs = _mapper.Map<IEnumerable<PaymentTypeDTO>>(data);
        return PaymentTypeDTOs;
    }

    public PaymentTypeDTO GetById(int id)
    {
        var data = _context.PaymentTypes.Find(id);
        PaymentTypeDTO PaymentTypeDTO = _mapper.Map<PaymentTypeDTO>(data);
        return PaymentTypeDTO;
    }

    // public PaymentTypeDTO Create(PaymentTypeDTO data)
    // {
    //     // Convert DTO to entity
    //     PaymentType PaymentTypeEntity = _mapper.Map<PaymentType>(data);
    //     _context.PaymentTypes.Add(PaymentTypeEntity);

    //     // Save changes to the database
    //     _context.SaveChanges();

    //     return data;
    // }

    // public PaymentTypeDTO Update(int id, PaymentTypeDTO PaymentType)
    // {
    //     // Find the existing entity by ID
    //     var existingPaymentType = _context.PaymentTypes.Find(id);
    //     if (existingPaymentType == null) return null;

    //     // Update entity properties with data from DTO
    //     existingPaymentType.Name = PaymentType.Name;
    //     // Add other property updates as necessary

    //     // Save updated entity to the database
    //     _context.PaymentTypes.Update(existingPaymentType);
    //     _context.SaveChanges();

    //     return existingPaymentType;
    // }

    public int Delete(int id)
    {
        // Find the entity by ID
        var PaymentTypeEntity = _context.PaymentTypes.Find(id);
        if (PaymentTypeEntity == null) return 0;

        // Remove entity from the database
        _context.PaymentTypes.Remove(PaymentTypeEntity);
        return _context.SaveChanges();
    }
}
