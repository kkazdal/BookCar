using System;
using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class UpdateBlogHandler : IRequestHandler<UpdateBlogCommand>
{
    private readonly IRepository<Blog> _repository;

    public UpdateBlogHandler(IRepository<Blog> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = await _repository.GetByIdAsync(request.AuthorId);
        
        blog.AuthorId = request.AuthorId;
        blog.Title = request.Title;
        blog.CoverImageUrl = request.CoverImageUrl;
        blog.CategoryId = request.CategoryId;

        await _repository.UpdateAsync(blog);
    }
}
