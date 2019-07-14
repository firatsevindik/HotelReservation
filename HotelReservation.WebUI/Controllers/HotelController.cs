using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservation.Business.Abstract;
using HotelReservation.Entity.Concrete;
using HotelReservation.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public IActionResult Index(string searchString)
        {
            var model = String.IsNullOrEmpty(searchString) 
                ? _hotelService.GetRandomHotels(count: 5) 
                : _hotelService.GetSelectedHotels(searchString);

            return View(model);
        }

        public IActionResult HotelDetail(int hotelId)
        {
            var model = _hotelService.GetHotelDetail(hotelId);
            return View(model);
        }
    }
}