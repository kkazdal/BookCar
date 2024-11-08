using System;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetQueryBlogResult>>
{
    private readonly IRepository<Blog> repository;

    public GetBlogQueryHandler(IRepository<Blog> repository)
    {
        this.repository = repository;
    }

    public async Task<List<GetQueryBlogResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
    {
        var response = await repository.GetAllAsync();
        return response.Select(x => new GetQueryBlogResult
        {
            AuthorId = x.AuthorId,
            CategoryId = x.CategoryId,
            CoverImageUrl = x.CoverImageUrl,
            CreatedDate = x.CreatedDate,
            Id = x.Id,
            Title = x.Title
        }).ToList();
    }
}
