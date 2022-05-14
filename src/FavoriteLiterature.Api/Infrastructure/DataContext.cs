using FavoriteLiterature.Api.Entities;
using FavoriteLiterature.Api.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FavoriteLiterature.Api.Infrastructure;

public class DataContext : DbContext, IDataContext
{
    #region DbSet
    
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Critic> Critics { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<CriticOpinion> Opinions { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Status> Statuses { get; set; }
    
    #endregion

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("favoriteLiterature");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}