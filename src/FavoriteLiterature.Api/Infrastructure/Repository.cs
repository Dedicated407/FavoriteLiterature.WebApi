using FavoriteLiterature.Api.Entities;
using FavoriteLiterature.Api.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FavoriteLiterature.Api.Infrastructure;

public class Repository : IRepository
{
    public Repository(DataContext context)
    {
        _context = context;
    }
    
    private readonly DataContext _context;

    #region IQueryable

    public IQueryable<User> Users => _context.DbUsers;
    public IQueryable<Author> Authors => _context.DbAuthors;
    public IQueryable<Book> Books => _context.DbBooks;
    public IQueryable<Role> Roles => _context.DbRoles;

    #endregion
    
    public async Task Create<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class
    {   
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        
        await _context.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<Role> FindRole(int id)
    {
        return await _context.DbRoles.FirstOrDefaultAsync(role => role.Id == id) ?? throw new InvalidOperationException();
    }
}