using System;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.CommentRepositories;

public interface ICommentRepository
{
    Task<List<CommentViewDto>> GetMediatorCommentListByBlogId(int blogId);
}
