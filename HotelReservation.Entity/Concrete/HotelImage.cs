using System;
using System.Collections.Generic;

namespace HotelReservation.Entity.Concrete
{
    public partial class HotelImage : IEntity
    {
        public int Id { get; set; }
        public int? HotelId { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }

        public Hotel Hotel { get; set; }
    }
}
