using System;
using CarBook.Application.Features.Mediator.Commands.TagCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TagHandlers;

public class UpdateTagHandler : IRequestHandler<UpdateTagCommand>
{
    private readonly IRepository<Tag> _repository;

    public UpdateTagHandler(IRepository<Tag> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.Id);
        response.TagName = request.TagName;
        await _repository.UpdateAsync(response);
    }
}
