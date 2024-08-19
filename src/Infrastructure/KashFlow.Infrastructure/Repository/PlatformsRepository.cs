using AutoMapper;
using KashFlow.Domain.DTOs;
using KashFlow.Domain.Entities;
using KashFlow.Domain.Interfaces.Repositories;
using KashFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KashFlow.Infrastructure.Repository;

public class PlatformsRepository: IPlatformsRepository
{
    private readonly BaseContext _context;
    private readonly IMapper _mapper;

    public PlatformsRepository(BaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<PlatformDTO> GetAll()
    {
        var data = _context.Platforms.ToList();
        IEnumerable<PlatformDTO> PlatformDTOs = _mapper.Map<IEnumerable<PlatformDTO>>(data);
        return PlatformDTOs;
    }

    public PlatformDTO GetById(int id)
    {
        var data = _context.Platforms.Find(id);
        PlatformDTO PlatformDTO = _mapper.Map<PlatformDTO>(data);
        return PlatformDTO;
    }

    public Platform GetByName(string name)
    {
        var data = _context.Platforms
            .FirstOrDefault(x => x.Name == name);

        return data;
    }

    // public PlatformDTO Create(PlatformDTO data)
    // {
    //     // Convert DTO to entity
    //     Platform PlatformEntity = _mapper.Map<Platform>(data);
    //     _context.Platforms.Add(PlatformEntity);

    //     // Save changes to the database
    //     _context.SaveChanges();

    //     return data;
    // }

    // public PlatformDTO Update(int id, PlatformDTO Platform)
    // {
    //     // Find the existing entity by ID
    //     var existingPlatform = _context.Platforms.Find(id);
    //     if (existingPlatform == null) return null;

    //     // Update entity properties with data from DTO
    //     existingPlatform.Name = Platform.Name;
    //     // Add other property updates as necessary

    //     // Save updated entity to the database
    //     _context.Platforms.Update(existingPlatform);
    //     _context.SaveChanges();

    //     return existingPlatform;
    // }

    public int Delete(int id)
    {
        // Find the entity by ID
        var PlatformEntity = _context.Platforms.Find(id);
        if (PlatformEntity == null) return 0;

        // Remove entity from the database
        _context.Platforms.Remove(PlatformEntity);
        return _context.SaveChanges();
    }
}
