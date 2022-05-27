using FavoriteLiterature.Api.Entities.Enums;

namespace FavoriteLiterature.Api.Entities;

public class Role
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; set; }

    public Role(int id, string name, string? description = null) : this()
    {
        Id = id;
        Name = name;
        Description = description;
    }

    private Role()
    {
        Id = 1;
        Name = Enum.GetName(typeof(Roles), Id);
    }

    public List<User> Users { get; set; } = new();
}