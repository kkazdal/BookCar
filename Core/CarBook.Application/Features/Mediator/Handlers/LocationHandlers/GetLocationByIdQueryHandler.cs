using System;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Results.Location;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;


public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
{
    private readonly IRepository<Location> _repository;

    public GetLocationByIdQueryHandler(IRepository<Location> repository)
    {
        _repository = repository;
    }

    public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.Id);
        return new GetLocationByIdQueryResult
        {
            LocationId = response.LocationId,
            Name = response.Name
        };
    }
}
