using System;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.StatisticsQueries;

public class GetCarCountByKmSmallerThan1000Query : IRequest<GetCarCountByKmSmallerThan1000Result>
{

}
