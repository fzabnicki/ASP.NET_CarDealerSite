using ASP.NET_Car.DtoModels;
using ASP.NET_Car.Interfaces;
using ASP.NET_Car.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Car.Logic
{
    public class CarsLogic : ICarsLogic
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CarsLogic(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddNewCarAsync(CarsDto carDto)
        {
            var car = _mapper.Map<CarsDto, Cars>(carDto);
            _context.Cars.Add(car);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(int id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(c => c.ID == id);
            _context.Cars.Remove(car);

            await _context.SaveChangesAsync();
        }

        public async Task EditCarAsync(CarsDto carDto)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(c => c.ID == carDto.ID);
            _mapper.Map<CarsDto, Cars>(carDto, car);

            await _context.SaveChangesAsync();
        }

        public async Task<List<CarsDto>> GetCarsAsync()
        {
            var car = await _context.Cars.ToListAsync();
            var mappedCar = _mapper.Map<List<Cars>, List<CarsDto>>(car);

            return mappedCar;
        }

        public async Task<CarsDto> GetCarAsync(int id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(c => c.ID == id);
            var mappedCar = _mapper.Map<Cars, CarsDto>(car);

            return mappedCar;
        }
    }
}
