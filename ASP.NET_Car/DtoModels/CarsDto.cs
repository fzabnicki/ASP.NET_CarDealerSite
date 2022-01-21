using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Car.DtoModels
{
    public class CarsDto
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public DateTime ProductionDate { get; set; }
        public decimal Price { get; set; }
    }
}
