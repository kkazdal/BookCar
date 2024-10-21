using System;
using CarBook.Application.Features.CQRS.Results.AboutResult;
using CarBook.Application.Features.CQRS.Results.Banner;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;


public class GetBannerByIdQueryHandle
{
    private readonly IRepository<Banner> _repository;

    public GetBannerByIdQueryHandle(IRepository<Banner> repository)
    {
        _repository = repository;
    }


    public async Task<GetBannerQueryByIdResult> handle(GetBannerQueryByIdQuery getBannerQueryByIdResult)
    {
        var response = await _repository.GetByIdAsync(getBannerQueryByIdResult.id);
        return new GetBannerQueryByIdResult
        {
            BannerId = response.BannerId,
            Description = response.Description,
            Title = response.Title,
            VideoDescription = response.VideoDescription,
            VideoUrl = response.VideoUrl
        };
    }
}
