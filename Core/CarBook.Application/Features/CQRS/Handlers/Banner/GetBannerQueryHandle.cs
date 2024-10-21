using System;
using CarBook.Application.Features.CQRS.Results.Banner;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;


public class GetBannerQueryHandle
{
    private readonly IRepository<Banner> _repository;

    public GetBannerQueryHandle(IRepository<Banner> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetBannerQueryResult>> Handle()
    {
        var response = await _repository.GetAllAsync();
        return response.Select(item => new GetBannerQueryResult
        {
            BannerId = item.BannerId,
            Description = item.Description,
            Title = item.Title,
            VideoDescription = item.VideoDescription,
            VideoUrl = item.VideoUrl
        }).ToList();
    }
}
