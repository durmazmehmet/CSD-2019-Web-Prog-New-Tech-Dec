using System.Collections.Generic;
using CarGalleryApp.Models;

namespace CarGalleryApp.Repository
{
    public class CarInfoRepository
    {
        private static List<CarInfo> ms_Cars;
        static CarInfoRepository()
        {
            ms_Cars = new List<CarInfo>();
            ms_Cars.Add(new CarInfo { Id = 1, Description = "Renault", Plate = "34CLU517", Price = 96000.90M });
            ms_Cars.Add(new CarInfo { Id = 1, Description = "Mercedes", Plate = "34CLU517", Price = 196000.90M });
            ms_Cars.Add(new CarInfo { Id = 1, Description = "Ferrari", Plate = "34CLU517", Price = 1196000.90M });
        }
        public IEnumerable<CarInfo> AllCars => ms_Cars;
    }
}
