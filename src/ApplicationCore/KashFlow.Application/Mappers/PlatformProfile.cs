namespace KashFlow.Application.Mappers;

using AutoMapper;
using KashFlow.Domain.DTOs;
using KashFlow.Domain.Entities;

public class PlatformProfile : Profile
{
    public PlatformProfile()
    {
        CreateMap<Platform, PlatformDTO>();
        CreateMap<PlatformDTO, Platform>();
    }
}