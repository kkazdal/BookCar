using System;
using CarBook.Application.Features.CQRS.Results.Car;
using CarBook.Application.Interfaces.CarRespositories;
namespace CarBook.Application.Features.CQRS.Handlers.Car;

public class GetCarsByNumberHandle
{
    private readonly ICarRepository _carRepository;

    public GetCarsByNumberHandle(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public List<GetLastCarsByNumber> Handle(int carNumber)
    {
        var response = _carRepository.GetTheLastCarsByNumber().Take(carNumber).ToList();
        return response;
    }
}
