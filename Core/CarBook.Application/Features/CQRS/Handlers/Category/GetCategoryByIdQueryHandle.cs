using System;
using CarBook.Application.Features.CQRS.Queries.Category;
using CarBook.Application.Features.CQRS.Results.Category;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;


public class GetCategoryByIdQueryHandle
{
    private readonly IRepository<Category> _repository;

    public GetCategoryByIdQueryHandle(IRepository<Category> repository)
    {
        _repository = repository;
    }


    public async Task<GetCategoryByIdQueryResult> handle(GetCategoryQueryByIdQuery getCategoryQueryByIdResult)
    {
        var response = await _repository.GetByIdAsync(getCategoryQueryByIdResult.Id);
        return new GetCategoryByIdQueryResult
        {
            CategoryId = response.CategoryId,
            Name = response.Name
        };
    }
}
