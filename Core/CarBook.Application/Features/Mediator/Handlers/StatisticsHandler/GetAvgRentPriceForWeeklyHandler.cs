using System;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterface;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandler;

public class GetAvgRentPriceForWeeklyHandler : IRequestHandler<GetAvgRentPriceForWeeklyQuery, GetAvgRentPriceForWeeklyResult>
{
    private readonly IStaticticRepository _staticticRepository;

    public GetAvgRentPriceForWeeklyHandler(IStaticticRepository staticticRepository)
    {
        this._staticticRepository = staticticRepository;
    }

    public async Task<GetAvgRentPriceForWeeklyResult> Handle(GetAvgRentPriceForWeeklyQuery request, CancellationToken cancellationToken)
    {
        var response = await _staticticRepository.GetAvgRentPriceForWeekly();
        return new GetAvgRentPriceForWeeklyResult
        {
            Amount = response
        };
    }
}
