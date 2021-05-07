using System;
using System.Collections.Generic;
using StudentApp.Entity.Model;

namespace StudentApp.Repository
{
    public class StudentRepository : IDisposable
    {
        private static List<Student> ms_students;
        private static int ms_index;
        static StudentRepository()
        {
            ms_students = new List<Student>();
        }
        public IEnumerable<Student> AllStudents => ms_students;
        public Student Save(Student student)
        {
            student.Id = ++ms_index;
            ms_students.Add(student);
            return student;
        }
        public string CheckBirthDay(Student student)
        {
            DateTime Today = DateTime.Today.Date;
            DateTime BirthDay = student.BirthDate;
            DateTime BirthDayOfYear = new DateTime(Today.Year, BirthDay.Month, BirthDay.Day);

            int res = DateTime.Compare(BirthDayOfYear, Today);

            if(res < 0)
                return $"Geçmiş doğum gününüz kutlu olsun";
            if (res == 0)
                return $"Doğum gününüz kutlu olsun";
            if (res > 0)
                return $"Yaklaşan doğum gününüz kutlu olsun";

            return $"Seni anan benim için doğurmuş";
        }

        public void Dispose()
        {
            //...
        } 
    }
}
