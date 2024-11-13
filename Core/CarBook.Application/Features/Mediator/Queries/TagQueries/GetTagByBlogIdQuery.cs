using System;
using CarBook.Application.Features.Mediator.Results.TagResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.TagQueries;

public class GetTagByBlogIdQuery : IRequest<List<GetTagByBlogIdResult>>
{
    public int BlogId { get; set; }

    public GetTagByBlogIdQuery(int blogId)
    {
        BlogId = blogId;
    }
}
