using System;

namespace CarBook.Application.Features.Mediator.Results.CommentResults;

public class CommentQueryResult
{
    public int CommentId { get; set; }
    public string Name { get; set; }
    public required string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public int BlogId { get; set; }
}
