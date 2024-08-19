namespace KashFlow.Application.Mappers;

using AutoMapper;
using KashFlow.Domain.DTOs;
using KashFlow.Domain.Entities;

public class PaymentTypeProfile : Profile
{
    public PaymentTypeProfile()
    {
        CreateMap<PaymentType, PaymentTypeDTO>();
        CreateMap<PaymentTypeDTO, PaymentType>();
    }
}