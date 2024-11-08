using System;
using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class CreateBlogHandler : IRequestHandler<CreateBlogCommand>
{
    private readonly IRepository<Blog> _repository;

    public CreateBlogHandler(IRepository<Blog> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(
            new Blog
            {
                AuthorId = request.AuthorId,
                CategoryId = request.CategoryId,
                Title = request.Title,
                CoverImageUrl = request.CoverImageUrl,
                CreatedDate = DateTime.Now
            }
        );
    }
}
