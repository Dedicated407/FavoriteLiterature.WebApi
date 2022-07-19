namespace FavoriteLiterature.Client.Models;

public class PaginationModel
{
    private readonly int _skip = 0;
    private readonly int _take = 10;

    public int Skip
    {
        get => _skip;
        init
        {
            if (value < 0)
            {
                throw new ArgumentException("You can`t skip be less 0", nameof(Skip));
            }
            _skip = value;
        }
    }

    public int Take
    {
        get => _take;
        init
        {
            if (value is < 0 or > 10)
            {
                throw new ArgumentException("You can`t take more 10 values", nameof(Take));
            }
            _take = value;
        }
    }
}