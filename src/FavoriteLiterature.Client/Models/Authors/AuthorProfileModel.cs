namespace FavoriteLiterature.Client.Models.Authors;

public class AuthorProfileModel : AuthorModel
{
    public string? Description { get; set; }
    public List<string> BookNames { get; set; }
    public DateTimeOffset? Birthday { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public byte Rating { get; set; }
}