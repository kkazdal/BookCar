using System;
using CarBook.Application.Features.Mediator.Results.CarDescriptionResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries;

public class GetCarDescriptionQuery : IRequest<GetCarDescriptionResult>
{
    public int CarId { get; set; }

    public GetCarDescriptionQuery(int carId)
    {
        CarId = carId;
    }
}
