using System;
using CarBook.Application.Features.CQRS.Commands.Car;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;


public class UpdateCarHandle
{
    private readonly IRepository<Car> _repository;
    public UpdateCarHandle(IRepository<Car> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateCarCommand command)
    {
        var values = await _repository.GetByIdAsync(command.CarId);
        values.Fuel = command.Fuel;
        values.Transmission = command.Transmission;
        values.BigImageUrl = command.BigImageUrl;
        values.BrandId = command.BrandId;
        values.CoverImageUrl = command.CoverImageUrl;
        values.Km = command.Km;
        values.Luggage = command.Luggage;
        values.Model = command.Model;
        values.Seat = command.Seat;
        await _repository.UpdateAsync(values);
    }

}
