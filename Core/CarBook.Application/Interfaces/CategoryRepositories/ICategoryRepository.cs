using System;
using CarBook.Application.Features.CQRS.Results.Category;

namespace CarBook.Application.Interfaces.CategoryRepositories;

public interface ICategoryRepository
{
    Task<List<GetCategoryByBlogNumberResult>> GetCategoryByBlogNumberResult();
}
