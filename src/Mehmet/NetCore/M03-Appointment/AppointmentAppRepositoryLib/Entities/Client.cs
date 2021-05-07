using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CSD.Util.Repository;

// Nagivation property. Tablolar arasındaki ilişkileri EF ile tespit eder  
// Nav Property der ki: Ben bir client'dan başlayıp onun appointmentlerini dolaşıpi
// herhangi bir appointmentten de client'e dönebilirim demektir.  

//ICollection:
//IEnumerable arayüzünü kullanır. Farklı olarak;
//Add element ekleyen
//Remove element silen
//Contains ​elementin varlığını sınayan 
//metodları vardır.

//HasSet:
//In C#, HashSet is an unordered collection of unique elements. This collection is introduced //in .NET 3.5. It supports the implementation of sets and uses the hash table for storage.

namespace CSD.AppointmentApp.Entities
{
    public class Client : IEntity<string>
    {
        // Bu satır bu sınıf (client) appointmentlerini temsil ediyor
        // Bir clientin hangi appointmentlere sahip olduğu bilgisi bu kolleksiyonla tutulur.
        // Yani bir cliente appointment ekleyeceğimizde BU SINIFDAKİ appointments ile yapacak
        // HashSet oluşturmuş scaffold ancak IEnumerable herhengi bir koleksiyon kullanılabilir.
        public Client() => Appointments = new HashSet<Appointment>();

        [Required(ErrorMessage = "Please input Your Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please input Your Phone")]
        public string Phone { get; set; }

        // Appointment sınıfı açılımlı Icollection field'i autoproperty ile tanımlanıyor
        public virtual ICollection<Appointment> Appointments { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "Lenght must be 11")]
        [Required(ErrorMessage = "Please input Your Citizen ID with 11 digits")]
        public string Id { get; set; }
    }
}