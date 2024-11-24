using System;

namespace CarBook.Application.Features.CQRS.Results.Car;

public class GetLastCarsByNumber
{
    public string brandName { get; set; }
    public string Model { get; set; }
    public string imageUrl { get; set; }
    public decimal Price { get; set; }
    public string PriceName { get; set; }
}
