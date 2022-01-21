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
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private readonly ICarsLogic _carsLogic;
        public CarController(ICarsLogic carsLogic)
        {
            _carsLogic = carsLogic;
        }
        [HttpGet]
        public async Task<List<CarsDto>> GetCarsAsync()
        {
            return await _carsLogic.GetCarsAsync();
        }
        [HttpGet("{id}")]
        public async Task<CarsDto> GetCarAsync(int id)
        {
            return await _carsLogic.GetCarAsync(id);
        }
        [HttpPost]
        public async Task AddNewCarAsync(CarsDto car)
        {
            await _carsLogic.AddNewCarAsync(car);
        }
        [HttpPut]
        public async Task EditCarAsync(CarsDto car)
        {
            await _carsLogic.EditCarAsync(car);
        }
        [HttpDelete]
        public async Task DeleteCarAsync(int id)
        {
            await _carsLogic.DeleteCarAsync(id);
        }
    }
}
