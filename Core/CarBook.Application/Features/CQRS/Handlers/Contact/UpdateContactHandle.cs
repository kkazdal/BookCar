using System;
using CarBook.Application.Features.CQRS.Commands.Contact;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;


public class UpdateContactHandle
{
    private readonly IRepository<Contact> _repository;

    public UpdateContactHandle(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateContactCommands updateContactCommands)
    {
        Contact Contact = await _repository.GetByIdAsync(updateContactCommands.ContactId);

        Contact.Name = updateContactCommands.Name;
        Contact.Email = updateContactCommands.Email;
        Contact.Subject = updateContactCommands.Subject;
        Contact.Message = updateContactCommands.Message;
        Contact.SendDate = updateContactCommands.SendDate;

        await _repository.UpdateAsync(Contact);
    }
}
