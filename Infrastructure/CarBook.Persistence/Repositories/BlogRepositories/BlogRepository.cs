using System;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogRepositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.BlogRepositories;

public class BlogRepository : IBlogRepository
{
    private readonly CarBookContext _carBookContext;
    public BlogRepository(CarBookContext carBookContext)
    {
        _carBookContext = carBookContext;
    }

    public async Task<List<GetLastBlogsByNumberResult>> GetBlogAndAuthorName()
    {
        var response = await (from blog in _carBookContext.Blogs
                              join author in _carBookContext.Authors
                              on blog.AuthorId equals author.AuthorId
                              select new GetLastBlogsByNumberResult
                              {
                                  BlogId = blog.Id,
                                  AuthorName = author.Name,
                                  CoverImageUrl = blog.CoverImageUrl,
                                  Title = blog.Title
                              }).ToListAsync();


        return response;
    }
}
