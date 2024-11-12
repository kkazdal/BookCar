using System;
using CarBook.Application.Features.Mediator.Queries.TagQueries;
using CarBook.Application.Features.Mediator.Results.TagResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TagHandlers;

public class GetTagQueryHandler : IRequestHandler<GetTagQuery, List<GetTagQueryResult>>
{
    private readonly IRepository<Tag> _repository;

    public GetTagQueryHandler(IRepository<Tag> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetTagQueryResult>> Handle(GetTagQuery request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetAllAsync();

        return response.Select(item => new GetTagQueryResult
        {
            Id = item.Id,
            BlogId = item.BlogId,
            TagName = item.TagName
        }).ToList();
    }
}
