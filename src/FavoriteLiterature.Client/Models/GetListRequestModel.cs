namespace FavoriteLiterature.Client.Models;

public class GetListRequestModel : PaginationModel
{
    public string? Query { get; init; }
}