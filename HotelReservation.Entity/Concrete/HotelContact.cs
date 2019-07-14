using System;
using System.Collections.Generic;

namespace HotelReservation.Entity.Concrete
{
    public partial class HotelContact : IEntity
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string ContactValue { get; set; }
        public int HotelContactTypeId { get; set; }

        public Hotel Hotel { get; set; }
        public HotelContactType HotelContactType { get; set; }
    }
}
