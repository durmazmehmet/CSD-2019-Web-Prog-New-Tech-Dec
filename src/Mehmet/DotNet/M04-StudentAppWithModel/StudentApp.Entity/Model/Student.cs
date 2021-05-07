using System;

namespace StudentApp.Entity.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CitizenId { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString() => $"[{Id}]:{Name}({CitizenId}), {BirthDate}";
        public double Age => Math.Round((DateTime.Today - BirthDate).TotalDays / 365, 0);
        public override bool Equals(object obj)
        {
            return Id == ((Student)obj).Id;
        }
    }
}
