using System;
using System.Collections.Generic;

namespace HotelReservation.Entity.Concrete
{
    public partial class User : IEntity
    {
        public User()
        {
            HotelComment = new HashSet<HotelComment>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public ICollection<HotelComment> HotelComment { get; set; }
    }
}
