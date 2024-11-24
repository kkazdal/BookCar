using System;

namespace CarBook.Dto.CarDtos;

public class FeaturedVehiclesDto
{
    public string brandName { get; set; }
    public string Model { get; set; }
    public string imageUrl { get; set; }
    public decimal Price { get; set; }
    public string PriceName { get; set; }
}
