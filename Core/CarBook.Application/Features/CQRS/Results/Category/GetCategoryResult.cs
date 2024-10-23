using System;

namespace CarBook.Application.Features.CQRS.Results.Brand;

public class GetCategoryResult
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
}
