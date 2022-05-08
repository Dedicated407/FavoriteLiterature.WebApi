namespace FavoriteLiterature.Api.Entities;

public class Status
{
    public byte Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; set; }

    public Status(string name, string? description)
    {
        Name = name;
        Description = description;
    }
}