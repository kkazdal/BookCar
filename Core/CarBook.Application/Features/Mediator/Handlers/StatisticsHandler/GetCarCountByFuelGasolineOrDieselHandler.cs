using System;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterface;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandler;

public class GetCarCountByFuelGasolineOrDieselHandler : IRequestHandler<GetCarCountByFuelGasolineOrDieselQuery, GetCarCountByFuelGasolineOrDieselResult>
{
    private readonly IStaticticRepository _staticticRepository;

    public GetCarCountByFuelGasolineOrDieselHandler(IStaticticRepository staticticRepository)
    {
        this._staticticRepository = staticticRepository;
    }

    public async Task<GetCarCountByFuelGasolineOrDieselResult> Handle(GetCarCountByFuelGasolineOrDieselQuery request, CancellationToken cancellationToken)
    {
        var response = await _staticticRepository.GetCarCountByFuelGasolineOrDiesel();
        return new GetCarCountByFuelGasolineOrDieselResult
        {
            count = response
        };
    }
}
