using System;
using System.Collections.Generic;

namespace HotelReservation.Entity.Concrete
{
    public class Hotel:IEntity
    {
        public Hotel()
        {
            HotelAddress = new HotelAddress();
            HotelComment = new HashSet<HotelComment>();
            HotelContact = new HashSet<HotelContact>();
            HotelImage = new HashSet<HotelImage>();
            HotelRoom = new HashSet<HotelRoom>();
            HotelScore = new HotelScore();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public HotelAddress HotelAddress { get; set; }
        public ICollection<HotelComment> HotelComment { get; set; }
        public ICollection<HotelContact> HotelContact { get; set; }
        public ICollection<HotelImage> HotelImage { get; set; }
        public ICollection<HotelRoom> HotelRoom { get; set; }
        public HotelScore HotelScore { get; set; }
    }

    
}



