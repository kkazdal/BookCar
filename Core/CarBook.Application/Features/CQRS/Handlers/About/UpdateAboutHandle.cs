using System;
using CarBook.Application.Features.CQRS.Commands.About;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;


public class UpdateAboutHandle
{
    private readonly IRepository<About> _repository;

    public UpdateAboutHandle(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateAboutCommands updateAboutCommands)
    {
        About about = await _repository.GetByIdAsync(updateAboutCommands.AboutId);
        about.Description = updateAboutCommands.Description;
        about.Title = updateAboutCommands.Title;
        about.ImageUrl = updateAboutCommands.ImageUrl;

        await _repository.UpdateAsync(about);
    }
}
