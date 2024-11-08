using System;

namespace CarBook.Application.Features.Mediator.Results.AuthorResults;

public class GetQueryAuthorByIdResult
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
}
