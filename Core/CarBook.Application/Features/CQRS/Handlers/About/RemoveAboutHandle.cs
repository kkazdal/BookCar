using System;
using CarBook.Application.Features.CQRS.Commands.About;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;


public class RemoveAboutHandle
{
    private readonly IRepository<About> _repository;

    public RemoveAboutHandle(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveAboutCommands removeAbout)
    {
        About about = await _repository.GetByIdAsync(removeAbout.Id);
        await _repository.RemoveAsync(about);
    }
}
