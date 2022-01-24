using ASP.NET_Car.Interfaces;
using ASP.NET_Car.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Car.Repository
{
    public class CarRepository : ICarRepository
    {
        private DataContext _context;
        public CarRepository(DataContext context)
        {
            _context = context;
        }
        public Cars AddCar(Cars car)
        {
            _context.Add(car);
            _context.SaveChanges();
            return car;
        }

        public Cars DeleteCar(int? id)
        {
            var car = GetCar(id);
            _context.Remove(car);
            _context.SaveChanges();
            return car;
        }

        public Cars EditCar(Cars car)
        {
            _context.Update(car);
            _context.SaveChanges();
            return car;
        }

        public Cars GetCar(int? id)
        {
            return _context.Cars.FirstOrDefault(c => c.ID == id);
        }

        public List<Cars> GetCars()
        {
            return _context.Cars.ToList();
        }
    }
}
