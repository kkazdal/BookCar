using System;
using CarBook.Application.Features.Mediator.Commands.SocialMedia;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class RemoveSocialMedia : IRequestHandler<RemoveSocialMediaCommand>
{
    private readonly IRepository<SocialMedia> _repository;

    public RemoveSocialMedia(IRepository<SocialMedia> repository)
    {
        _repository = repository;
    }
    public async Task Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.SocialMediaId);
        await _repository.RemoveAsync(response);
    }
}
