using FavoriteLiterature.Api.Entities;
using MediatR;

namespace FavoriteLiterature.Api.Infrastructure.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    public Task<Unit> Create(TEntity entity, CancellationToken cancellationToken);
    public TEntity? Get(Guid id);
    public Guid Update(TEntity entity);
    public void Delete(Guid id);
    public IQueryable<TEntity> GetAll();
}