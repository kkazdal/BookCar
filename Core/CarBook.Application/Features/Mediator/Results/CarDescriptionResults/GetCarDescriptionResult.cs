using System;

namespace CarBook.Application.Features.Mediator.Results.CarDescriptionResults;

public class GetCarDescriptionResult
{
    public int CarDescriptionID { get; set; }
    public int CarID { get; set; }
    public string Details { get; set; }
}
