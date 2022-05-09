using FavoriteLiterature.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace FavoriteLiterature.Api.Infrastructure.Interfaces;

public interface IDataContext
{
    DbSet<Role> Roles { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<Author> Authors { get; set; }
    DbSet<Book> Books { get; set; }
    DbSet<Critic> Critics { get; set; }
    DbSet<CriticOpinion> Opinions { get; set; }
    DbSet<Document> Documents { get; set; }
    DbSet<Status> Statuses { get; set; }
}