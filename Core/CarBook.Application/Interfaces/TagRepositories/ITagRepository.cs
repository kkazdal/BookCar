using System;
using CarBook.Application.Features.Mediator.Results.TagResults;

namespace CarBook.Application.Interfaces.TagRepositories;

public interface ITagRepository
{
    Task<List<GetTagByBlogIdResult>> GetTagByBlogIdList(int blogId);
}
