using System;

namespace CarBook.Dto.FooterDtos;

public class FooterAddressDtos
{
    public int FooterAddressId { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string EMail { get; set; }
}
