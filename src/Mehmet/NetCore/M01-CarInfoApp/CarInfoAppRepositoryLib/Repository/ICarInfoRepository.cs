using CSD.CarInfoApp.Models;
using CSD.Util.Repository;

namespace CSD.CarInfoApp.Repository
{
    public interface ICarInfoRepository : ICrudRepository<CarInfo, int>
    {       
        
    }
}