using System;

namespace CarBook.Dto.CarPricingDto;

public class ResultCarPricingListWithModelDto
{
    public string model { get; set; }
    public decimal dailyAmount { get; set; }
    public decimal weeklyAmount { get; set; }
    public decimal monthlyAmount { get; set; }
    public string CoverImageUrl { get; set; }
    public string Brand { get; set; }
}
