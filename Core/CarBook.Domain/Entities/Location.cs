using System;
using CarBook.Domain.Entities;
namespace CarBook.CarBookDomain.Entities
{
    public class Location
    {
        public int LocationId{ get; set; }
        public string Name{ get; set; }
        public ICollection<RentACar> RentACars { get; set; }
        public ICollection<Reservation> PickUpReservation { get; set; }
        public ICollection<Reservation> DropOffReservation { get; set; }
    }
}
