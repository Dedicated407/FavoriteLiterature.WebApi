namespace FavoriteLiterature.Api.Entities;

public class Document : BaseEntity
{
    public string Name { get; private set; }
    public Guid BookId { get; private set; }
    public Book Book { get; private set; }
    public byte[] File { get; private set; }

    public Document(string name, Guid bookId, byte[] file)
    {
        Name = name;
        BookId = bookId;
        File = file;
    }
}