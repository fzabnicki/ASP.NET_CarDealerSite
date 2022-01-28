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
        private readonly IShoppingCartRepository _shopContext;
        private readonly IUserRepository _userContext;
        public ShopController(ICarRepository context, IShoppingCartRepository shopContext, IUserRepository userContext)
        {
            _context = context;
            _shopContext = shopContext;
            _userContext = userContext;
        }
        public IActionResult Index(User loggedIn)
        {
            ViewBag.User = loggedIn;
            if(loggedIn.ShoppingCart != null)
                ViewBag.Cart = loggedIn.ShoppingCart.ShoppingList.Count;
            ViewBag.ListOfCars = _context.GetCars();
            return View();
        }
        public IActionResult ShoppingCart(int id)
        {
            var user = _userContext.Find(id);
            ViewBag.User = user;
            ViewBag.Bucket = user.ShoppingCart.ShoppingList;
            return View();
        }
        public IActionResult Buy(int? id, int userID)
        {
            var car = _context.GetCar(id);
            ViewBag.Car = car;
            ViewBag.User = _userContext.Find(userID);
            return View();
        }

        public IActionResult AddCarToShoppingCart(int? id,int userID)
        {
            _shopContext.AddToBucket(userID, id);
            var user = _userContext.Find(userID);
            return RedirectToAction("Index", user);
        }
    }
}
