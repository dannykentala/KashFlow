using AutoMapper;
using KashFlow.Domain.DTOs;
using KashFlow.Domain.Entities;
using KashFlow.Domain.Interfaces.Repositories;
using KashFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KashFlow.Infrastructure.Repository;

public class CustomersRepository: ICustomersRepository
{
    private readonly BaseContext _context;
    private readonly IMapper _mapper;

    public CustomersRepository(BaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<CustomerDTO> GetAll()
    {
        var data = _context.Customers
            .AsNoTracking()
            .Include(x => x.DocumentType)
            .ToList();

        IEnumerable<CustomerDTO> CustomerDTOs = _mapper.Map<IEnumerable<CustomerDTO>>(data);
        return CustomerDTOs;
    }

    public Customer GetById(int id)
    {
        var data = _context.Customers
            .Include(x => x.DocumentType)
            .FirstOrDefault(x => x.Id == id);

        // CustomerDTO CustomerDTO = _mapper.Map<CustomerDTO>(data);
        return data;
    }

    public Customer GetByEmail(string email)
    {
        var data = _context.Customers
            .FirstOrDefault(x => x.Email == email);

        return data;
    }

    // public CustomerDTO Create(CustomerDTO data)
    // {
    //     // Convert DTO to entity
    //     Customer CustomerEntity = _mapper.Map<Customer>(data);
    //     _context.Customers.Add(CustomerEntity);

    //     // Save changes to the database
    //     _context.SaveChanges();

    //     return data;
    // }

    // public CustomerDTO Update(int id, CustomerDTO Customer)
    // {
    //     // Find the existing entity by ID
    //     var existingCustomer = _context.Customers.Find(id);
    //     if (existingCustomer == null) return null;

    //     // Update entity properties with data from DTO
    //     existingCustomer.Name = Customer.Name;
    //     // Add other property updates as necessary

    //     // Save updated entity to the database
    //     _context.Customers.Update(existingCustomer);
    //     _context.SaveChanges();

    //     return existingCustomer;
    // }

    public int Delete(int id)
    {
        // Find the entity by ID
        var CustomerEntity = _context.Customers.Find(id);
        if (CustomerEntity == null) return 0;

        // Remove entity from the database
        _context.Customers.Remove(CustomerEntity);
        return _context.SaveChanges();
    }
}
