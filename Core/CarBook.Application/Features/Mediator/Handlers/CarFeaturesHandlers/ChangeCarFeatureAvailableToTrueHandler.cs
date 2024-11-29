using System;
using CarBook.Application.Features.Mediator.Commands.CarFeaturesCommands;
using CarBook.Application.Interfaces.CarFeaturesRepositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeaturesHandlers;

public class ChangeCarFeatureAvailableToTrueHandler : IRequestHandler<ChangeCarFeatureAvailableToTrueCommand>
{
    private readonly ICarFeatureRepository _carFeatureRepository;

    public ChangeCarFeatureAvailableToTrueHandler(ICarFeatureRepository carFeatureRepository)
    {
        _carFeatureRepository = carFeatureRepository;
    }

    public async Task Handle(ChangeCarFeatureAvailableToTrueCommand request, CancellationToken cancellationToken)
    {
        _carFeatureRepository.ChangeCarFeatureAvailableToTrue(request.CarFeatureId);
    }
}
