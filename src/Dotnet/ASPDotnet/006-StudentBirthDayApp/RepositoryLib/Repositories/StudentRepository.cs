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

        public IEnumerable<Student> FindByNameStartsWith(String name)
        {
            var list = new List<Student>();

            foreach (var s in ms_students)
                if (s.Name.StartsWith(name))
                    list.Add(s);            

            return list;
        }

        public void Dispose()
        {
            //...
        }
    }
}
