using System;
using CarBook.Application.Features.Mediator.Results.FooterAddress;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.FooterAddress;

public class GetFooterAddressQuery : IRequest<List<GetFooterAddressResult>>
{

}
