using System;
using CSD.Util.Repository;

namespace CSD.AppointmentApp.Entities
{
    public class Appointment : IEntity<int>
    {
        // Bu satır bir appintmentin hangi cliente ait olduğu bilgisini bu referansla tutar (foreign key)
        public string ClientId { get; set; }

        public DateTime Date { get; set; }

        // Bu satır Appointmentin hangi client sınıfına ait olduğunu gösteriyor
        public virtual Client Client { get; set; }

        public int Id { get; set; }
        // Meali: Her Appointment bir client sahibidir. 
        // alan ismi [PropertyName]_[PropertyIDName] “client_Id”  
    }
}