using System;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers;

public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetQueryAuthorResult>>
{
    private readonly IRepository<Author> repository;

    public GetAuthorQueryHandler(IRepository<Author> repository)
    {
        this.repository = repository;
    }

    public async Task<List<GetQueryAuthorResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        var response = await repository.GetAllAsync();
        return response.Select(x => new GetQueryAuthorResult
        {
            AuthorId = x.AuthorId,
            Description = x.Description,
            ImageUrl = x.ImageUrl,
            Name = x.Name
        }).ToList();
    }
}
