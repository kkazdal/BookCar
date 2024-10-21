using System;
using CarBook.Application.Features.CQRS.Results.Banner;
using CarBook.Application.Features.CQRS.Results.Brand;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;


public class GetBrandQueryHandle
{
    private readonly IRepository<Brand> _repository;

    public GetBrandQueryHandle(IRepository<Brand> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetBrandQueryResult>> Handle()
    {
        var response = await _repository.GetAllAsync();
        return response.Select(item => new GetBrandQueryResult
        {
            BrandId = item.BrandId,
            Name = item.Name
        }).ToList();
    }
}
