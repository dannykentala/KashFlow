namespace KashFlow.Application.Mappers;

using AutoMapper;
using KashFlow.Domain.DTOs;
using KashFlow.Domain.Entities;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDTO>();
        CreateMap<EmployeeDTO, Employee>();
    }
}