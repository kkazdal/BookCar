using System;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterface;
using CarBook.CarBookDomain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.StatisticsRepositories;

public class StatisticRepository : IStaticticRepository
{
    private readonly CarBookContext _carBookContext;

    public StatisticRepository(CarBookContext carBookContext)
    {
        _carBookContext = carBookContext;
    }

    public async Task<string> BlogTitleByMaxBlogComment()
    {
        var result = await (from comment in _carBookContext.Comments
                            join blog in _carBookContext.Blogs
                            on comment.BlogId equals blog.Id
                            group comment by blog.Title into grp
                            orderby grp.Count() descending
                            select new
                            {
                                blogTitle = grp.Key
                            }).FirstOrDefaultAsync();

        if (result == null)
            return "";

        return result.blogTitle;
    }

    public async Task<string> BrandNameByMaxCar()
    {
        var result = await (from car in _carBookContext.Cars
                            join brand in _carBookContext.Brands
                            on car.BrandId equals brand.BrandId
                            group car by brand.Name into grp
                            orderby grp.Count() descending
                            select new
                            {
                                brandName = grp.Key,
                            }).FirstOrDefaultAsync();

        if (result == null)
            return "";

        return result.brandName;
    }

    public async Task<int> GetAuthorCount()
    {
        var count = await (from location in _carBookContext.Authors
                           select location).CountAsync();
        return count;
    }

    public async Task<decimal> GetAvgRentPriceForDaily()
    {
        var result = await (from pricing in _carBookContext.Pricings
                            join carPricing in _carBookContext.CarPricings
                            on pricing.PricingId equals carPricing.PricingId
                            where pricing.Name == "Günlük"
                            group carPricing by pricing.PricingId into g
                            select new
                            {
                                TotalAmount = g.Sum(c => c.Amount),
                                TotalCount = g.Count()
                            }).FirstOrDefaultAsync();

        if (result == null)
            return 0;

        return result.TotalAmount / result.TotalCount;
    }

    public async Task<decimal> GetAvgRentPriceForMontly()
    {
        var result = await (from pricing in _carBookContext.Pricings
                            join carPricing in _carBookContext.CarPricings
                            on pricing.PricingId equals carPricing.PricingId
                            where pricing.Name == "Aylik"
                            group carPricing by pricing.PricingId into g
                            select new
                            {
                                TotalAmount = g.Sum(c => c.Amount),
                                TotalCount = g.Count()
                            }).FirstOrDefaultAsync();

        if (result == null)
            return 0;

        return result.TotalAmount / result.TotalCount;
    }

    public async Task<decimal> GetAvgRentPriceForWeekly()
    {
        var result = await (from pricing in _carBookContext.Pricings
                            join carPricing in _carBookContext.CarPricings
                            on pricing.PricingId equals carPricing.PricingId
                            where pricing.Name == "Haftalik"
                            group carPricing by pricing.PricingId into g
                            select new
                            {
                                TotalAmount = g.Sum(c => c.Amount),
                                TotalCount = g.Count()
                            }).FirstOrDefaultAsync();

        if (result == null)
            return 0;

        return result.TotalAmount / result.TotalCount;
    }

    public async Task<int> GetBlogCount()
    {
        var count = await (from location in _carBookContext.Blogs
                           select location).CountAsync();
        return count;
    }

    public async Task<int> GetBrandCount()
    {
        var count = await (from location in _carBookContext.Brands
                           select location).CountAsync();
        return count;
    }

    public async Task<decimal> GetCarBrandAndModelByRentPriceDailyMax()
    {
        var result = await (from car in _carBookContext.Cars
                            join carPricing in _carBookContext.CarPricings
                            on car.CarId equals carPricing.CarId
                            group car by carPricing.Amount into grp
                            orderby grp.Key descending
                            select new
                            {
                                Amount = grp.Key
                            }).FirstOrDefaultAsync();

        if (result == null)
            return 0;

        return result.Amount;
    }

    public async Task<decimal> GetCarBrandAndModelByRentPriceDailyMin()
    {
        var result = await (from car in _carBookContext.Cars
                            join carPricing in _carBookContext.CarPricings
                            on car.CarId equals carPricing.CarId
                            group car by carPricing.Amount into grp
                            orderby grp.Key ascending
                            select new
                            {
                                Amount = grp.Key
                            }).FirstOrDefaultAsync();

        if (result == null)
            return 0;

        return result.Amount;
    }

    public async Task<int> GetCarCountByFuelElectric()
    {
        var result = await (from car in _carBookContext.Cars
                            where car.Fuel.ToLower() == "elektrik"
                            select car).CountAsync();

        return result;
    }

    public async Task<int> GetCarCountByFuelGasolineOrDiesel()
    {
        var result = await (from car in _carBookContext.Cars
                            where car.Fuel.ToLower() == "benzin" || car.Fuel.ToLower() == "dizel"
                            select car).CountAsync();

        return result;
    }

    public async Task<int> GetCarCountByKmSmallerThan1000()
    {
        var result = await (from car in _carBookContext.Cars
                            where car.Km < 100000
                            select car).CountAsync();

        return result;
    }

    public async Task<int> GetCarCountByTransmissionIsAuto()
    {
        var result = await (from car in _carBookContext.Cars
                            where car.Transmission.ToLower().Contains("otomatik")
                            select car).CountAsync();

        return result;
    }

    public async Task<GetLocationCountResult> GetLocationCount()
    {
        var count = await (from location in _carBookContext.Locations
                           select location).CountAsync();
        return new GetLocationCountResult
        {
            count = count
        };
    }
}
