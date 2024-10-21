using System;

namespace CarBook.Application.Features.CQRS.Commands.About;

public class UpdateAboutCommands
{
    public int AboutId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}
