using System;
using CarBook.Application.Features.Mediator.Commands.TagCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TagHandlers;

public class CreateTagHandler : IRequestHandler<CreateTagCommand>
{
    private readonly IRepository<Tag> _repository;

    public CreateTagHandler(IRepository<Tag> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Tag
        {
            TagName = request.TagName,
            BlogId = request.BlogId
        });
    }
}
