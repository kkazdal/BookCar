using System;
using CarBook.Application.Features.CQRS.Queries.Car;
using CarBook.Application.Features.CQRS.Results.Car;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;


public class GetCarByIdQueryHandle
{
    private readonly IRepository<Car> _repository;
    public GetCarByIdQueryHandle(IRepository<Car> repository)
    {
        _repository = repository;
    }
    public async Task<GetCarByIdQueryResult> Handle(GetCarQueryByIdQuery query)
    {
        var values = await _repository.GetByIdAsync(query.Id);
        return new GetCarByIdQueryResult
        {
            BrandId = values.BrandId,
            BigImageUrl = values.BigImageUrl,
            CoverImageUrl = values.CoverImageUrl,
            Fuel = values.Fuel,
            CarId = values.CarId,
            Transmission = values.Transmission,
            Seat = values.Seat,
            Model = values.Model,
            Km = values.Km,
            Luggage = values.Luggage
        };
    }
}
