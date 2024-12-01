using System;
using CarBook.Application.Features.Mediator.Results.ReviewsResults;
using CarBook.Application.Interfaces.ReviewRepositories;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.ReviewRepositories;

public class ReviewRepository : IReviewRepository
{
    private readonly CarBookContext carBookContext;

    public ReviewRepository(CarBookContext carBookContext)
    {
        this.carBookContext = carBookContext;
    }

    public List<GetReviewByCarIdResult> GetReviewByCarIdList(int carId)
    {
        var response = (from rew in carBookContext.Reviews
                        where rew.CarID == carId
                        select new GetReviewByCarIdResult
                        {
                            CarID = carId,
                            Comment = rew.Comment,
                            CustomerImage = rew.CustomerImage,
                            CustomerName = rew.CustomerName,
                            RaytingValue = rew.RaytingValue,
                            ReviewDate = rew.ReviewDate,
                            ReviewID = rew.ReviewID
                        }).ToList();

        return response;
    }
}
