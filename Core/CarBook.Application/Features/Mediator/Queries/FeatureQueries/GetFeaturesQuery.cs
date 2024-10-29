using System;
using CarBook.Application.Features.Mediator.Results;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.FeatureQueries;

public class GetFeaturesQuery : IRequest<List<GetFeatureQueryResult>>
{

}
