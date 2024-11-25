using System;
using CarBook.Application.Features.Mediator.Results.CommentResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CommentQueries;

public class CommentListQuery : IRequest<List<CommentQueryResult>>
{
    public int BlogId { get; set; }

    public CommentListQuery(int blogId)
    {
        BlogId = blogId;
    }
}
