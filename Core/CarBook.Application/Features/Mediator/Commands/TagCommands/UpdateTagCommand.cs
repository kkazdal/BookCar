using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TagCommands;

public class UpdateTagCommand : IRequest
{
    public int Id { get; set; }
    public string TagName { get; set; }
    
}
