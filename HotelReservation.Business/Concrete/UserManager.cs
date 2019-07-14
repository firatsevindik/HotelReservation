using System;
using System.Collections.Generic;
using System.Text;
using HotelReservation.Business.Abstract;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.Entity.Concrete;

namespace HotelReservation.Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User Login(string userName, string password)
        {
            return _userDal.Login(userName, password);
        }
    }
}
