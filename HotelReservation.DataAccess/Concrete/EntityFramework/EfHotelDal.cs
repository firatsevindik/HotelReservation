using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.DataAccess.Concrete.EntityFramework
{
    public class EfHotelDal:EfEntityRepositoryBase<Hotel, HotelDbContext>,IHotelDal
    {
        public List<Hotel> RandomHotels(int count)
        {
            using (var context = new HotelDbContext())
            {
                return context.Hotel
                    .Include(x => x.HotelImage)
                    .Include(x => x.HotelScore)
                    .AsEnumerable()
                    .OrderBy(x => Guid.NewGuid())
                    .Take(count)
                    .ToList();
            }
        }

        public Hotel GetHotelDetail(int hotelId)
        {
            using (var context = new HotelDbContext())
            {
                return context.Hotel
                    .Where(p => p.Id == hotelId)
                    .Include(x => x.HotelImage)
                    .Include(x=>x.HotelScore)
                    .Include(x=>x.HotelAddress)
                    .FirstOrDefault();

            }
        }

        public List<HotelImage> GetHotelImages(int hotelId)
        {
            using (var context = new HotelDbContext())
            {
                return context.HotelImage.Where(p => p.HotelId == hotelId).ToList();
            }
        }

        public List<Hotel> GetSelectedHotels(string searchString)
        {
            using (var context = new HotelDbContext())
            {
                return context.Hotel
                    .Include(x => x.HotelAddress)
                    .Include(x=>x.HotelImage)
                    .Include(x=>x.HotelScore)
                    .Where(p=>p.Name.ToLower().Contains(searchString.ToLower()) || p.Description.ToLower().Contains(searchString.ToLower()) || p.HotelAddress.AddressText.ToLower().Contains(searchString.ToLower()))
                    .ToList();
            }
        }

        //public List<Hotel> SearchHotels(string keyword)
        //{
        //    using (var context = new HotelDbContext())
        //    {
        //        return context.Hotel.Where(p => p.Name.Contains(keyword)).ToList();
        //    }
        //}
    }
}
