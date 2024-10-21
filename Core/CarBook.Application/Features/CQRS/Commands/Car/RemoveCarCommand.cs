using System;

namespace CarBook.Application.Features.CQRS.Commands.Car;

public class RemoveCarCommand
{
    public int Id { get; set; }

    public RemoveCarCommand(int id)
    {
        Id = id;
    }
}
