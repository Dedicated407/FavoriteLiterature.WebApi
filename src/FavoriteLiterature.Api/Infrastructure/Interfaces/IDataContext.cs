using FavoriteLiterature.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace FavoriteLiterature.Api.Infrastructure.Interfaces;

public interface IDataContext
{
    DbSet<Role> DbRoles { get; set; }
    DbSet<User> DbUsers { get; set; }
    DbSet<Author> DbAuthors { get; set; }
    DbSet<Book> DbBooks { get; set; }
    DbSet<Critic> DbCritics { get; set; }
    DbSet<CriticOpinion> DbOpinions { get; set; }
    DbSet<Document> DbDocuments { get; set; }
    DbSet<Status> DbStatuses { get; set; }
}