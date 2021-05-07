using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSD.AppointmentApp.Data;
using CSD.AppointmentApp.Entities;
using CSD.Util.Repository;
using Microsoft.EntityFrameworkCore;
using static CSD.Util.DbUtil;

namespace CSD.AppointmentApp.Repository
{
    public class AppointmentRepository :
        CrudRepositoryEx<Appointment, int, AppointmentAppDbContext>,
        IAppointmentRepository
    {
        public AppointmentRepository() : base(new AppointmentAppDbContext())
        {
        }

        public async Task<IEnumerable<Appointment>> FindAppointments(Client client, int month = 0)
        {
            if (month != 0)
            {
                return await DoWorkForRepositoryAsync(() => Ctx.Clients.First(c => c.Id == client.Id).Appointments.Where(a => a.Date.Month == month),
                    "Service.FindAppointmentByClientAndMonthAsync");
            }
            else
            {
                return await  DoWorkForRepositoryAsync(() => Ctx.Appointments.Where(a => a.ClientId == client.Id),
                    "Service.FindAppointmentByClient");
            }
        }
           
    }
}