using System;
using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBook.Application.Features.Mediator.Results.SocialMedia;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
{
    private readonly IRepository<SocialMedia> _repository;

    public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
    {
        _repository = repository;
    }

    public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.Id);
        return new GetSocialMediaByIdQueryResult
        {
            SocialMediaId = response.SocialMediaId,
            Icon = response.Icon,
            Name = response.Name,
            Url = response.Url
        };
    }
}
