using System;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterface;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandler;

public class GetAvgRentPriceForDailyHandler : IRequestHandler<GetAvgRentPriceForDailyQuery, GetAvgRentPriceForDailyResult>
{
    private readonly IStaticticRepository _staticticRepository;

    public GetAvgRentPriceForDailyHandler(IStaticticRepository staticticRepository)
    {
        this._staticticRepository = staticticRepository;
    }

    public async Task<GetAvgRentPriceForDailyResult> Handle(GetAvgRentPriceForDailyQuery request, CancellationToken cancellationToken)
    {
        var response = await _staticticRepository.GetAvgRentPriceForDaily();
        return new GetAvgRentPriceForDailyResult
        {
            Amount = response
        };
    }
}
