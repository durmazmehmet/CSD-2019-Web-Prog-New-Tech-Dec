using System.Collections.Generic;
using System.Threading.Tasks;
using CSD.AppointmentApp.Entities;
using CSD.AppointmentApp.Repository;
using static CSD.Util.DbUtil;

//Client ve Appointment repositorileri için tek servis olarak tasarlamayı seçtik
//Servis tasarımını ilişkileri göz önüne almak lazım, ilişkili sınıfların repolarını ortak sevise alabiliriz..
//Eğer client ile appointment ilişkili olmasaydı ayrı sevislere koyabilirdik.

namespace CSD.AppointmentApp.Service
{
    public class AppointmentAppService : IAppointmentAppService
    {
        private readonly IAppointmentRepository m_appointmentRepository;

        //Dep. Inject. hemen (her iki sınıf için de)        
        private readonly IClientRepository m_clientRepository;

        public AppointmentAppService(IClientRepository clientRepository, IAppointmentRepository appointmentRepository)
        {
            m_clientRepository = clientRepository;
            m_appointmentRepository = appointmentRepository;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
            => await DoWorkForServiceAsync(() => m_appointmentRepository.FindAllAsync(),
                "AppointmentAppService.GetAllAppointments");

        public async Task<IEnumerable<Client>> GetAllClients()
            => await DoWorkForServiceAsync(() => m_clientRepository.FindAllAsync(),
                "AppointmentAppService.GetAllClients");

        public async Task<Client> SaveClient(Client client)
            => await DoWorkForServiceAsync(() => m_clientRepository.SaveAsync(client),
                "AppointmentAppService.SaveClient");

        public async Task<Client> FindByCitizenID(string id) => await DoWorkForServiceAsync(
            () => m_clientRepository.FindByIdAsync(id),
            "AppointmentAppService.FindByCitizenID");

        public async Task DeleteClient(Client client) => await DoWorkForServiceAsync(
            () => m_clientRepository.DeleteByAsync(client),
            "AppointmentAppService.DeleteClient");

        public async Task DeleteAppointments(Appointment appointment) => await DoWorkForServiceAsync(
            () => m_appointmentRepository.DeleteByAsync(appointment),
            "AppointmentAppService.DeleteAppointments");

        public async Task<IEnumerable<Appointment>> FindAppointmentsByClient(Client client) =>
            await DoWorkForServiceAsync(
                () => m_appointmentRepository.FindAppointments(client),
                "AppointmentAppService.FindAppointments");
        public async Task<IEnumerable<Appointment>> FindAppointmentsByClientAndMonth(Client client, int month) =>
            await DoWorkForServiceAsync(
                () => m_appointmentRepository.FindAppointments(client, month),
                "AppointmentAppService.FindAppointmentByClientAndMonthAsync");
    }
}