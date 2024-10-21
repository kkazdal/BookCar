using CarBook.Application.Features.CQRS.Commands.Banner;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;


public class RemoveBannerHandle
{
    private readonly IRepository<Banner> _repository;

    public RemoveBannerHandle(IRepository<Banner> repository)
    {
        _repository = repository;
    }

    public async Task handle(RemoveBannerCommand removeAboutHandle)
    {
        Banner banner = await _repository.GetByIdAsync(removeAboutHandle.id);

        await _repository.RemoveAsync(banner);
    }
}
