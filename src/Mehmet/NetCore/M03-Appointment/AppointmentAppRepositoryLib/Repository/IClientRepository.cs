using CSD.AppointmentApp.Entities;
using CSD.Util.Repository;

namespace CSD.AppointmentApp.Repository
{
    public interface IClientRepository : ICrudRepository<Client, string>
    {
    }
}