using System;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterface;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandler;

public class GetTotalBlogNumberHandler : IRequestHandler<GetTotalBlogNumberQuery, GetTotalBlogNumberResult>
{
    private readonly IStaticticRepository _staticticRepository;

    public GetTotalBlogNumberHandler(IStaticticRepository staticticRepository)
    {
        _staticticRepository = staticticRepository;
    }

    public async Task<GetTotalBlogNumberResult> Handle(GetTotalBlogNumberQuery request, CancellationToken cancellationToken)
    {
        var result = await _staticticRepository.GetBlogCount();
        return new GetTotalBlogNumberResult
        {
            BlogNumber = result
        };
    }
}
