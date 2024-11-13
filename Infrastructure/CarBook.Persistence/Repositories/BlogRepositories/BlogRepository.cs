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
                                  Title = blog.Title,
                                  CreatedDate = blog.CreatedDate,
                                  Description = blog.Description
                              }).ToListAsync();


        return response;
    }

    public async Task<List<GetBlogsWithAuthorResult>> GetBlogsWithAuthorList()
    {
        var response = await (from blog in _carBookContext.Blogs
                              join author in _carBookContext.Authors
                              on blog.AuthorId equals author.AuthorId
                              select new GetBlogsWithAuthorResult
                              {
                                  AuthorName = author.Name,
                                  BlogTitle = blog.Title,
                                  ImageUrl = blog.CoverImageUrl,
                                  AuthorId = author.AuthorId,
                                  BlogId = blog.Id,
                                  CreatedDate = blog.CreatedDate,
                                  Description = blog.Description
                              }).ToListAsync();

        return response;
    }

    public async Task<GetQueryBlogByIdResult> GetBlogWithAuthorInfoById(int blogId)
    {
        var response = await (from blog in _carBookContext.Blogs
                              where blog.Id == blogId
                              join author in _carBookContext.Authors
                              on blog.AuthorId equals author.AuthorId
                              select new GetQueryBlogByIdResult
                              {
                                  AuthorName = author.Name,
                                  AuthorId = author.AuthorId,
                                  CategoryId = blog.CategoryId,
                                  CoverImageUrl = blog.CoverImageUrl,
                                  CreatedDate = blog.CreatedDate,
                                  Description = blog.Description,
                                  Title = blog.Title,
                                  AuthorDescription = author.Description,
                                  Id = blog.Id
                              }).FirstOrDefaultAsync();

        return response!;

    }
}
