using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using CarBook.Application.Features.CQRS.Results.ContactResult;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandler;
public class GetContactByIdQueryHandle
{
    private readonly IRepository<Contact> _repository;

    public GetContactByIdQueryHandle(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery getContactByIdQuery)
    {
        var response = await _repository.GetByIdAsync(getContactByIdQuery.Id);

        return new GetContactByIdQueryResult
        {
            ContactId = response.ContactId,
            Name = response.Name,
            Email = response.Email,
            Subject = response.Subject,
            Message = response.Message,
            SendDate = response.SendDate,
        };
    }
}
