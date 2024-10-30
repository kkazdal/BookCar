using System;
using CarBook.Application.Features.Mediator.Results.PriceResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.PriceQueries;

public class GetPriceByIdQuery : IRequest<GetPriceByIdQueryResults>
{
    public int Id { get; set; }

    public GetPriceByIdQuery(int id)
    {
        Id = id;
    }
}
