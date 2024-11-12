using System;

namespace CarBook.Application.Features.Mediator.Results.TagResults;

public class GetTagByIdQueryResult
{
    public int Id { get; set; }
    public required string TagName { get; set; }
}
