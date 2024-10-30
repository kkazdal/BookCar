using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.PriceCommands;

public class RemovePriceCommand : IRequest
{
    public int PricingId { get; set; }

    public RemovePriceCommand(int pricingId)
    {
        PricingId = pricingId;
    }
}
