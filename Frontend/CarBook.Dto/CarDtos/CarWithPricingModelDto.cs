using System;

namespace CarBook.Dto.CarDtos;

public class CarWithPricingModelDto
{
    public int CarId { get; set; }
    public decimal Amount { get; set; }
    public required string CarModel { get; set; }
    public required string PricingName { get; set; }
    public required string Image { get; set; }
    public required string BrandName { get; set; }
}
