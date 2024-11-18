using System;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterface;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandler;

public class GetCarBrandAndModelByRentPriceDailyMinHandler : IRequestHandler<GetCarBrandAndModelByRentPriceDailyMinQuery, GetCarBrandAndModelByRentPriceDailyMinResult>
{
    private readonly IStaticticRepository _staticticRepository;

    public GetCarBrandAndModelByRentPriceDailyMinHandler(IStaticticRepository staticticRepository)
    {
        this._staticticRepository = staticticRepository;
    }

    public async Task<GetCarBrandAndModelByRentPriceDailyMinResult> Handle(GetCarBrandAndModelByRentPriceDailyMinQuery request, CancellationToken cancellationToken)
    {
        var response = await _staticticRepository.GetCarBrandAndModelByRentPriceDailyMin();
        return new GetCarBrandAndModelByRentPriceDailyMinResult
        {
            Amount = response
        };
    }
}
