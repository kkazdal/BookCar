using System;

namespace CarBook.Application.Features.Mediator.Results.FooterAddress;

public class GetFooterAddressByIdQueryResult
{
    public int FooterAddressId { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string EMail { get; set; }
}
