using System;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterface;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandler;

public class GetBlogTitleByMaxCommentHandler : IRequestHandler<GetBlogTitleByMaxCommentQuery, GetBlogTitleByMaxCommentResult>
{
    private readonly IStaticticRepository _staticticRepository;

    public GetBlogTitleByMaxCommentHandler(IStaticticRepository staticticRepository)
    {
        this._staticticRepository = staticticRepository;
    }
    public async Task<GetBlogTitleByMaxCommentResult> Handle(GetBlogTitleByMaxCommentQuery request, CancellationToken cancellationToken)
    {
        var result = await _staticticRepository.BlogTitleByMaxBlogComment();
        return new GetBlogTitleByMaxCommentResult
        {
            Name = result
        };
    }
}
