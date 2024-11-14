using System;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CommentRepositories;

public class CommentRepository<T> : IGenericRepository<Comment>
{
    private readonly CarBookContext _carBookContext;

    public CommentRepository(CarBookContext carBookContext)
    {
        _carBookContext = carBookContext;
    }

    public async Task Create(Comment entity)
    {
        _carBookContext.Comments.Add(entity);
        await _carBookContext.SaveChangesAsync();
    }

    public async Task<List<Comment>> GetAll()
    {
        return await _carBookContext.Comments.Select(x => new Comment
        {
            Description = x.Description,
            BlogId = x.BlogId,
            CommentId = x.CommentId,
            CreatedDate = x.CreatedDate,
            Name = x.Name
        }).ToListAsync();
    }

    public async Task<Comment> GetById(int id)
    {
        return await _carBookContext.Comments.FindAsync(id);
    }

    public async Task Remove(Comment entity)
    {
        var item = await _carBookContext.Comments.FindAsync(entity.CommentId);
        _carBookContext.Comments.Remove(item);
        await _carBookContext.SaveChangesAsync();
    }

    public async Task Update(Comment entity)
    {
        _carBookContext.Comments.Update(entity);
        await _carBookContext.SaveChangesAsync();
    }
}
