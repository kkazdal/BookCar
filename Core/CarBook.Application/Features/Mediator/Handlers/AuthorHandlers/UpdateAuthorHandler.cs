using System;
using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers;

public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand>
{
    private readonly IRepository<Author> _repository;

    public UpdateAuthorHandler(IRepository<Author> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _repository.GetByIdAsync(request.AuthorId);
        author.Description = request.Description;
        author.ImageUrl = request.ImageUrl;
        author.Name = request.Name;
        await _repository.UpdateAsync(author);
    }
}
