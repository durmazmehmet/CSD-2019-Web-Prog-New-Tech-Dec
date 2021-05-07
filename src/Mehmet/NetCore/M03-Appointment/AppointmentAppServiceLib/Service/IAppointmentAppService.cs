using System.Collections.Generic;
using System.Threading.Tasks;
using CSD.AppointmentApp.Entities;

namespace CSD.AppointmentApp.Service
{
    public interface IAppointmentAppService
    {
        Task<IEnumerable<Appointment>> GetAllAppointments();
        Task<IEnumerable<Client>> GetAllClients();
        Task<Client> SaveClient(Client client);
        Task<Client> FindByCitizenID(string id);
        Task<IEnumerable<Appointment>> FindAppointmentsByClient(Client client);
        Task<IEnumerable<Appointment>> FindAppointmentsByClientAndMonth(Client client, int month);
        Task DeleteClient(Client client);
        Task DeleteAppointments(Appointment appointment);
    }
}