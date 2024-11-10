using System;
using CarBook.Application.Features.CQRS.Queries.Car;
using CarBook.Application.Interfaces.CarRespositories;

namespace CarBook.Application.Features.CQRS.Handlers.Car;

public class GetCarsWithPricingsHandler
{
    private readonly ICarRepository _carRepository;

    public GetCarsWithPricingsHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<List<GetCarsWithPricingModel>> handle()
    {
        var response = await _carRepository.GetCarsWithPricings();
        return response;
    }
}
