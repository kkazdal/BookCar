using System;
using CarBook.Application.Features.Mediator.Commands.CarFeaturesCommands;
using CarBook.Application.Interfaces.CarFeaturesRepositories;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeaturesHandlers;

public class CreateCarFeatureByCarHandle : IRequestHandler<CreateCarFeatureByCarCommand>
{
    private readonly ICarFeatureRepository _carFeatureRepository;

    public CreateCarFeatureByCarHandle(ICarFeatureRepository carFeatureRepository)
    {
        _carFeatureRepository = carFeatureRepository;
    }

    public async Task Handle(CreateCarFeatureByCarCommand request, CancellationToken cancellationToken)
    {
        _carFeatureRepository.CreateCarFeatureByCar(new CarFeature
        {
            Available = false,
            CarId = request.CarId,
            FeatureId = request.FeatureId
        });
    }
}
