using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FooterAddress;

public class RemoveFooterAddressCommand : IRequest
{
    public int Id { get; set; }

    public RemoveFooterAddressCommand(int id)
    {
        Id = id;
    }
}
