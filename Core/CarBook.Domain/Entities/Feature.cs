using System;
using System.Collections.Generic;

namespace CarBook.CarBookDomain.Entities
{
    public class Feature
    {
        public int FeatureId{ get; set; }
        public string Name{ get; set; }
        public ICollection<CarFeature> CarFeatures { get; set; }
    }
}
