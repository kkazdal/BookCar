using System;
using CarBook.Application.Features.CQRS.Commands.About;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers;

public class RemoveAuthotHandler : IRequestHandler<RemoveAboutCommands>
{
    private readonly IRepository<Author> _repository;

    public RemoveAuthotHandler(IRepository<Author> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveAboutCommands request, CancellationToken cancellationToken)
    {
        var author = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(author);
    }
}
