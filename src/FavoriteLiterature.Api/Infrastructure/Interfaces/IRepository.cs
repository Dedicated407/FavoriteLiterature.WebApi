using FavoriteLiterature.Api.Entities;

namespace FavoriteLiterature.Api.Infrastructure.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    public Guid Create(TEntity entity);
    public TEntity? Get(Guid id);
    public Guid Update(TEntity entity);
    public void Delete(Guid id);
    public IQueryable<TEntity> GetAll();

}