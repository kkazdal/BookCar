using System;
using CarBook.Application.Features.CQRS.Commands.Banner;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;


public class UpdateBannerHandle
{
    private readonly IRepository<Banner> _repository;

    public UpdateBannerHandle(IRepository<Banner> repository)
    {
        _repository = repository;
    }

    public async Task handle(UpdateBannerCommand updateBannerCommand)
    {
        Banner banner = await _repository.GetByIdAsync(updateBannerCommand.BannerId);

        banner.Description = updateBannerCommand.Description;
        banner.Title = updateBannerCommand.Title;
        banner.VideoDescription = updateBannerCommand.VideoDescription;
        banner.VideoUrl = updateBannerCommand.VideoUrl;

        await _repository.UpdateAsync(banner);
    }
}
