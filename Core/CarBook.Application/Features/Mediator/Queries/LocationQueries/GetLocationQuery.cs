using System;
using CarBook.Application.Features.Mediator.Results.Location;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.LocationQueries;

public class GetLocationQuery : IRequest<List<GetLocationResult>>
{

}
