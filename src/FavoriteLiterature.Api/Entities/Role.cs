namespace FavoriteLiterature.Api.Entities;

public class Role
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; set; }

    public Role(string name, string? description = null) : this()
    {
        Name = name;
        Description = description;
    }

    private Role()
    {
    }

    public List<User> Users { get; set; } = new();
}