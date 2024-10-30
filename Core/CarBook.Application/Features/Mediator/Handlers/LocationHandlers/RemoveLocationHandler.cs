using System;
using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers;

public class RemoveLocationHandler : IRequestHandler<RemoveLocationCommand>
{
    private readonly IRepository<Location> _repository;

    public RemoveLocationHandler(IRepository<Location> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(response);
    }
}
