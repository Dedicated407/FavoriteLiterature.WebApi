namespace FavoriteLiterature.Api.Entities;

public class Document : BaseEntity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Guid BookId { get; private set; }
    public Book Book { get; private set; }
    public byte[] File { get; private set; }

    public Document(string name, Guid bookId, byte[] file) : this()
    {
        Name = name;
        BookId = bookId;
        File = file;
    }
    
    private Document()
    {
        Id = Guid.Empty;
    }
}