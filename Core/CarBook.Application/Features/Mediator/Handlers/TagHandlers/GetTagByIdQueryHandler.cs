using System;
using CarBook.Application.Features.Mediator.Queries.TagQueries;
using CarBook.Application.Features.Mediator.Results.TagResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TagHandlers;

public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, GetTagByIdQueryResult>
{
    private readonly IRepository<Tag> _repository;

    public GetTagByIdQueryHandler(IRepository<Tag> repository)
    {
        _repository = repository;
    }

    public async Task<GetTagByIdQueryResult> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.Id);
        return new GetTagByIdQueryResult
        {
            TagName = response.TagName,
            Id = response.Id
        };
    }
}
