using System;
using System.Collections.Generic;

namespace HotelReservation.Entity.Concrete
{
    public partial class HotelRoom : IEntity
    {
        public HotelRoom()
        {
            HotelRoomPrice = new HashSet<HotelRoomPrice>();
        }

        public int Id { get; set; }
        public int? HotelId { get; set; }
        public int? RoomTypeId { get; set; }
        public string RoomSummary { get; set; }
        public string RoomDetail { get; set; }

        public Hotel Hotel { get; set; }
        public RoomType RoomType { get; set; }
        public ICollection<HotelRoomPrice> HotelRoomPrice { get; set; }
    }
}
