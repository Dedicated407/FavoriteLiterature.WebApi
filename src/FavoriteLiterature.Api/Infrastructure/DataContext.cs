using FavoriteLiterature.Api.Entities;
using FavoriteLiterature.Api.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FavoriteLiterature.Api.Infrastructure;

public class DataContext : DbContext, IDataContext
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("favoriteLiterature");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}