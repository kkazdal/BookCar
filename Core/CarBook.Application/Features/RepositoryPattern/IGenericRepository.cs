using System;

namespace CarBook.Application.Features.RepositoryPattern;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> GetAll();
    Task Create(T entity);
    Task Remove(T entity);
    Task Update(T entity);
    Task<T> GetById(int id);
}
