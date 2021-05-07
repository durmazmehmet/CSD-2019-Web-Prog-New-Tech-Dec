using System.Collections.Generic;
using System.Threading.Tasks;
using CSD.CarInfoApp.Models;
using CSD.CarInfoApp.Repository;
using static CSD.Util.DbUtil;

namespace CSD.CarInfoApp.Services
{
    public class CarInfoService : ICarInfoService
    {
        private readonly ICarInfoRepository m_carInfoRepository;

        public CarInfoService(ICarInfoRepository carInfoRepository) => m_carInfoRepository = carInfoRepository;

        public async Task<IEnumerable<CarInfo>> All() =>
            await DoWorkForServiceAsync(() => m_carInfoRepository.FindAllAsync(), "ICarInfoService.All");

        public async Task<CarInfo> SaveCar(CarInfo carInfo) =>
            await DoWorkForServiceAsync(() => m_carInfoRepository.SaveAsync(carInfo), "ICarInfoService.Save");

        public async Task<CarInfo> GetCarInfoById(int id) =>
            await DoWorkForServiceAsync(() => m_carInfoRepository.FindByIdAsync(id), "ICarInfoService.GetCarInfoById");

        public async Task Delete(CarInfo carInfo) =>
            await DoWorkForServiceAsync(() => m_carInfoRepository.DeleteByAsync(carInfo), "ICarInfoService.Delete");
    }
}