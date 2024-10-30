using System;
using CarBook.Application.Features.Mediator.Queries.FooterAddress;
using CarBook.Application.Features.Mediator.Results.FooterAddress;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;


public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
{
    private readonly IRepository<FooterAddress> _repository;

    public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
    {
        _repository = repository;
    }

    public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.Id);
        return new GetFooterAddressByIdQueryResult
        {
            FooterAddressId = response.FooterAddressId,
            Address = response.Address,
            Description = response.Description,
            EMail = response.EMail,
            Phone = response.Phone,
        };
    }
}
