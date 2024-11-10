using System;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class GetBlogByQueryHandler : IRequestHandler<GetBlogQueryById, GetQueryBlogByIdResult>
{
    private readonly IRepository<Blog> _repository;

    public GetBlogByQueryHandler(IRepository<Blog> repository)
    {
        _repository = repository;
    }

    public async Task<GetQueryBlogByIdResult> Handle(GetBlogQueryById request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.Id);
        return new GetQueryBlogByIdResult
        {
            AuthorId = response.AuthorId,
            CategoryId = response.CategoryId,
            Title = response.Title,
            CoverImageUrl = response.CoverImageUrl,
            CreatedDate = response.CreatedDate,
            Id = response.Id,
            Description = response.Description
        };
    }
}
