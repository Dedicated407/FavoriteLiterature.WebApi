using FavoriteLiterature.Api.Entities;
using FavoriteLiterature.Api.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FavoriteLiterature.Api.Infrastructure;

public class DataContext : DbContext, IDataContext, IRepository
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    #region DbSet
    
    public DbSet<Role> DbRoles { get; set; }
    public DbSet<User> DbUsers { get; set; }
    public DbSet<Author> DbAuthors { get; set; }
    public DbSet<Critic> DbCritics { get; set; }
    public DbSet<Book> DbBooks { get; set; }
    public DbSet<CriticOpinion> DbOpinions { get; set; }
    public DbSet<Document> DbDocuments { get; set; }
    public DbSet<Status> DbStatuses { get; set; }
    
    #endregion

    #region IQueryable

    public IQueryable<User> Users => DbUsers;
    public IQueryable<Author> Authors => DbAuthors;
    public IQueryable<Book> Books => DbBooks;
    public IQueryable<Role> Roles => DbRoles;

    #endregion
    
    public async Task Create<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class
    {   
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        
        await AddAsync(entity, cancellationToken);
        await SaveChangesAsync(cancellationToken);
    }
    
    public async Task<Role> FindRole(int id)
    {
        return await DbRoles.FirstOrDefaultAsync(role => role.Id == id) ?? throw new InvalidOperationException();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("favoriteLiterature");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}