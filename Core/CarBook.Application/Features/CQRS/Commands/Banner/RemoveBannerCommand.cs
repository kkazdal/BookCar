using System;

namespace CarBook.Application.Features.CQRS.Commands.Banner;

public class RemoveBannerCommand
{
    public int id { get; set; }

    public RemoveBannerCommand(int id)
    {
        this.id = id;
    }
}
