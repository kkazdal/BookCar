using System;
using CarBook.Application.Features.Mediator.Results.SocialMedia;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;

public class GetSocialMediaQuery : IRequest<List<GetSocialMediaQueryResult>>
{

}
