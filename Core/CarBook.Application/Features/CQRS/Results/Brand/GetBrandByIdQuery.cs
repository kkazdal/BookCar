using System;

namespace CarBook.Application.Features.CQRS.Results.Brand;

public class GetBrandByIdQueryResult
{
    public int BrandId { get; set; }
    public string Name { get; set; }
}
