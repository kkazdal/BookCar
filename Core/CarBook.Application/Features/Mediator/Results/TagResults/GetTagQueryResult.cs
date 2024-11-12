using System;

namespace CarBook.Application.Features.Mediator.Results.TagResults;

public class GetTagQueryResult
{
    public int Id { get; set; }
    public required string TagName { get; set; }
    public int BlogId { get; set; }
}
