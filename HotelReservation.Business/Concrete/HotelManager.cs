using System;
using System.Collections.Generic;
using System.Text;
using HotelReservation.Business.Abstract;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.DataAccess.Concrete.EntityFramework;
using HotelReservation.Entity.Concrete;

namespace HotelReservation.Business.Concrete
{
    public class HotelManager:IHotelService
    {
        private IHotelDal _hotelDal;

        public HotelManager(IHotelDal hotelDal)
        {
            _hotelDal = hotelDal;
        }

        public List<Hotel> GetAll()
        {
            return _hotelDal.GetList();
        }

        public Hotel GetHotelById(int id)
        {
            return _hotelDal.Get(p => p.Id == id);
        }


        public List<Hotel> GetRandomHotels(int count)
        {
            return _hotelDal.RandomHotels(count);
        }

        public List<Hotel> SearchHotels(string keyword)
        {
            return _hotelDal.GetList(p => p.Name.Contains(keyword));
        }

        public List<HotelImage> GetHotelImagesByHotelId(int hotelId)
        {
            return _hotelDal.GetHotelImages(hotelId);
        }

        public Hotel GetHotelDetail(int hotelId)
        {
            return _hotelDal.GetHotelDetail(hotelId);
        }

        public List<Hotel> GetSelectedHotels(string searchString)
        {
            return _hotelDal.GetSelectedHotels(searchString);
        }

        public void Add(Hotel hotel)
        {
            _hotelDal.Add(hotel);
        }

        public void Update(Hotel hotel)
        {
            _hotelDal.Update(hotel);
        }

        public void Delete(int hotelId)
        {
            _hotelDal.Delete(new Hotel{Id = hotelId});
        }
    }
}
