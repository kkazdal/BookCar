using System;
using CarBook.Application.Features.Mediator.Queries.PriceQueries;
using CarBook.Application.Features.Mediator.Results.PriceResults;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.PriceHandlers;

public class GetPriceQueryHandler : IRequestHandler<GetPriceQuery, List<GetPriceQueryResult>>
{
    private readonly IRepository<Pricing> _repository;

    public GetPriceQueryHandler(IRepository<Pricing> repository)
    {
        _repository = repository;
    }
    public async Task<List<GetPriceQueryResult>> Handle(GetPriceQuery request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetAllAsync();
        return response.Select(x => new GetPriceQueryResult
        {
            PricingId = x.PricingId,
            Name = x.Name,
        }).ToList();
    }
}
