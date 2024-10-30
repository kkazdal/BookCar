using System;
using CarBook.Application.Features.Mediator.Queries.FooterAddress;
using CarBook.Application.Features.Mediator.Results.FooterAddress;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;


public class GetFooterAddresshandle : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressResult>>
{
    private readonly IRepository<FooterAddress> _repository;

    public GetFooterAddresshandle(IRepository<FooterAddress> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetFooterAddressResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetAllAsync();
        return response.Select(x => new GetFooterAddressResult
        {
            FooterAddressId = x.FooterAddressId,
            Description = x.Description,
            Address = x.Address,
            Phone = x.Phone,
            EMail = x.EMail,
        }).ToList();
    }
}
