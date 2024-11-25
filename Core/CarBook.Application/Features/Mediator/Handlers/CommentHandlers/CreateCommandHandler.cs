using System;
using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers;

public class CreateCommandHandler : IRequestHandler<CreateCommand>
{
    private readonly IRepository<Comment> _repository;

    public CreateCommandHandler(IRepository<Comment> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Comment
        {
            Name = request.Name,
            Description = request.Description,
            BlogId = request.BlogId,
            Email = request.Email
        });
    }
}
