namespace FavoriteLiterature.Api.Entities;

public class Book : BaseEntity
{
    public string Name { get; private set; }
    public Guid AuthorId { get; private set; }
    public Author Author { get; private set; }
    public string? Description { get; private set; }

    public Book(string name, Guid authorId, string? description = null)
    {
        Name = name;
        AuthorId = authorId;
        Description = description;
    }
    
    public List<Document> Documents { get; set; } = new();
    public List<CriticOpinion> Opinions { get; set; } = new();
}