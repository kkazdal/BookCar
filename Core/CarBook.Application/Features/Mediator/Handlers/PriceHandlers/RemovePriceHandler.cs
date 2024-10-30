using System;
using CarBook.Application.Features.Mediator.Commands.PriceCommands;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.PriceHandlers;

public class RemovePriceHandler : IRequestHandler<RemovePriceCommand>
{
    private readonly IRepository<Pricing> _repository;

    public RemovePriceHandler(IRepository<Pricing> repository)
    {
        _repository = repository;
    }


    public async Task Handle(RemovePriceCommand request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.PricingId);
        await _repository.RemoveAsync(response);
    }
}
