using KashFlow.Domain.DTOs;
using KashFlow.Domain.Entities;

namespace KashFlow.Domain.Interfaces.Repositories;

public interface IPlatformsRepository
{
    IEnumerable<PlatformDTO> GetAll();
    PlatformDTO GetById(int id);
    Platform GetByName(string platform);

    // PlatformDTO Create(PlatformDTO platform);
    // PlatformDTO Update(int id, PlatformDTO platform);
    int Delete(int id);
}