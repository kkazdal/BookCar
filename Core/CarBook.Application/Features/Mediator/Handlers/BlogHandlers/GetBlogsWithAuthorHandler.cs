using System;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogRepositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class GetBlogsWithAuthorHandler : IRequestHandler<GetBlogsWithAuthorQuery, List<GetBlogsWithAuthorResult>>
{
    private readonly IBlogRepository _blogRepository;

    public GetBlogsWithAuthorHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<List<GetBlogsWithAuthorResult>> Handle(GetBlogsWithAuthorQuery request, CancellationToken cancellationToken)
    {
        var response = await _blogRepository.GetBlogsWithAuthorList();
        return response;
    }
}
