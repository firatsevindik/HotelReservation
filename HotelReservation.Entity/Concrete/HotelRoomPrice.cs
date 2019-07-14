using System;
using System.Collections.Generic;

namespace HotelReservation.Entity.Concrete
{
    public partial class HotelRoomPrice : IEntity
    {
        public int Id { get; set; }
        public int? HotelRoomId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Price { get; set; }
        public bool? IsAvailable { get; set; }

        public HotelRoom HotelRoom { get; set; }
    }
}
