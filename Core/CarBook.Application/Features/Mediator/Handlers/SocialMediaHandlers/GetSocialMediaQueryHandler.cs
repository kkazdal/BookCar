using System;
using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBook.Application.Features.Mediator.Results.SocialMedia;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
{
    private readonly IRepository<SocialMedia> _repository;

    public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
    {
        _repository = repository;
    }
    public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetAllAsync();
        return response.Select(x => new GetSocialMediaQueryResult
        {
            Icon = x.Icon,
            Name = x.Name,
            SocialMediaId = x.SocialMediaId,
            Url = x.Url
        }).ToList();
    }
}
