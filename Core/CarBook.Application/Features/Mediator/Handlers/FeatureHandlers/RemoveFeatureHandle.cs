using System;
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;

public class RemoveFeatureHandle : IRequestHandler<RemoveFeatureCommand>
{
    private readonly IRepository<Feature> _repository;

    public RemoveFeatureHandle(IRepository<Feature> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
    {
        var feature = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(feature);
    }
}
