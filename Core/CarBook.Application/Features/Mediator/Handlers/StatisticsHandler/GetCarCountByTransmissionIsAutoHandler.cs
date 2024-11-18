using System;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterface;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandler;

public class GetCarCountByTransmissionIsAutoHandler : IRequestHandler<GetCarCountByTransmissionIsAutoQuery, GetCarCountByTransmissionIsAutoResult>
{
    private readonly IStaticticRepository _staticticRepository;

    public GetCarCountByTransmissionIsAutoHandler(IStaticticRepository staticticRepository)
    {
        this._staticticRepository = staticticRepository;
    }

    public async Task<GetCarCountByTransmissionIsAutoResult> Handle(GetCarCountByTransmissionIsAutoQuery request, CancellationToken cancellationToken)
    {
        var response = await _staticticRepository.GetCarCountByTransmissionIsAuto();
        return new GetCarCountByTransmissionIsAutoResult
        {
            count = response
        };
    }

}
