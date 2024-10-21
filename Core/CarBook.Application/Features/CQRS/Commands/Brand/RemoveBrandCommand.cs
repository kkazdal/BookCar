using System;

namespace CarBook.Application.Features.CQRS.Commands.Brand;

public class RemoveBrandCommand
{
    public int Id { get; set; }

    public RemoveBrandCommand(int id)
    {
        Id = id;
    }
}
