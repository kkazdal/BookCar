using System;

namespace CarBook.Application.Features.Mediator.Results.ReviewsResults;

public class GetReviewByCarIdResult
{
    public int ReviewID { get; set; }
    public string CustomerName { get; set; }
    public string CustomerImage { get; set; }
    public string Comment { get; set; }
    public int RaytingValue { get; set; }
    public DateTime ReviewDate { get; set; }
    public int CarID { get; set; }
}
