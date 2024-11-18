using System;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterface;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandler;

public class GetCarBrandAndModelByRentPriceDailyMaxHandler : IRequestHandler<GetCarBrandAndModelByRentPriceDailyMaxQuery, GetCarBrandAndModelByRentPriceDailyMaxResult>
{
    private readonly IStaticticRepository _staticticRepository;

    public GetCarBrandAndModelByRentPriceDailyMaxHandler(IStaticticRepository staticticRepository)
    {
        this._staticticRepository = staticticRepository;
    }

    public async Task<GetCarBrandAndModelByRentPriceDailyMaxResult> Handle(GetCarBrandAndModelByRentPriceDailyMaxQuery request, CancellationToken cancellationToken)
    {
        var response = await _staticticRepository.GetCarBrandAndModelByRentPriceDailyMax();
        return new GetCarBrandAndModelByRentPriceDailyMaxResult
        {
            Amount = response
        };
    }
}
