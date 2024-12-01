using System;
using CarBook.Application.Features.Mediator.Results.ReviewsResults;

namespace CarBook.Application.Interfaces.ReviewRepositories;

public interface IReviewRepository
{
    List<GetReviewByCarIdResult> GetReviewByCarIdList(int carId);
}
