using CarBook.Application.Features.CQRS.Results.ContactResult;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandler;

public class GetContactQueryHandle
{
    private readonly IRepository<Contact> _repository;

    public GetContactQueryHandle(IRepository<Contact> repository)
    {
        this._repository = repository;
    }

    public async Task<List<GetContactQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetContactQueryResult
        {
            ContactId = x.ContactId,
            Name = x.Name,
            Email = x.Email,
            Subject = x.Subject,
            Message = x.Message,
            SendDate = x.SendDate,
        }).ToList();
    }
}
