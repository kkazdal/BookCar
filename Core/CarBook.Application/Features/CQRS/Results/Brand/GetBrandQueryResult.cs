using System;

namespace CarBook.Application.Features.CQRS.Results.Brand;

public class GetBrandQueryResult
{
    public int BrandId { get; set; }
    public string Name { get; set; }
}
