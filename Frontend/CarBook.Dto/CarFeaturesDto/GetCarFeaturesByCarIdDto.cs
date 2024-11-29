using System;

namespace CarBook.Dto.CarFeaturesDto;

public class GetCarFeaturesByCarIdDto
{
    public int CarFeatureId { get; set; }
    public int CarId { get; set; }
    public int FeatureId { get; set; }
    public string FeatureName { get; set; }
    public bool Available { get; set; }
}
