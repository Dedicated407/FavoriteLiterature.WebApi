namespace FavoriteLiterature.Client.Models.Books;

public class AddBookRequestModel
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public byte Rating { get; set; }
    public string? Description { get; set; }
}