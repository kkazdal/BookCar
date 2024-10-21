using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.CQRS.Results.AboutResult;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandler;
public class GetAboutByIdQueryHandle
{
    private readonly IRepository<About> _repository;

    public GetAboutByIdQueryHandle(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery getAboutByIdQuery)
    {
        var response = await _repository.GetByIdAsync(getAboutByIdQuery.Id);

        return new GetAboutByIdQueryResult
        {
            AboutId = response.AboutId,
            Description = response.Description,
            ImageUrl = response.ImageUrl,
            Title = response.Title
        };
    }
}
