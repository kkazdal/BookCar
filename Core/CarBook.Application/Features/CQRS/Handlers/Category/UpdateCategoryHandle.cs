using System;
using CarBook.Application.Features.CQRS.Commands.Category;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;


public class UpdateCategoryHandle
{
    private readonly IRepository<Category> _repository;

    public UpdateCategoryHandle(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task handle(UpdateCategoryCommand updateCategoryCommand)
    {
        Category Category = await _repository.GetByIdAsync(updateCategoryCommand.CategoryId);

        Category.Name = updateCategoryCommand.Name;

        await _repository.UpdateAsync(Category);
    }
}
