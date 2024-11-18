using System;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.GetLocationCountHandle;

public class GetStatisticsCarCountHandle : IRequestHandler<GetStatisticsCarCountQuery, GetStatisticsCarCountResult>
{
    private readonly IRepository<Car> _carRepository;

    public GetStatisticsCarCountHandle(IRepository<Car> carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<GetStatisticsCarCountResult> Handle(GetStatisticsCarCountQuery request, CancellationToken cancellationToken)
    {
        var response = (await _carRepository.GetAllAsync()).Count();
        return new GetStatisticsCarCountResult
        {
            count = response
        };
    }
}
