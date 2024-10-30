using System;
using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers;

public class UpdateServiceHandler : IRequestHandler<UpdateServiceCommand>
{
    private readonly IRepository<Service> _repository;

    public UpdateServiceHandler(IRepository<Service> repository)
    {
        _repository = repository;
    }



    public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.ServiceId);
        response.Description = request.Description;
        response.IconUrl = request.IconUrl;
        response.Title = request.Title;

        await _repository.UpdateAsync(response);
    }
}