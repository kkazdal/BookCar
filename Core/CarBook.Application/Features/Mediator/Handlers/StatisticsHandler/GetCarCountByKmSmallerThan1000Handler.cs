using System;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterface;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandler;

public class GetCarCountByKmSmallerThan1000Handler : IRequestHandler<GetCarCountByKmSmallerThan1000Query, GetCarCountByKmSmallerThan1000Result>
{
    private readonly IStaticticRepository _staticticRepository;

    public GetCarCountByKmSmallerThan1000Handler(IStaticticRepository staticticRepository)
    {
        this._staticticRepository = staticticRepository;
    }

    public async Task<GetCarCountByKmSmallerThan1000Result> Handle(GetCarCountByKmSmallerThan1000Query request, CancellationToken cancellationToken)
    {
        var response = await _staticticRepository.GetCarCountByKmSmallerThan1000();
        return new GetCarCountByKmSmallerThan1000Result
        {
            count = response
        };
    }

}
