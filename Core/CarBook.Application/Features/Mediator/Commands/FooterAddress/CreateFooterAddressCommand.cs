using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FooterAddress;

public class CreateFooterAddressCommand : IRequest
{
    public string Description { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string EMail { get; set; }
}
