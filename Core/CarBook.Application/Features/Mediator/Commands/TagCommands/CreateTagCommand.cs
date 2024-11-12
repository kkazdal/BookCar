using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TagCommands;

public class CreateTagCommand : IRequest
{
    public required string TagName { get; set; }
    public int BlogId { get; set; }
}
