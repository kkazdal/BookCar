using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.SocialMedia;

public class UpdateSocialMediaCommand : IRequest
{
    public int SocialMediaId { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
}
