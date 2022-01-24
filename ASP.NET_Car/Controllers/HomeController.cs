using ASP.NET_Car.Interfaces;
using ASP.NET_Car.Models;
using ASP.NET_Car.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Car.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _context;

        public HomeController(IUserRepository context)
        {
            _context = context;
        }
        #region Views
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
        #region Methods
        [HttpPost]
        public IActionResult Login(User userCredentials)
        {
            var result = _context.Login(userCredentials);
            if (result is null)
                throw new UnauthorizedAccessException("Invalid Crednetials");
            if (result.UserRole == UserRole.Admin)
            {
                return RedirectToAction("Index", "Car");
            }
            if (result.UserRole == UserRole.User)
            {
                return RedirectToAction("Index", "Shop");
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult Registration(User credentials)
        {
            if (ModelState.IsValid)
            {
                _context.Add(credentials);
                return RedirectToAction("Index");
            }
            return View(credentials);
        }
        #endregion
    }
}
