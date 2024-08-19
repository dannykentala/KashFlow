using AutoMapper;
using KashFlow.Domain.DTOs;
using KashFlow.Domain.Entities;
using KashFlow.Domain.Interfaces.Repositories;
using KashFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KashFlow.Infrastructure.Repository;

public class BillsRepository: IBillsRepository
{
    private readonly BaseContext _context;
    private readonly IMapper _mapper;

    public BillsRepository(BaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<BillDTO> GetAll()
    {
        var data = _context.Bills
            .AsNoTracking()
            .Include(x => x.PaymentType)
            .ToList();
            
        IEnumerable<BillDTO> BillDTOs = _mapper.Map<IEnumerable<BillDTO>>(data);
        return BillDTOs;
    }

    public BillDTO GetById(int id)
    {
        var data = _context.Bills
            .AsNoTracking()
            .Include(x => x.PaymentType) 
            .FirstOrDefault(x => x.Id == id);
            
        BillDTO BillDTO = _mapper.Map<BillDTO>(data);
        return BillDTO;
    }

    public Bill GetByCode(string  code)
    {
        var data = _context.Bills
            .AsNoTracking()
            .FirstOrDefault(x => x.Code == code);

        return data;
    }

    // public BillDTO Create(BillDTO data)
    // {
    //     // Convert DTO to entity
    //     Bill BillEntity = _mapper.Map<Bill>(data);
    //     _context.Bills.Add(BillEntity);

    //     // Save changes to the database
    //     _context.SaveChanges();

    //     return data;
    // }

    // public BillDTO Update(int id, BillDTO Bill)
    // {
    //     // Find the existing entity by ID
    //     var existingBill = _context.Bills.Find(id);
    //     if (existingBill == null) return null;

    //     // Update entity properties with data from DTO
    //     existingBill.Name = Bill.Name;
    //     // Add other property updates as necessary

    //     // Save updated entity to the database
    //     _context.Bills.Update(existingBill);
    //     _context.SaveChanges();

    //     return existingBill;
    // }

    public int Delete(int id)
    {
        // Find the entity by ID
        var BillEntity = _context.Bills.Find(id);
        if (BillEntity == null) return 0;

        // Remove entity from the database
        _context.Bills.Remove(BillEntity);
        return _context.SaveChanges();
    }
}
