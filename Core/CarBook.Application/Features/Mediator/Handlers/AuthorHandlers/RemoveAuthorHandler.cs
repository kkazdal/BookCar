using System;
using CarBook.Application.Features.CQRS.Commands.About;
using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers;

public class RemoveAuthorHandler : IRequestHandler<RemoveAuthorCommand>
{
    private readonly IRepository<Author> _repository;

    public RemoveAuthorHandler(IRepository<Author> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _repository.GetByIdAsync(request.AuthorId);
        await _repository.RemoveAsync(author);
    }
}
