using System;

namespace CarBook.Application.Features.CQRS.Commands.Contact;

public class RemoveContactCommands
{
    public int Id { get; set; }

    public RemoveContactCommands(int id)
    {
        this.Id = id;
    }
}
