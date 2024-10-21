using System;
using CarBook.Application.Features.CQRS.Commands.Car;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;


public class CreateCarHandle
{
    private readonly IRepository<Car> _repository;

    public CreateCarHandle(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateCarCommand command)
    {
        await _repository.CreateAsync(new Car
        {
            BigImageUrl = command.BigImageUrl,
            Luggage = command.Luggage,
            Km = command.Km,
            Model = command.Model,
            Seat = command.Seat,
            Transmission = command.Transmission,
            CoverImageUrl = command.CoverImageUrl,
            BrandId = command.BrandId,
            Fuel = command.Fuel
        });
    }
}
