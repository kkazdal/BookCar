
using CarBook.Application.Features.CQRS.Commands.About;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;

public class CreateAboutHandle
{
    private readonly IRepository<About> _repository;

    public CreateAboutHandle(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateAboutCommands createAbout)
    {
        await _repository.CreateAsync(new About
        {
            Title = createAbout.Title,
            Description = createAbout.Description,
            ImageUrl = createAbout.ImageUrl
        });
    }
}
