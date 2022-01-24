using ASP.NET_Car.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Car.Interfaces
{
    public interface ICarRepository
    {
        Cars AddCar(Cars car);
        Cars DeleteCar(int? id);
        Cars EditCar(Cars car);
        List<Cars> GetCars();
        Cars GetCar(int? id);
    }
}
