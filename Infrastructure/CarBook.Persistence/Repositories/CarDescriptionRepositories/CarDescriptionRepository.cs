using System;
using CarBook.Application.Features.Mediator.Results.CarDescriptionResults;
using CarBook.Application.Interfaces.CarDescriptionRepositories;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CarDescriptionRepositories;

public class CarDescriptionRepository : ICarDescriptionRepository
{
    private readonly CarBookContext _carBookContext;

    public CarDescriptionRepository(CarBookContext carBookContext)
    {
        _carBookContext = carBookContext;
    }

    public async Task<GetCarDescriptionResult> GetDescriptionByCarId(int carId)
    {
        var response = await (from carDescription in _carBookContext.CarDescriptions
                              where carDescription.CarId == carId
                              select new GetCarDescriptionResult
                              {
                                  CarDescriptionID = carDescription.CarDescriptionId,
                                  CarID = carDescription.CarId,
                                  Details = carDescription.Details
                              }).FirstOrDefaultAsync();

        return response;
    }
}
