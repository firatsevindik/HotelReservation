using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.Entity.Concrete;

namespace HotelReservation.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,HotelDbContext>,IUserDal
    {
        public User Login(string userName, string password)
        {
            using (var context = new HotelDbContext())
            {
                return context.User
                    .SingleOrDefault(x => x.UserName == userName && x.Password == password);
            }
        }
    }
}
