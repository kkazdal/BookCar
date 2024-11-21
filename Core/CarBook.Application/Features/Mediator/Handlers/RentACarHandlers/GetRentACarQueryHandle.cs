using System;
using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using CarBook.Application.Features.Mediator.Results.RentACarResults;
using CarBook.Application.Interfaces.RentACarInterface;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.RentACarHandlers;

public class GetRentACarQueryHandle : IRequestHandler<GetRentACarQuery, List<GetRentACarResult>>
{
    private readonly IRentACarRepository _rentACarRepository;

    public GetRentACarQueryHandle(IRentACarRepository rentACarRepository)
    {
        _rentACarRepository = rentACarRepository;
    }

    async Task<List<GetRentACarResult>> IRequestHandler<GetRentACarQuery, List<GetRentACarResult>>.Handle(GetRentACarQuery request, CancellationToken cancellationToken)
    {
        var values = await _rentACarRepository.GetByFilterAsync(x => x.LocationId == request.LocationId && x.Available == true);
        var results = values.Select(y => new GetRentACarResult
        {
            CarId = y.CarId,
            Brand = y.Car.Brand.Name,
            Model = y.Car.Model,
            CoverImageUrl = y.Car.CoverImageUrl
        }).ToList();
        return results;
    }
}
