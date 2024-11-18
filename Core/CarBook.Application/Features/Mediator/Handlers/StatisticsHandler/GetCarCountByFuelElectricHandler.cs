using System;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterface;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandler;

public class GetCarCountByFuelElectricHandler : IRequestHandler<GetCarCountByFuelElectricQuery, GetCarCountByFuelElectricResult>
{
    private readonly IStaticticRepository _staticticRepository;

    public GetCarCountByFuelElectricHandler(IStaticticRepository staticticRepository)
    {
        this._staticticRepository = staticticRepository;
    }

    public async Task<GetCarCountByFuelElectricResult> Handle(GetCarCountByFuelElectricQuery request, CancellationToken cancellationToken)
    {
        var response = await _staticticRepository.GetCarCountByFuelElectric();
        return new GetCarCountByFuelElectricResult
        {
            count = response
        };
    }
}
