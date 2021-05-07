using CSD.CarGalleryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGalleryApp.Repository.Repository
{    
    public class CarInfoRepository
    {
        private static List<CarInfo> ms_cars;
        static CarInfoRepository()
        {
            ms_cars = new List<CarInfo>();
            ms_cars.Add(new CarInfo { Id = 1, Description = "Mercedes", Plate = "34 ABC 45", Price = 249999.9M });
            ms_cars.Add(new CarInfo { Id = 2, Description = "Porche", Plate = "35 ABC 55", Price = 249999.9M });
            ms_cars.Add(new CarInfo { Id = 3, Description = "Ferrari", Plate = "34 ABC 34", Price = 249999.9M });
        }
        public IEnumerable<CarInfo> AllCars => ms_cars;
        
    }
}
