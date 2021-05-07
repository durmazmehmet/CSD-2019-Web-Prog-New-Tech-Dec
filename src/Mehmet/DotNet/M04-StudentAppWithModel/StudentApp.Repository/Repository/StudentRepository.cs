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
            ms_students.Add(new Student { Id = 1, Name = "mehmet", BirthDate = new DateTime(1983,2,19), CitizenId = "323" }) ;
        }
        public IEnumerable<Student> Search (string keyword, bool searchName, bool searchCitizenID, bool searchAge)
        {
            var Result = new List<Student>();      
                        
            foreach (var s in ms_students)
            {
                if (searchName)
                    if (s.Name.StartsWith(keyword))
                        if (!ExistById(s.Id))
                            Result.Add(s);

                if(searchCitizenID)
                    if (s.CitizenId.StartsWith(keyword))
                        if (!ExistById(s.Id))
                            Result.Add(s);

                if (searchAge)      
                    if(Double.TryParse(keyword, out var ageKeyword))
                        if(s.Age.Equals(ageKeyword))
                            if (!ExistById(s.Id))
                                Result.Add(s);
            } 
            return Result;
        }


        public bool ExistById(int id)
        {
            return FindById(id) != null;
        }
        public Student FindById(int id)
        {
            var index = ms_students.IndexOf(new Student { Id = id });

            return index == -1 ? null : ms_students[index];
        }
        public IEnumerable<Student> All => ms_students;
        public Student Save(Student student)
        {
            student.Id = ++ms_index;
            ms_students.Add(student);     
            return student;
        }
        public bool Update(Student student)
        {
            int index = ms_students.IndexOf(student);

            if (index < 0)
                return false;

            ms_students[index].Name = student.Name;
            ms_students[index].BirthDate = student.BirthDate;
            ms_students[index].CitizenId = student.CitizenId;

            return true;
        }
        public bool Delete(Student student)
        {
            int index = ms_students.IndexOf(student);
            if (index < 0)
                return false;

            ms_students.RemoveAt(index);
            return true;
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
