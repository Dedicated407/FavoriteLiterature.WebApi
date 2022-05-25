using FavoriteLiterature.Api.Entities;

namespace FavoriteLiterature.Api.Infrastructure.Interfaces;

public interface IRepository
{
    public IQueryable<User> Users { get; }
    public IQueryable<Author> Authors { get; }
    public IQueryable<Book> Books { get; }
    public Task Create<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class;
}