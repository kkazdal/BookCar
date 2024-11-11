using System;
using CarBook.Application.Features.CQRS.Queries.Category;
using CarBook.Application.Features.CQRS.Results.Category;
using CarBook.Application.Interfaces.CategoryRepositories;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.Category;

public class GetCategoryByBlogNumberHandler
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByBlogNumberHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<GetCategoryByBlogNumberResult>> Handle()
    {
        var response = await _categoryRepository.GetCategoryByBlogNumberResult();
        return response;
    }
}
