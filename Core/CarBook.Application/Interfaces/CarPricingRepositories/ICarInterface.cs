using System;
using CarBook.Application.ViewModels;
using CarBook.CarBookDomain.Entities;

namespace CarBook.Application.Interfaces.CarInterfaces;

public interface ICarPricingRepository
{
    Task<List<CarPricingViewModel>> GetCarPricingWithTimePeriod();
}
