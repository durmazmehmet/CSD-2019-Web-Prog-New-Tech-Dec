using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBirthDayApp.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CitizenId { get; set; }
        public DateTime BirthDate { get; set; }
        public double Age => (DateTime.Today - BirthDate).TotalDays / 365;
    }
}
