using AutoMapper;
using FavoriteLiterature.Api.Infrastructure.Interfaces;
using FavoriteLiterature.Client.Models.Authors;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FavoriteLiterature.Api.Entities.Requests.Authors;

public class GetAuthorsListRequestHandler : IRequestHandler<GetAuthorsListRequest, ICollection<AuthorModel>>
{
    private readonly IRepository _repository;

    public GetAuthorsListRequestHandler(IRepository? repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    
    public async Task<ICollection<AuthorModel>> Handle(GetAuthorsListRequest request, CancellationToken cancellationToken)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<User, AuthorModel>());
        var mapper = new Mapper(config);
        
        var entities = await _repository.Users
            .Where(x => x.Author != null)
            .OrderBy(x => x.LastName)
            .ToArrayAsync(cancellationToken);
        
        var result = mapper.Map<List<AuthorModel>>(entities);
        return result;
    }
}