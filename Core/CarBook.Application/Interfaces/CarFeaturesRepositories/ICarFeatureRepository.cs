using System;
using CarBook.Application.Features.Mediator.Results.CarFeatures;

namespace CarBook.Application.Interfaces.CarFeaturesRepositories;

public interface ICarFeatureRepository
{
    Task<List<GetCarFeaturesByCarIdResult>> getCarFeaturesByCarId(int carId);
}
