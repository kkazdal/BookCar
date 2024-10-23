using System;
using CarBook.Application.Features.CQRS.Commands.Category;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;


public class CreateCategoryHandle
{
    private readonly IRepository<Category> _repository;

    public CreateCategoryHandle(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateCategoryCommand createCategoryCommand)
    {
        await _repository.CreateAsync(new Category
        {
            Name = createCategoryCommand.Name
        });
    }
}
