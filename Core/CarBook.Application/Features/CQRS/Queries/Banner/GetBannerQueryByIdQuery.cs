using System;

namespace CarBook.Application.Features.CQRS.Results.Banner;

public class GetBannerQueryByIdQuery
{
    public int id { get; set; }

    public GetBannerQueryByIdQuery(int id)
    {
        this.id = id;
    }
}
