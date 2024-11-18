using System;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterface;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandler;

public class GetAvgRentPriceForMontlyHandler : IRequestHandler<GetAvgRentPriceForMontlyQuery, GetAvgRentPriceForMontlyResult>
{
    private readonly IStaticticRepository _staticticRepository;

    public GetAvgRentPriceForMontlyHandler(IStaticticRepository staticticRepository)
    {
        this._staticticRepository = staticticRepository;
    }

    public async Task<GetAvgRentPriceForMontlyResult> Handle(GetAvgRentPriceForMontlyQuery request, CancellationToken cancellationToken)
    {
        var response = await _staticticRepository.GetAvgRentPriceForMontly();
        return new GetAvgRentPriceForMontlyResult
        {
            Amount = response
        };
    }

}
