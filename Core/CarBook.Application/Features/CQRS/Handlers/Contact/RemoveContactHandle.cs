using System;
using CarBook.Application.Features.CQRS.Commands.Contact;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;


public class RemoveContactHandle
{
    private readonly IRepository<Contact> _repository;

    public RemoveContactHandle(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveContactCommands removeContact)
    {
        Contact Contact = await _repository.GetByIdAsync(removeContact.Id);
        await _repository.RemoveAsync(Contact);
    }
}
