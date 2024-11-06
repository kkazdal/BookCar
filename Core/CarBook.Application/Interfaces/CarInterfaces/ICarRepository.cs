using System;
using CarBook.Application.Features.CQRS.Results.Car;
using CarBook.CarBookDomain.Entities;

namespace CarBook.Application.Interfaces.CarRespositories;

public interface ICarRepository
{
    List<Car> GetCarListWithBrands();
    List<GetLastCarsByNumber> GetTheLastCarsByNumber();
}
