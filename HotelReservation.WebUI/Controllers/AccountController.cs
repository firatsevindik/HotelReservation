using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                return RedirectToAction("Index", "Hotel");
            }
            return View();
        }


        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            var user = _userService.Login(userName, password);

            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("UserName", user.UserName);
                TempData["Message"] = "Success Login Welcome " + user.UserName.ToUpper();
                return RedirectToAction("Index", "Hotel");
            }
            else
            {
                TempData["Message"] = "Username or Password Incorrect.";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("userId", "");
            HttpContext.Session.SetString("userName", "");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Hotel");
        }
    }
}