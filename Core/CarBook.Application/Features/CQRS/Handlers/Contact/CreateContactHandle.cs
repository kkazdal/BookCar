
using CarBook.Application.Features.CQRS.Commands.Contact;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;

public class CreateContactHandle
{
    private readonly IRepository<Contact> _repository;

    public CreateContactHandle(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateContactCommands createContact)
    {
        await _repository.CreateAsync(new Contact
        {
            Name = createContact.Name,
            Email = createContact.Email,
            Subject = createContact.Subject,
            Message = createContact.Message,
            SendDate = createContact.SendDate,
        });
    }
}
