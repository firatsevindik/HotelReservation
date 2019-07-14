using System;
using System.Collections.Generic;
using System.Text;
using HotelReservation.Entity.Concrete;

namespace HotelReservation.Business.Abstract
{
    public interface IUserService
    {
        User Login(string userName, string password);
    }
}
