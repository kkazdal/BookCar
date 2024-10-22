using System;
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
}
