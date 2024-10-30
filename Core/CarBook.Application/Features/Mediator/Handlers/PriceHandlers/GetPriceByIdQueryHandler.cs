using System;
using CarBook.Application.Features.Mediator.Queries.PriceQueries;
using CarBook.Application.Features.Mediator.Results.PriceResults;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.PriceHandlers;

public class GetPriceByIdQueryHandler : IRequestHandler<GetPriceByIdQuery, GetPriceByIdQueryResults>
{
    private readonly IRepository<Pricing> _repository;

    public GetPriceByIdQueryHandler(IRepository<Pricing> repository)
    {
        _repository = repository;
    }
    public async Task<GetPriceByIdQueryResults> Handle(GetPriceByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.Id);
        return new GetPriceByIdQueryResults
        {
            PricingId = response.PricingId,
            Name = response.Name,
        };
    }
}
