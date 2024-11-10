using System;
using CarBook.Application.Features.Mediator.Results.BlogResults;

namespace CarBook.Application.Interfaces.BlogRepositories;

public interface IBlogRepository
{
    Task<List<GetLastBlogsByNumberResult>> GetBlogAndAuthorName();
    Task<List<GetBlogsWithAuthorResult>> GetBlogsWithAuthorList();
}
