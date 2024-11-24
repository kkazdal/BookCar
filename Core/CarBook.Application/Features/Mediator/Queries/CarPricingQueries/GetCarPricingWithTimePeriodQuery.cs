using System;
using CarBook.Application.Features.Mediator.Results;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CarPricingQueries;

public class GetCarPricingWithTimePeriodQuery : IRequest<List<GetCarPricingWithTimePeriodQueryResult>>
{

}
