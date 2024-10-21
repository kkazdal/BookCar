using CarBook.Application.Features.CQRS.Results.AboutResult;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandler;

public class GetAboutQueryHandle
{
    private readonly IRepository<About> _repository;

    public GetAboutQueryHandle(IRepository<About> repository)
    {
        this._repository = repository;
    }

    public async Task<List<GetAboutQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetAboutQueryResult
        {
            AboutId = x.AboutId,
            Description = x.Description,
            ImageUrl = x.ImageUrl,
            Title = x.Title
        }).ToList();
    }
}
