using AutoMapper;
using KashFlow.Domain.DTOs;
using KashFlow.Domain.Interfaces.Repositories;
using KashFlow.Infrastructure.Data;

namespace KashFlow.Infrastructure.Repository;

public class DocumentsTypesRepository: IDocumentsTypesRepository
{
    private readonly BaseContext _context;
    private readonly IMapper _mapper;

    public DocumentsTypesRepository(BaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<DocumentTypeDTO> GetAll()
    {
        var data = _context.DocumentTypes.ToList();
        IEnumerable<DocumentTypeDTO> DocumentTypeDTOs = _mapper.Map<IEnumerable<DocumentTypeDTO>>(data);
        return DocumentTypeDTOs;
    }

    public DocumentTypeDTO GetById(int id)
    {
        var data = _context.DocumentTypes.Find(id);
        DocumentTypeDTO DocumentTypeDTO = _mapper.Map<DocumentTypeDTO>(data);
        return DocumentTypeDTO;
    }

    // public DocumentTypeDTO Create(DocumentTypeDTO data)
    // {
    //     // Convert DTO to entity
    //     DocumentType DocumentTypeEntity = _mapper.Map<DocumentType>(data);
    //     _context.DocumentTypes.Add(DocumentTypeEntity);

    //     // Save changes to the database
    //     _context.SaveChanges();

    //     return data;
    // }

    // public DocumentTypeDTO Update(int id, DocumentTypeDTO DocumentType)
    // {
    //     // Find the existing entity by ID
    //     var existingDocumentType = _context.DocumentTypes.Find(id);
    //     if (existingDocumentType == null) return null;

    //     // Update entity properties with data from DTO
    //     existingDocumentType.Name = DocumentType.Name;
    //     // Add other property updates as necessary

    //     // Save updated entity to the database
    //     _context.DocumentTypes.Update(existingDocumentType);
    //     _context.SaveChanges();

    //     return existingDocumentType;
    // }

    public int Delete(int id)
    {
        // Find the entity by ID
        var DocumentTypeEntity = _context.DocumentTypes.Find(id);
        if (DocumentTypeEntity == null) return 0;

        // Remove entity from the database
        _context.DocumentTypes.Remove(DocumentTypeEntity);
        return _context.SaveChanges();
    }
}
