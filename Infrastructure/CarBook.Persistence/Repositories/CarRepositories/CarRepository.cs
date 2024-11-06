using System;
using CarBook.Application.Features.CQRS.Results.Car;
using CarBook.Application.Interfaces.CarRespositories;
using CarBook.CarBookDomain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

public class CarRepository : ICarRepository
{
    private readonly CarBookContext _carBookContext;

    public CarRepository(CarBookContext carBookContext)
    {
        _carBookContext = carBookContext;
    }

    public List<Car> GetCarListWithBrands()
    {
        var values = _carBookContext.Cars.Include(x => x.Brand).ToList();
        return values;
    }

    public List<GetLastCarsByNumber> GetTheLastCarsByNumber()
    {
        var carList = (from car in _carBookContext.Cars
                       join brand in _carBookContext.Brands
                       on car.BrandId equals brand.BrandId
                       orderby car.CarId descending
                       select new GetLastCarsByNumber
                       {
                           brandName = brand.Name,
                           Model = car.Model
                       }).ToList();

        return carList;
    }
}
