using FavoriteLiterature.Api.Entities;
using FavoriteLiterature.Api.Infrastructure.Interfaces;

namespace FavoriteLiterature.Api.Infrastructure;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly DataContext _context;

    public Repository(DataContext context)
    {
        _context = context;
    }
    
    public Guid Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
        return entity.Id;
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
}