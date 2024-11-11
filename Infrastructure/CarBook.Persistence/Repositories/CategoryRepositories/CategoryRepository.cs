using System;
using CarBook.Application.Features.CQRS.Results.Category;
using CarBook.Application.Interfaces.CategoryRepositories;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CategoryRepositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly CarBookContext _carBookContext;

    public CategoryRepository(CarBookContext carBookContext)
    {
        _carBookContext = carBookContext;
    }

    public async Task<List<GetCategoryByBlogNumberResult>> GetCategoryByBlogNumberResult()
    {
        var response = await (from cat in _carBookContext.Categories
                              join blog in _carBookContext.Blogs
                              on cat.CategoryId equals blog.CategoryId into blogGroup
                              select new GetCategoryByBlogNumberResult
                              {
                                  CategoryId = cat.CategoryId,
                                  Name = cat.Name,
                                  BlogNumber = blogGroup.Count()
                              }).ToListAsync();

        return response;
    }
}
