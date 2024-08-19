namespace KashFlow.Application.Mappers;

using AutoMapper;
using KashFlow.Domain.DTOs;
using KashFlow.Domain.Entities;

public class DocumentTypeProfile : Profile
{
    public DocumentTypeProfile()
    {
        CreateMap<DocumentType, DocumentTypeDTO>();
        CreateMap<DocumentTypeDTO, DocumentType>();
    }
}