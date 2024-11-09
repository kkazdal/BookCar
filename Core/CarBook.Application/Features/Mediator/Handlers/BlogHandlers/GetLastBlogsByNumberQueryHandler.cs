using System;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogRepositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class GetLastBlogsByNumberQueryHandler : IRequestHandler<GetLastBlogsQueryByNumber, List<GetLastBlogsByNumberResult>>
{
    private readonly IBlogRepository _blogRepository;

    public GetLastBlogsByNumberQueryHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<List<GetLastBlogsByNumberResult>> Handle(GetLastBlogsQueryByNumber request, CancellationToken cancellationToken)
    {
        var response = await _blogRepository.GetBlogAndAuthorName();
        return response.Take(request.BlogNumber).ToList();
    }
}
