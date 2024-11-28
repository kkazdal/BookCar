using System;
using CarBook.CarBookDomain.Entities;

namespace CarBook.Application.Features.Mediator.Results.CarFeatures;

public class GetCarFeaturesByCarIdResult
{
    public int CarFeatureId { get; set; }
    public int CarId { get; set; }
    public int FeatureId { get; set; }
    public string FeatureName { get; set; }
    public bool Available { get; set; }
}
