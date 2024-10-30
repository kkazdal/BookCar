using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.PriceCommands;

public class UpdatePriceCommand : IRequest
{
    public int PricingId { get; set; }
    public string Name { get; set; }
}
