using System;
using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers;

public class UpdateLocationHandler : IRequestHandler<UpdateLocationCommand>
{
    private readonly IRepository<Location> _repository;

    public UpdateLocationHandler(IRepository<Location> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.Id);
        response.Name = request.Name;

        await _repository.UpdateAsync(response);
    }
}
