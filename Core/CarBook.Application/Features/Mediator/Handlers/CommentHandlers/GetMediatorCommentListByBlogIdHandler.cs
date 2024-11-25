using System;
using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResults;
using CarBook.Application.Interfaces.CommentRepositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers;

public class GetMediatorCommentListByBlogIdHandler : IRequestHandler<CommentListQuery, List<CommentQueryResult>>
{
    private readonly ICommentRepository _commentRepository;

    public GetMediatorCommentListByBlogIdHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<List<CommentQueryResult>> Handle(CommentListQuery request, CancellationToken cancellationToken)
    {
        var response = await _commentRepository.GetMediatorCommentListByBlogId(request.BlogId);
        return response.Select(x => new CommentQueryResult
        {
            Description = x.Description,
            BlogId = x.BlogId,
            CommentId = x.CommentId,
            CreatedDate = x.CreatedDate,
            Name = x.Name
        }).ToList();
    }
}
