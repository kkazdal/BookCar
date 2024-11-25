using System;
using CarBook.Application.Interfaces.CommentRepositories;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CommentRepositories;

public class CommentRepositoryMediator : ICommentRepository
{
    private readonly CarBookContext _carBookContext;

    public CommentRepositoryMediator(CarBookContext carBookContext)
    {
        _carBookContext = carBookContext;
    }

    public async Task<List<CommentViewDto>> GetMediatorCommentListByBlogId(int blogId)
    {
        var response = (from com in _carBookContext.Comments
                        join blog in _carBookContext.Blogs
                        on com.BlogId equals blog.Id
                        where com.BlogId == blogId
                        select new CommentViewDto
                        {
                            BlogId = blog.Id,
                            Description = com.Description,
                            CommentId = com.CommentId,
                            CreatedDate = com.CreatedDate,
                            Name = com.Name,
                        }).ToList();
        return response;
    }
}
