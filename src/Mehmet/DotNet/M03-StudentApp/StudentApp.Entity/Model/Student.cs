using System;

namespace StudentApp.Entity.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PassportId { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString() => $"[{Id}]:{Name}({PassportId}), {BirthDate}";
        
    }
}
