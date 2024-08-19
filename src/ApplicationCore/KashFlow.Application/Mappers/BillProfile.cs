namespace KashFlow.Application.Mappers;

using AutoMapper;
using KashFlow.Domain.DTOs;
using KashFlow.Domain.Entities;

public class BillProfile : Profile
{
    public BillProfile()
    {
        // Source - Destination
        CreateMap<Bill, BillDTO>()
            .ForMember(dest =>
                dest.PaymentType,
                opt => opt.MapFrom(src => src.PaymentType.Name)
            );

        CreateMap<BillDTO, Bill>();
    }
}