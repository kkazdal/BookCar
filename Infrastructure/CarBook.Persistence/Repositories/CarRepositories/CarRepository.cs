using System;
using CarBook.Application.Features.CQRS.Queries.Car;
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

    public async Task<List<GetCarsWithPricingModel>> GetCarsWithPricings()
    {
        var carList = await (from car in _carBookContext.Cars
                             join carPricing in _carBookContext.CarPricings
                             on car.CarId equals carPricing.CarId
                             join pricing in _carBookContext.Pricings
                             on carPricing.PricingId equals pricing.PricingId
                             join brand in _carBookContext.Brands
                             on car.BrandId equals brand.BrandId
                             select new GetCarsWithPricingModel
                             {
                                 CarId = car.CarId,
                                 CarModel = car.Model,
                                 Amount = carPricing.Amount,
                                 PricingName = pricing.Name,
                                 Image = car.CoverImageUrl,
                                 BrandName = brand.Name
                             }).ToListAsync();

        return carList;

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
                           Model = car.Model,
                           imageUrl = car.CoverImageUrl
                       }).ToList();

        return carList;
    }
}
