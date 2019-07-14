using System;
using System.Collections.Generic;

namespace HotelReservation.Entity.Concrete
{
    public partial class HotelScore : IEntity
    {
        public int Id { get; set; }
        public int? HotelId { get; set; }
        public int? HotelScoreTypeId { get; set; }
        public int? ScoreValue { get; set; }

        public Hotel Hotel { get; set; }
    }
}
