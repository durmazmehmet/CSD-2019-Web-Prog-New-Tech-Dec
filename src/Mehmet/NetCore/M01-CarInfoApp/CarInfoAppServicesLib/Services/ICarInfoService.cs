using CSD.CarInfoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSD.CarInfoApp.Services
{
    public interface ICarInfoService
    {
        Task<IEnumerable<CarInfo>> All();
        Task Delete(CarInfo carInfo);
        Task<CarInfo> GetCarInfoById(int id);
        Task<CarInfo> SaveCar(CarInfo carInfo);
    }
}