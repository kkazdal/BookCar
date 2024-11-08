using System;
using MediatR;

namespace CarBook.Application.Features.CQRS.Commands.About;

public class RemoveAboutCommands : IRequest
{
    public int Id { get; set; }

    public RemoveAboutCommands(int id)
    {
        this.Id = id;
    }
}
