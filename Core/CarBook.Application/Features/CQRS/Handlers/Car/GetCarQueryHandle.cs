using System;
using CarBook.Application.Features.CQRS.Results.Car;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;


public class GetCarQueryHandle
{
    private readonly IRepository<Car> _repository;
    public GetCarQueryHandle(IRepository<Car> repository)
    {
        _repository = repository;
    }
    public async Task<List<GetCarQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetCarQueryResult
        {
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
