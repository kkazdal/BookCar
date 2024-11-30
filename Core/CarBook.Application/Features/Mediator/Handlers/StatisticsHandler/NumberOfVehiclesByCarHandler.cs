using System;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterface;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandler;

public class NumberOfVehiclesByCarHandler : IRequestHandler<NumberOfVehiclesByCarQuery, List<NumberOfVehiclesByCarResult>>
{
    private readonly IStaticticRepository _staticticRepository;

    public NumberOfVehiclesByCarHandler(IStaticticRepository staticticRepository)
    {
        _staticticRepository = staticticRepository;
    }

    public async Task<List<NumberOfVehiclesByCarResult>> Handle(NumberOfVehiclesByCarQuery request, CancellationToken cancellationToken)
    {
        return await _staticticRepository.GetNumberOfVehiclesByCar();
    }
}
