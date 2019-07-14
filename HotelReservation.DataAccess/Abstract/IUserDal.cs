using System;
using System.Collections.Generic;
using System.Text;
using HotelReservation.DataAccess.Concrete.EntityFramework;
using HotelReservation.Entity.Concrete;

namespace HotelReservation.DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        User Login(string userName, string password);
    }
}
