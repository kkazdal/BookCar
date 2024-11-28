using System;
using CarBook.Application.Features.Mediator.Results.CarFeatures;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CarFeatures;

public class GetCarFeaturesByCarIdQuery : IRequest<List<GetCarFeaturesByCarIdResult>>
{
    public int CarId { get; set; }

    public GetCarFeaturesByCarIdQuery(int carId)
    {
        CarId = carId;
    }
}
