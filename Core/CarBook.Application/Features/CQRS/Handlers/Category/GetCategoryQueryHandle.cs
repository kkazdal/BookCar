using System;
using CarBook.Application.Features.CQRS.Results.Brand;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;


public class GetCategoryQueryHandle
{
    private readonly IRepository<Category> _repository;

    public GetCategoryQueryHandle(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetCategoryResult>> Handle()
    {
        var response = await _repository.GetAllAsync();
        return response.Select(item => new GetCategoryResult
        {
            CategoryId = item.CategoryId,
            Name = item.Name
        }).ToList();
    }
}
