using System;
using CarBook.Application.Features.Mediator.Results.TagResults;
using CarBook.Application.Interfaces.TagRepositories;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.TagRepositories;

public class TagRepository : ITagRepository
{
    private readonly CarBookContext _carBookContext;
    public TagRepository(CarBookContext carBookContext)
    {
        _carBookContext = carBookContext;
    }

    public async Task<List<GetTagByBlogIdResult>> GetTagByBlogIdList(int blogId)
    {
        var response = await (from tag in _carBookContext.Tag
                              where tag.BlogId == blogId
                              select new GetTagByBlogIdResult
                              {
                                  TagName = tag.TagName,
                                  BlogId = blogId,
                                  TagId = tag.Id
                              }).ToListAsync();
        return response;
    }
}
