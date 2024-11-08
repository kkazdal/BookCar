using System;
using CarBook.Application.Features.CQRS.Commands.About;
using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class RemoveBlogHandler : IRequestHandler<RemoveBlogCommand>
{
    private readonly IRepository<Blog> _repository;

    public RemoveBlogHandler(IRepository<Blog> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
    {
        var Blog = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(Blog);
    }
}
