using System;

namespace CarBook.Application.Features.Mediator.Results.TagResults;

public class GetTagByBlogIdResult
{
    public int TagId { get; set; }
    public int BlogId { get; set; }
    public required string TagName { get; set; }
}
