using System;
using System.Collections.Generic;

namespace CarBook.CarBookDomain.Entities
{
    public class Pricing
    {
        public int PricingId{ get; set; }
        public string Name{ get; set; }
        public ICollection<CarPricing> CarPricings{ get; set; }
    }
}
