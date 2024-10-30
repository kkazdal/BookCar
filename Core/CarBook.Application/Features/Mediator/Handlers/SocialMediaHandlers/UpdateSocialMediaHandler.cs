using System;
using CarBook.Application.Features.Mediator.Commands.SocialMedia;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class UpdateSocialMediaHandler : IRequestHandler<UpdateSocialMediaCommand>
{
    private readonly IRepository<SocialMedia> _repository;

    public UpdateSocialMediaHandler(IRepository<SocialMedia> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.SocialMediaId);
        response.Icon = request.Icon;
        response.Name = request.Name;
        response.Url = request.Url;

        await _repository.UpdateAsync(response);
    }
}
