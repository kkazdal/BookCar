using System;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Results.Location;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers;

public class GetLocationHandler : IRequestHandler<GetLocationQuery, List<GetLocationResult>>
{
    private readonly IRepository<Location> _repository;

    public GetLocationHandler(IRepository<Location> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetLocationResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetAllAsync();
        return response.Select(x => new GetLocationResult
        {
            LocationId = x.LocationId,
            Name = x.Name
        }).ToList();
    }
}
