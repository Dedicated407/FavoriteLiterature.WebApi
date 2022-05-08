namespace FavoriteLiterature.Api.Entities;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        Created = DateTimeOffset.UtcNow;
    }

    public DateTimeOffset Created { get; private set; }

    public DateTimeOffset? Updated { get; protected set; }
}
