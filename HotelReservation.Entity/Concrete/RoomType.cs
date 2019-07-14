using System;
using System.Collections.Generic;

namespace HotelReservation.Entity.Concrete
{
    public partial class RoomType : IEntity
    {
        public RoomType()
        {
            HotelRoom = new HashSet<HotelRoom>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }

        public ICollection<HotelRoom> HotelRoom { get; set; }
    }
}
