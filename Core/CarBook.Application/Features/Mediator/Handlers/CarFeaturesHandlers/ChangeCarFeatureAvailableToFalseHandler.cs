using System;
using CarBook.Application.Features.Mediator.Commands.CarFeaturesCommands;
using CarBook.Application.Interfaces.CarFeaturesRepositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeaturesHandlers;

public class ChangeCarFeatureAvailableToFalseHandler : IRequestHandler<ChangeCarFeatureAvailableToFalseCommand>
{
    private readonly ICarFeatureRepository _carFeatureRepository;

    public ChangeCarFeatureAvailableToFalseHandler(ICarFeatureRepository carFeatureRepository)
    {
        _carFeatureRepository = carFeatureRepository;
    }

    public async Task Handle(ChangeCarFeatureAvailableToFalseCommand request, CancellationToken cancellationToken)
    {
        _carFeatureRepository.ChangeCarFeatureAvailableToFalse(request.CarFeatureId);
    }
}
