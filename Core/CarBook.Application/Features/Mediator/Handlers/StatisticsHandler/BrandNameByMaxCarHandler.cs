using System;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterface;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandler;

public class BrandNameByMaxCarHandler : IRequestHandler<BrandNameByMaxCarQuery, BrandNameByMaxCarResult>
{
    private readonly IStaticticRepository _staticticRepository;

    public BrandNameByMaxCarHandler(IStaticticRepository staticticRepository)
    {
        this._staticticRepository = staticticRepository;
    }
    public async Task<BrandNameByMaxCarResult> Handle(BrandNameByMaxCarQuery request, CancellationToken cancellationToken)
    {
        var result = await _staticticRepository.BrandNameByMaxCar();
        return new BrandNameByMaxCarResult
        {
            Name = result
        };
    }
}
