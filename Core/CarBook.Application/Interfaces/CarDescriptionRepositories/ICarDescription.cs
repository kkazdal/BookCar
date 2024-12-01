using System;
using CarBook.Application.Features.Mediator.Results.CarDescriptionResults;

namespace CarBook.Application.Interfaces.CarDescriptionRepositories;

public interface ICarDescriptionRepository
{
    Task<GetCarDescriptionResult> GetDescriptionByCarId(int carId);
}
