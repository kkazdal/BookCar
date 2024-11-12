using System;
using CarBook.Application.Features.Mediator.Commands.TagCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TagHandlers;

public class RemoveTagHandler : IRequestHandler<RemoveTagCommand>
{
    private readonly IRepository<Tag> _repository;

    public RemoveTagHandler(IRepository<Tag> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveTagCommand request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(response);
    }
}
