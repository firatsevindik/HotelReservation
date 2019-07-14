using System;
using System.Collections.Generic;
using System.Text;
using HotelReservation.DataAccess.Concrete.EntityFramework;
using HotelReservation.Entity.Concrete;

namespace HotelReservation.DataAccess.Abstract
{
    public interface IHotelDal:IEntityRepository<Hotel>
    {
        List<Hotel> RandomHotels(int count);
        Hotel GetHotelDetail(int hotelId);

        List<HotelImage> GetHotelImages(int hotelId);
        List<Hotel> GetSelectedHotels(string searchString);

        //List<Hotel> SearchHotels(string keyword);
        //Custom Operations (Örn: sp çağırmak istiyoruz veya joinli sorgu yazmak istiyorsak burda yazıyoruz
    }
}
