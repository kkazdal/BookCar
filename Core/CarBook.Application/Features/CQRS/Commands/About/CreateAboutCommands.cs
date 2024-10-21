using System;

namespace CarBook.Application.Features.CQRS.Commands.About;

public class CreateAboutCommands
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}
