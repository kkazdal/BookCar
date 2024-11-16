using System;

namespace CarBook.Application.Features.Mediator.Results.BlogResults;

public class GetBlogsWithAuthorResult
{
    public int BlogId { get; set; }
    public int AuthorId { get; set; }
    public required string AuthorName { get; set; }
    public DateTime CreatedDate { get; set; }
    public required string BlogTitle { get; set; }
    public required string ImageUrl { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }

}
