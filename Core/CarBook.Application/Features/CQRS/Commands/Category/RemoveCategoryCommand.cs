using System;

namespace CarBook.Application.Features.CQRS.Commands.Category;

public class RemoveCategoryCommand
{
   public int Id { get; set; }

    public RemoveCategoryCommand(int id)
    {
        Id = id;
    }
}
