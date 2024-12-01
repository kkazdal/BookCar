using System;
using CarBook.Application.Features.Mediator.Results.ReviewsResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.ReviewQueries;

public class GetReviewByCarIdQuery : IRequest<List<GetReviewByCarIdResult>>
{
    public int CarId { get; set; }

    public GetReviewByCarIdQuery(int carId)
    {
        CarId = carId;
    }
}
