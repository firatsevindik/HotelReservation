using System;
using System.Collections.Generic;

namespace HotelReservation.Entity.Concrete
{
    public partial class HotelContactType : IEntity
    {
        public HotelContactType()
        {
            HotelContact = new HashSet<HotelContact>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<HotelContact> HotelContact { get; set; }
    }
}
