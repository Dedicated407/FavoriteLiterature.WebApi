using FavoriteLiterature.Api.Entities;
using FavoriteLiterature.Api.Entities.Enums;
using FavoriteLiterature.Api.Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FavoriteLiterature.Api.Infrastructure;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly DataContext _context;

    public Repository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<Unit> Create(TEntity entity, CancellationToken cancellationToken)
    {
        await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }

    public TEntity? Get(Guid id)
    {
        return _context.Set<TEntity>().FirstOrDefault(entity => entity.Id == id);
    }

    public Guid Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        _context.SaveChanges();
        return entity.Id;
    }

    public void Delete(Guid id)
    {
        var foundEntity = Get(id);
        
        if (foundEntity != null)
        {
            _context.Set<TEntity>().Remove(foundEntity);
        }
        
        _context.SaveChanges();
    }

    public IQueryable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().AsQueryable();
    }

    public async Task<Role> FindRole(int id)
    {
        return await _context.Roles.FirstOrDefaultAsync(role => role.Id == id) ?? throw new InvalidOperationException();
    }
}