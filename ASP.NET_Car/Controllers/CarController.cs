using ASP.NET_Car.Interfaces;
using ASP.NET_Car.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Car.API_Logic
{
    public class CarController : Controller
    {
        private readonly ICarRepository _context;
        public CarController(ICarRepository context)
        {
            _context = context;
        }

        #region Views
        public IActionResult Index()
        {
            ViewBag.ListOfCars = _context.GetCars();
            return View();
        }
        public IActionResult AddCar()
        {
            return View();
        }
        public IActionResult Edit(int? id)
        {
            var car = _context.GetCar(id);
            ViewBag.Car = car;
            return View();
        }
        public IActionResult Delete(int? id)
        {
            var car = _context.GetCar(id);
            ViewBag.CarToBeDeleted = car;
            return View();
        }
        #endregion
        #region Methods
        [HttpPost]
        public IActionResult AddCar(Cars car)
        {
            if (ModelState.IsValid)
            {
                _context.AddCar(car);
                return RedirectToAction("Index");
            }
            return View(car);
        }
        public IActionResult DeleteCar(int id)
        {
            _context.DeleteCar(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult EditCar(Cars car)
        {
            _context.EditCar(car);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
