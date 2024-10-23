using System;

namespace CarBook.Application.Features.CQRS.Commands.About;

public class RemoveAboutCommands
{
    public int Id { get; set; }

    public RemoveAboutCommands(int id)
    {
        this.Id = id;
    }
}
