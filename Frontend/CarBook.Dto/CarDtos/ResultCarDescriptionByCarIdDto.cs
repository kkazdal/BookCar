using System;

namespace CarBook.Dto.CarDtos;

public class ResultCarDescriptionByCarIdDto
{
    public int CarDescriptionID { get; set; }
    public int CarID { get; set; }
    public string Details { get; set; }
}
