using System;
using CarBook.Application.Features.Mediator.Commands.PriceCommands;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.PriceHandlers;

public class UpdatePriceHandler : IRequestHandler<UpdatePriceCommand>
{
    private readonly IRepository<Pricing> _repository;

    public UpdatePriceHandler(IRepository<Pricing> repository)
    {
        _repository = repository;
    }



    public async Task Handle(UpdatePriceCommand request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.PricingId);
        response.Name = request.Name;

        await _repository.UpdateAsync(response);
    }
}
