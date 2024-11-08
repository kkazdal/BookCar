using System;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers;

public class GetAuthorByQueryHandler : IRequestHandler<GetAuthorQueryById, GetQueryAuthorByIdResult>
{
    private readonly IRepository<Author> _repository;

    public GetAuthorByQueryHandler(IRepository<Author> repository)
    {
        _repository = repository;
    }

    public async Task<GetQueryAuthorByIdResult> Handle(GetAuthorQueryById request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.Id);
        return new GetQueryAuthorByIdResult
        {
            AuthorId = response.AuthorId,
            Name = response.Name,
            Description = response.Description,
            ImageUrl = response.ImageUrl
        };
    }
}
