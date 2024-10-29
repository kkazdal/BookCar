using System;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Results;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;

public class GetFeatureQueryHandler : IRequestHandler<GetFeaturesQuery, List<GetFeatureQueryResult>>
{
    private readonly IRepository<Feature> _repository;

    public GetFeatureQueryHandler(IRepository<Feature> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetFeatureQueryResult>> Handle(GetFeaturesQuery request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetAllAsync();
        return response.Select(x => new GetFeatureQueryResult
        {
            Id = x.FeatureId,
            Name = x.Name
        }).ToList();
    }
}
