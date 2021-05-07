using CSD.AppointmentApp.Data;
using CSD.AppointmentApp.Entities;
using CSD.Util.Repository;

namespace CSD.AppointmentApp.Repository
{
    // Bu tasarımda exception handling eden CRUD kullanmamayı tercih ettik,
    // Onun yerine servis katmanına handle ettireceğiz
    public class ClientRepository :
        CrudRepository<Client, string, AppointmentAppDbContext>,
        IClientRepository
    {
        public ClientRepository() : base(new AppointmentAppDbContext())
        {
        }
    }
}