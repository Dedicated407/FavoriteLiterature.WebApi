using FavoriteLiterature.Client.Models.Authors;

namespace FavoriteLiterature.Client.Models.Books;

public class BookModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public AuthorModel Author { get; set; }
    
    public string? Description { get; set; }
}