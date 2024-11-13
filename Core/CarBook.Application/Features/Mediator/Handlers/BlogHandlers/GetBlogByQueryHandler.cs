using System;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogRepositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class GetBlogByQueryHandler : IRequestHandler<GetBlogQueryById, GetQueryBlogByIdResult>
{
    private readonly IBlogRepository _repository;

    public GetBlogByQueryHandler(IBlogRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetQueryBlogByIdResult> Handle(GetBlogQueryById request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetBlogWithAuthorInfoById(request.Id);
        return response;
    }
}
