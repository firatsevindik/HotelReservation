﻿using System;
using System.Collections.Generic;

namespace HotelReservation.Entity.Concrete
{
    public class HotelAddress:IEntity
    {
        public int Id { get; set; }
        public int? HotelId { get; set; }
        public string AddressText { get; set; }
        public int? CityId { get; set; }
        public string PostalCode { get; set; }
        public string LocationLatitude { get; set; }
        public string LocationLongtitude { get; set; }

        public Hotel Hotel { get; set; }
    }
}
