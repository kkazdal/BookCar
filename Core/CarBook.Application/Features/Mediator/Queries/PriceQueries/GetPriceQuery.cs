using System;
using CarBook.Application.Features.Mediator.Results.PriceResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.PriceQueries;

public class GetPriceQuery : IRequest<List<GetPriceQueryResult>>
{

}
