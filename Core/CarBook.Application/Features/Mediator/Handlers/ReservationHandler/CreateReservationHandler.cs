using System;
using CarBook.Application.Features.Mediator.Commands.ReservationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandler;

public class CreateReservationHandler : IRequestHandler<CreateReservationCommand>
{
    private readonly IRepository<Reservation> _repository;

    public CreateReservationHandler(IRepository<Reservation> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Reservation
        {
            Age = request.Age,
            CarId = request.CarID,
            Description = request.Description,
            DriverLicenceYear = request.DriverLicenseYear,
            DropOffLocationId = request.DropOffLocationID,
            Email = request.Email,
            Name = request.Name,
            Phone = request.Phone,
            PickUpLocationId = request.PickUpLocationID,
            Surname = request.Surname,
            Status = "Rezervasyon Alındı"
        });
    }
}
