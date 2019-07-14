using System;
using System.Collections.Generic;

namespace HotelReservation.Entity.Concrete
{
    public partial class HotelComment : IEntity
    {
        public int Id { get; set; }
        public int? HotelId { get; set; }
        public int? UserId { get; set; }
        public string Comment { get; set; }
        public int? Score { get; set; }

        public Hotel Hotel { get; set; }
        public User User { get; set; }
    }
}
