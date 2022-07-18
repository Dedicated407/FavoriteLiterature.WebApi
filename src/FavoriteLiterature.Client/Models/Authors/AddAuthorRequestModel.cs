namespace FavoriteLiterature.Client.Models.Authors;

public class AddAuthorRequestModel
{
    public Guid AuthorId { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset? Birthday { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public byte Rating { get; set; }
}