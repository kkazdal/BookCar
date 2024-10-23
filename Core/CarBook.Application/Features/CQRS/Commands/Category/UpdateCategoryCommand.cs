using System;

namespace CarBook.Application.Features.CQRS.Commands.Category;

public class UpdateCategoryCommand
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
}
