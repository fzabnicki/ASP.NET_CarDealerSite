using ASP.NET_Car.DtoModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.NET_Car.Interfaces
{
    public interface ICarsLogic
    {
        Task<List<CarsDto>> GetCarsAsync();
        Task<CarsDto> GetCarAsync(int id);
        Task AddNewCarAsync(CarsDto car);
        Task EditCarAsync(CarsDto car);
        Task DeleteCarAsync(int id);
    }
}
