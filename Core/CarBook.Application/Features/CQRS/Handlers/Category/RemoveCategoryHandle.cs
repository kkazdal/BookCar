using System;
using CarBook.Application.Features.CQRS.Commands.Category;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;


public class RemoveCategoryHandle
{
    private readonly IRepository<Category> _repository;

    public RemoveCategoryHandle(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task handle(RemoveCategoryCommand removeCategoryHandle)
    {
        Category Category = await _repository.GetByIdAsync(removeCategoryHandle.Id);

        await _repository.RemoveAsync(Category);
    }
}
