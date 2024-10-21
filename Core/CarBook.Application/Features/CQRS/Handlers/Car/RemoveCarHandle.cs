using System;
using CarBook.Application.Features.CQRS.Commands.Car;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;


public class RemoveCarHandle
{
    private readonly IRepository<Car> _repository;
    public RemoveCarHandle(IRepository<Car> repository)
    {
        _repository = repository;
    }
    public async Task Handle(RemoveCarCommand command)
    {
        var value = await _repository.GetByIdAsync(command.Id);
        await _repository.RemoveAsync(value);
    }
}
