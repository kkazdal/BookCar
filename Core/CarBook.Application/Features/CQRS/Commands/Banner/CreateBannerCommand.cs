using System;

namespace CarBook.Application.Features.CQRS.Commands.Banner;

public class CreateBannerCommand
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string VideoDescription { get; set; }
    public string VideoUrl { get; set; }
}
