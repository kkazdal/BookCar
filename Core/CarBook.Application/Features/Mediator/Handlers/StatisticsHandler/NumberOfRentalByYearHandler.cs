using System;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterface;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandler;

public class NumberOfRentalByYearHandler : IRequestHandler<NumberOfRentalByYearQuery, List<NumberOfRentalByYearResult>>
{
    private readonly IStaticticRepository _staticticRepository;

    public NumberOfRentalByYearHandler(IStaticticRepository staticticRepository)
    {
        _staticticRepository = staticticRepository;
    }

    public async Task<List<NumberOfRentalByYearResult>> Handle(NumberOfRentalByYearQuery request, CancellationToken cancellationToken)
    {
        var response = await _staticticRepository.GetNumberOfRentalByYearResult();
        return response;
    }
}
