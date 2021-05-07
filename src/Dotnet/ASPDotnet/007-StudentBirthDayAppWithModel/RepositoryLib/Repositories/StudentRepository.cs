using StudentBirthDayApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBirthDayApp.Repositories
{
    public class StudentRepository : IDisposable
    {
        private static List<Student> ms_students = new List<Student>();
        private static int ms_index;

        public Student Save(Student student)
        {
            student.Id = ++ms_index;
            ms_students.Add(student);

            return student;
        }

        public IEnumerable<Student> All => ms_students;

        public Student FindById(int id)
        {
            var index = ms_students.IndexOf(new Student { Id = id });

            return index == -1 ? null : ms_students[index];
        }


        public bool ExistById(int id)
        {
            return FindById(id) != null;
        }

        public IEnumerable<Student> FindByNameStartsWith(String name)
        {
            var list = new List<Student>();

            foreach (var s in ms_students)
                if (s.Name.StartsWith(name))
                    list.Add(s);            

            return list;
        }

        public bool Update(Student student)
        {
            var index = ms_students.IndexOf(student);

            if (index < 0)
                return false;            
            ms_students[index].Name = student.Name;
            ms_students[index].CitizenId = student.CitizenId;
            ms_students[index].BirthDate = student.BirthDate;

            return true;
        }

        public void Dispose()
        {
            //...
        }
    }
}
