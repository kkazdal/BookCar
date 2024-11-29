using System;
using CarBook.Application.Features.Mediator.Results.CarFeatures;
using CarBook.Application.Interfaces.CarFeaturesRepositories;
using CarBook.CarBookDomain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CarFeaturesRepositories;

public class CarFeaturesRepository : ICarFeatureRepository
{
    private readonly CarBookContext _carBookContext;

    public CarFeaturesRepository(CarBookContext carBookContext)
    {
        this._carBookContext = carBookContext;
    }

    public void ChangeCarFeatureAvailableToFalse(int id)
    {
        var value = _carBookContext.CarFeatures.Where(item => item.CarFeatureId == id).FirstOrDefault();
        value.Available = false;
        _carBookContext.SaveChanges();
    }

    public void ChangeCarFeatureAvailableToTrue(int id)
    {
        var value = _carBookContext.CarFeatures.Where(item => item.CarFeatureId == id).FirstOrDefault();
        value.Available = true;
        _carBookContext.SaveChanges();
    }

    public void CreateCarFeatureByCar(CarFeature carFeature)
    {
        _carBookContext.CarFeatures.Add(carFeature);
        _carBookContext.SaveChanges();
    }

    public async Task<List<GetCarFeaturesByCarIdResult>> getCarFeaturesByCarId(int carId)
    {
        var response = await (from carFeature in _carBookContext.CarFeatures
                              where carFeature.CarId == carId
                              join feature in _carBookContext.Features
                              on carFeature.FeatureId equals feature.FeatureId
                              select new GetCarFeaturesByCarIdResult
                              {
                                  Available = carFeature.Available,
                                  CarFeatureId = carFeature.CarFeatureId,
                                  CarId = carFeature.CarId,
                                  FeatureId = feature.FeatureId,
                                  FeatureName = feature.Name
                              }).ToListAsync();

        return response;
    }
}
