using System;
using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Features.Mediator.Results.ReviewsResults;
using CarBook.Application.Interfaces.ReviewRepositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers;

public class GetReviewByCarIdHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdResult>>
{
    private readonly IReviewRepository reviewRepository;

    public GetReviewByCarIdHandler(IReviewRepository reviewRepository)
    {
        this.reviewRepository = reviewRepository;
    }

    public async Task<List<GetReviewByCarIdResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
    {
        var response = reviewRepository.GetReviewByCarIdList(request.CarId);
        return response;
    }
}
