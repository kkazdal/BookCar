using System;
using System.Collections.Generic;

namespace CarBook.CarBookDomain.Entities
{
    public class Brand
    {
        public int BrandId{ get; set; }
        public string Name{ get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
