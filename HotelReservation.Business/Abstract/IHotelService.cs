using System;
using System.Collections.Generic;
using System.Text;
using HotelReservation.DataAccess.Concrete.EntityFramework;
using HotelReservation.Entity.Concrete;

namespace HotelReservation.Business.Abstract
{
    public interface IHotelService
    {
        List<Hotel> GetAll();
        Hotel GetHotelById(int id);
        void Add(Hotel hotel);
        void Update(Hotel hotel);
        void Delete(int hotelId);
        List<Hotel> GetRandomHotels(int count);
        List<Hotel> SearchHotels(string keyword);
        List<HotelImage> GetHotelImagesByHotelId(int hotelId);
        Hotel GetHotelDetail(int hotelId);
        List<Hotel> GetSelectedHotels(string searchString);

    }
}
