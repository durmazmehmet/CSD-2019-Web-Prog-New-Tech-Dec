using System.Collections.Generic;
using System.Threading.Tasks;
using CSD.AppointmentApp.Entities;
using CSD.Util.Repository;

namespace CSD.AppointmentApp.Repository
{
    public interface IAppointmentRepository : ICrudRepository<Appointment, int> 
    {
        Task<IEnumerable<Appointment>> FindAppointments(Client client, int month = 0);
    }
}