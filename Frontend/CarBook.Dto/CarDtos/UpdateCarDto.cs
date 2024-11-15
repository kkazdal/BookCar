using System;

namespace CarBook.Dto.CarDtos;

public class UpdateCarDto
{
    public int CarId { get; set; }
    public int BrandID { get; set; }
    public string Model { get; set; }
    public string CoverImageUrl { get; set; }
    public int Km { get; set; }
    public string Transmission { get; set; }
    public byte Seat { get; set; }
    public byte Luggage { get; set; }
    public string Fuel { get; set; }
    public string BigImageUrl { get; set; }
}
