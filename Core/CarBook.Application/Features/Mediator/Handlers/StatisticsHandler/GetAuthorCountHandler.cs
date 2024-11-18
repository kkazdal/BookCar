using System;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterface;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandler;

public class GetAuthorCountHandler : IRequestHandler<GetAuthorCountQuery, GetAuthorCountResult>
{
    private readonly IStaticticRepository _staticticRepository;

    public GetAuthorCountHandler(IStaticticRepository staticticRepository)
    {
        this._staticticRepository = staticticRepository;
    }
    public async Task<GetAuthorCountResult> Handle(GetAuthorCountQuery request, CancellationToken cancellationToken)
    {
        var result = await _staticticRepository.GetAuthorCount();
        return new GetAuthorCountResult
        {
            count = result
        };
    }
}
