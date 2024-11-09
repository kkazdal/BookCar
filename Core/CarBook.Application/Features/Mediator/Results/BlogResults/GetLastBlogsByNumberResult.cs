using System;

namespace CarBook.Application.Features.Mediator.Results.BlogResults;

public class GetLastBlogsByNumberResult
{
    public int BlogId { get; set; }
    public string AuthorName { get; set; }
    public string Title { get; set; }
    public string CoverImageUrl { get; set; }
}
