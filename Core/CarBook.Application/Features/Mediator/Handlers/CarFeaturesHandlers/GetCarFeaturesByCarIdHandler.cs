using System;
using CarBook.Application.Features.Mediator.Queries.CarFeatures;
using CarBook.Application.Features.Mediator.Results.CarFeatures;
using CarBook.Application.Interfaces.CarFeaturesRepositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeaturesHandlers;

public class GetCarFeaturesByCarIdHandler : IRequestHandler<GetCarFeaturesByCarIdQuery, List<GetCarFeaturesByCarIdResult>>
{
    private readonly ICarFeatureRepository _carFeatureRepository;
    public GetCarFeaturesByCarIdHandler(ICarFeatureRepository carFeatureRepository)
    {
        _carFeatureRepository = carFeatureRepository;
    }

    public Task<List<GetCarFeaturesByCarIdResult>> Handle(GetCarFeaturesByCarIdQuery request, CancellationToken cancellationToken)
    {
        var response = _carFeatureRepository.getCarFeaturesByCarId(request.CarId);

        return response;
    }
}
