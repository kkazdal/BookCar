using System;
using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers;

public class RemoveServiceHandler : IRequestHandler<RemoveServiceCommand>
{
    private readonly IRepository<Service> _repository;

    public RemoveServiceHandler(IRepository<Service> repository)
    {
        _repository = repository;
    }


    public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.ServiceId);
        await _repository.RemoveAsync(response);
    }
}
