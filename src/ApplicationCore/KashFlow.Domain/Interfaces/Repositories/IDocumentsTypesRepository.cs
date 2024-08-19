using KashFlow.Domain.DTOs;

namespace KashFlow.Domain.Interfaces.Repositories;

public interface IDocumentsTypesRepository
{
    IEnumerable<DocumentTypeDTO> GetAll();
    DocumentTypeDTO GetById(int id);
    // DocumentTypeDTO Create(DocumentTypeDTO documentType);
    // DocumentTypeDTO Update(int id, DocumentTypeDTO documentType);
    int Delete(int id);
}
