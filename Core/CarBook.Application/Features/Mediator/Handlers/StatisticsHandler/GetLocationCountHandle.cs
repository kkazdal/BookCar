using System;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterface;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandler;

public class GetLocationCountHandle : IRequestHandler<GetLocationCountQuery, GetLocationCountResult>
{
    private readonly IStaticticRepository _staticticRepository;

    public GetLocationCountHandle(IStaticticRepository staticticRepository)
    {
        this._staticticRepository = staticticRepository;
    }

    public async Task<GetLocationCountResult> Handle(GetLocationCountQuery request, CancellationToken cancellationToken)
    {
        GetLocationCountResult result = await _staticticRepository.GetLocationCount();
        return result;
    }
}
