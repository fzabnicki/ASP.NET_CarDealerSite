using ASP.NET_Car.Interfaces;
using ASP.NET_Car.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Car.Controllers
{
    public class ShopController : Controller
    {
        private readonly ICarRepository _context;
        int counter = 0;
        public ShopController(ICarRepository context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Cart = counter;
            ViewBag.ListOfCars = _context.GetCars();
            return View();
        }
        public IActionResult ShoppingCart()
        {
            return View();
        }
        public IActionResult Buy()
        {
            counter++;
            return View("Index");
        }
    }
}
