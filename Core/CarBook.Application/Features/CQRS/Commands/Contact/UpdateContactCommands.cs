using System;

namespace CarBook.Application.Features.CQRS.Commands.Contact;

public class UpdateContactCommands
{
    public int ContactId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime SendDate { get; set; }
}
