using System;
using CarBook.Application.Features.Mediator.Results.CarFeatures;
using CarBook.CarBookDomain.Entities;

namespace CarBook.Application.Interfaces.CarFeaturesRepositories;

public interface ICarFeatureRepository
{
    Task<List<GetCarFeaturesByCarIdResult>> getCarFeaturesByCarId(int carId);
    void ChangeCarFeatureAvailableToFalse(int id);
    void ChangeCarFeatureAvailableToTrue(int id);
    void CreateCarFeatureByCar(CarFeature carFeature);
}
