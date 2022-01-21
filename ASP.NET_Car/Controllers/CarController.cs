using ASP.NET_Car.DtoModels;
using ASP.NET_Car.Interfaces;
using ASP.NET_Car.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Car.API_Logic
{
    public class CarController : Controller
    {
        private readonly ICarsLogic _carsLogic;
        public CarController(ICarsLogic carsLogic)
        {
            _carsLogic = carsLogic;
        }

        #region Views
        public IActionResult Index()
        {
            //ViewBag.ListOfCars = GetCarsAsync();
            return View();
        }

        public IActionResult AddCar()
        {
            return View();
        }
        #endregion

        #region ApiMethods
        public async Task<List<CarsDto>> GetCarsAsync()
        {
            return await _carsLogic.GetCarsAsync();
        }
        public async Task<CarsDto> GetCarAsync(int id)
        {
            return await _carsLogic.GetCarAsync(id);
        }
        public async Task AddNewCarAsync(CarsDto car)
        {
            await _carsLogic.AddNewCarAsync(car);
        }
        public async Task EditCarAsync(CarsDto car)
        {
            await _carsLogic.EditCarAsync(car);
        }
        public async Task DeleteCarAsync(int id)
        {
            await _carsLogic.DeleteCarAsync(id);
        }
        #endregion
    }
}
