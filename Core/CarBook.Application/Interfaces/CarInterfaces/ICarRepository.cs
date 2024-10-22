using System;
using CarBook.CarBookDomain.Entities;

namespace CarBook.Application.Interfaces.CarRespositories;

public interface ICarRepository
{
    List<Car> GetCarListWithBrands();
}
