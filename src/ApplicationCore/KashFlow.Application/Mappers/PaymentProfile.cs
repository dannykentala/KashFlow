namespace KashFlow.Application.Mappers;

using AutoMapper;
using KashFlow.Domain.DTOs;
using KashFlow.Domain.DTOs.Setters;
using KashFlow.Domain.Entities;

public class PaymentProfile : Profile
{
    public PaymentProfile()
    {
        CreateMap<Payment, PaymentDTO>()
            .ForMember(dest =>
                dest.BillCode,
                opt => opt.MapFrom(src => src.Bill.Code)
            )
            .ForMember(dest =>
                dest.Customer,
                opt => opt.MapFrom(src => src.Customer.Name)
            )
            .ForMember(dest =>
                dest.Platform,
                opt => opt.MapFrom(src => src.Platform.Name)
            );

        CreateMap<PaymentCreateDTO, Payment>();
    }
}