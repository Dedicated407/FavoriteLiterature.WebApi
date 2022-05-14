namespace FavoriteLiterature.Api.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; private set; }

    public DateTimeOffset Created { get; private set; }

    public DateTimeOffset? Updated { get; protected set; }
    
    protected BaseEntity()
    {
        Id = Guid.Empty;
        Created = DateTimeOffset.UtcNow;
    }
}
