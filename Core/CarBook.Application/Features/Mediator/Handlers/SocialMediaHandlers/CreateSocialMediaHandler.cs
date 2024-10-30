using System;
using CarBook.Application.Features.Mediator.Commands.SocialMedia;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class CreateSocialMediaHandler : IRequestHandler<CreateSocialMediaCommand>
{
    private readonly IRepository<SocialMedia> _repository;

    public CreateSocialMediaHandler(IRepository<SocialMedia> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new SocialMedia
        {
            Icon = request.Icon,
            Name = request.Name,
            Url = request.Url
        });
    }
}
