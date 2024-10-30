using System;
using CarBook.Application.Features.Mediator.Results.FooterAddress;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.FooterAddress;

public class GetFooterAddressByIdQuery : IRequest<GetFooterAddressByIdQueryResult>
{
    public int Id { get; set; }

    public GetFooterAddressByIdQuery(int id)
    {
        Id = id;
    }
}
