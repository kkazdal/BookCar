using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ServiceCommands;

public class RemoveServiceCommand : IRequest
{
    public int ServiceId { get; set; }

    public RemoveServiceCommand(int serviceId)
    {
        ServiceId = serviceId;
    }
}
