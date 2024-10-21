using System;

namespace CarBook.Application.Features.CQRS.Results.Brand;

public class GetBrandQueryByIdQuery
{
    public int id { get; set; }
    public GetBrandQueryByIdQuery(int id)
    {
        this.id = id;
    }
}
