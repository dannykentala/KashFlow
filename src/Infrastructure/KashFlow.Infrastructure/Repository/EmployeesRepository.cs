using AutoMapper;
using KashFlow.Application.Utils;
using KashFlow.Domain.DTOs;
using KashFlow.Domain.Entities;
using KashFlow.Domain.Interfaces.Repositories;
using KashFlow.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace KashFlow.Infrastructure.Repository;

public class EmployeesRepository: IEmployeesRepository
{
    private readonly BaseContext _context;
    private readonly IMapper _mapper;

    public EmployeesRepository(BaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<EmployeeDTO> GetAll()
    {
        var data = _context.Employees.ToList();
        IEnumerable<EmployeeDTO> EmployeeDTOs = _mapper.Map<IEnumerable<EmployeeDTO>>(data);
        return EmployeeDTOs;
    }

    public EmployeeDTO GetById(int id)
    {
        var data = _context.Employees.Find(id);
        EmployeeDTO EmployeeDTO = _mapper.Map<EmployeeDTO>(data);
        return EmployeeDTO;
    }

    public EmployeeDTO GetByEmail(string email)
    {
        var data = _context.Employees.FirstOrDefault(x => x.Email == email);
        EmployeeDTO EmployeeDTO = _mapper.Map<EmployeeDTO>(data);
        return EmployeeDTO;
    }

    public EmployeeDTO Create(EmployeeDTO data)
    {
        // Convert DTO to entity
        Employee employeeEntity = _mapper.Map<Employee>(data);
        employeeEntity.Password = PasswordHashing.HashPassword(employeeEntity.Password);
        
        _context.Employees.Add(employeeEntity);

        // Save changes to the database
        _context.SaveChanges();

        return data;
    }

    // public EmployeeDTO Update(int id, EmployeeDTO Employee)
    // {
    //     // Find the existing entity by ID
    //     var existingEmployee = _context.Employees.Find(id);
    //     if (existingEmployee == null) return null;

    //     // Update entity properties with data from DTO
    //     existingEmployee.Name = Employee.Name;
    //     // Add other property updates as necessary

    //     // Save updated entity to the database
    //     _context.Employees.Update(existingEmployee);
    //     _context.SaveChanges();

    //     return existingEmployee;
    // }

    public int Delete(int id)
    {
        // Find the entity by ID
        var EmployeeEntity = _context.Employees.Find(id);
        if (EmployeeEntity == null) return 0;

        // Remove entity from the database
        _context.Employees.Remove(EmployeeEntity);
        return _context.SaveChanges();
    }
}
