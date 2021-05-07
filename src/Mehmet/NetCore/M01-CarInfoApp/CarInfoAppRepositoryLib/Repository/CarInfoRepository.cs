using CSD.CarInfoApp.Data;
using CSD.CarInfoApp.Models;
using CSD.Util.Repository;

namespace CSD.CarInfoApp.Repository
{
    public class CarInfoRepository :
        CrudRepositoryEx<CarInfo, int, CarInfoDbContext>,
        ICarInfoRepository
    {
        public CarInfoRepository() : base(new CarInfoDbContext()) { } //Burayı unuttun, unutma
    }
}
