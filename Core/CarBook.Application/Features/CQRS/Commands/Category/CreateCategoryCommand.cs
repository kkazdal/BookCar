using System;

namespace CarBook.Application.Features.CQRS.Commands.Category;

public class CreateCategoryCommand
{
    public string Name { get; set; }
}
