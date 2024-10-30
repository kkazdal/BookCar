using System;
using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers;

public class CreateLocationHandler : IRequestHandler<CreateLocationCommand>
{
    private readonly IRepository<Location> _repository;

    public CreateLocationHandler(IRepository<Location> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Location
        {
            Name = request.Name
        });
    }
}
