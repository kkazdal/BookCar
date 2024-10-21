using System;

namespace CarBook.Application.Features.CQRS.Results.AboutResult;

public class GetAboutByIdQueryResult
{
    public int AboutId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}
