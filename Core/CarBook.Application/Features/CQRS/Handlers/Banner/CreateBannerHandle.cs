using CarBook.Application.Features.CQRS.Commands.Banner;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;

public class CreateBannerHandle
{
    private readonly IRepository<Banner> _repository;

    public CreateBannerHandle(IRepository<Banner> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateBannerCommand createBannerCommand)
    {
        await _repository.CreateAsync(new Banner
        {
            Description = createBannerCommand.Description,
            Title = createBannerCommand.Title,
            VideoDescription = createBannerCommand.VideoDescription,
            VideoUrl  = createBannerCommand.VideoUrl
        });
    }
}
