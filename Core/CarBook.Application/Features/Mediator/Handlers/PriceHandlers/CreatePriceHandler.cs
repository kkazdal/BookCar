using System;
using CarBook.Application.Features.Mediator.Commands.PriceCommands;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.PriceHandlers;

public class CreatePriceHandler : IRequestHandler<CreatePriceCommand>
{
    private readonly IRepository<Pricing> _repository;

    public CreatePriceHandler(IRepository<Pricing> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreatePriceCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(
            new Pricing()
            {
                Name = request.Name
            }
        );
    }
}
