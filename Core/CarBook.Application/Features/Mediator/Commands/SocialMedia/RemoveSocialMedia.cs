using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.SocialMedia;

public class RemoveSocialMediaCommand : IRequest
{
    public int SocialMediaId { get; set; }

    public RemoveSocialMediaCommand(int socialMediaId)
    {
        SocialMediaId = socialMediaId;
    }
}
