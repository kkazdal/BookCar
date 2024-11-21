using System;
using System.Collections.Generic;
using CarBook.Domain.Entities;

namespace CarBook.CarBookDomain.Entities
{
    public class Car
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
        public ICollection<CarFeature> CarFeatures { get; set; }
        public ICollection<CarDescription> CarDescriptions { get; set; }
        public ICollection<CarPricing> CarPricings { get; set; }
        public ICollection<RentACar> RentACars { get; set; }
        public ICollection<RentACarProcess> RentACarProcesses { get; set; }

    }
}
