using System;
using CarBook.Application.Interfaces.CarRespositories;

namespace CarBook.Application.Features.CQRS.Handlers.Car;

public class GetCarListWithBrandHandle
{
    private readonly ICarRepository _repository;
    public GetCarListWithBrandHandle(ICarRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<GetCarListWithBrandsResult>> Handle()
    {
        var values = _repository.GetCarListWithBrands();
        return values.Select(x => new GetCarListWithBrandsResult
        {
            BrandName = x.Brand.Name,
            BrandId = x.BrandId,
            BigImageUrl = x.BigImageUrl,
            CarId = x.CarId,
            CoverImageUrl = x.CoverImageUrl,
            Fuel = x.Fuel,
            Km = x.Km,
            Luggage = x.Luggage,
            Model = x.Model,
            Seat = x.Seat,
            Transmission = x.Transmission
        }).ToList();
    }
}
