namespace KashFlow.Application.Mappers;

using AutoMapper;
using KashFlow.Domain.DTOs;
using KashFlow.Domain.Entities;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDTO>()
            .ForMember(dest =>
                dest.DocumentType,
                opt => opt.MapFrom(src => src.DocumentType.Name)
            );

        CreateMap<CustomerDTO, Customer>();
    }
}
