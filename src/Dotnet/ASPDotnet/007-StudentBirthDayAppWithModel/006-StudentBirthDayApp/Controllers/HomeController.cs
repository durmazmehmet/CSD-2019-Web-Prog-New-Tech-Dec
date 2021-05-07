using StudentBirthDayApp.Entities;
using StudentBirthDayApp.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _006_StudentBirthDayApp.Controllers
{
    public class HomeController : Controller
    {        
        // GET: Home
        public ActionResult Index()
        {
            
            using (StudentRepository studentRepository = new StudentRepository())
            {
                ViewBag.Today = DateTime.Today;
                ViewBag.StudentList = studentRepository.All;
            }

            return View(new Student { Name = "Lokman"});
        }

        [HttpPost]
        public ActionResult Index(Student student)
        {
            try
            {
                using (StudentRepository studentRepository = new StudentRepository())
                {
                    var birthDate = student.BirthDate;
                    var today = DateTime.Today;
                    var birthDay = new DateTime(today.Year, birthDate.Month, birthDate.Day);

                    ViewBag.Message = "Doğum gününüz kutlu olsun";

                    if (birthDay > today)
                    {
                        ViewBag.Message = "Doğum gününüz şimdiden kutlu olsun";
                    }
                    else if (birthDay < today)
                    {
                        ViewBag.Message = "Geçmiş doğum gününüz kutlu olsun";
                    }
                    
                    studentRepository.Save(student); 

                    ViewBag.StudentList = studentRepository.All;
                }                       
            }
            catch (Exception ex) { 
                //...
            }

            return View(student);
        }


        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchText)
        {
            IEnumerable<Student> students;

            using (var studentRepository = new StudentRepository())
            {
                students = studentRepository.FindByNameStartsWith(searchText);
            }

            return View(students);
        }
        
        public ActionResult Update(int id)
        {
            using (StudentRepository studentRepository = new StudentRepository())
            {
                var s = studentRepository.FindById(id);

                return s == null ? View("Error") : View(s);
            }
        }

        [HttpPost]
        public ActionResult Update(Student s)
        {
            using (StudentRepository studentRepository = new StudentRepository())
            {
                if (studentRepository.Update(s))
                    return View("Success", s);

                return View("Error");
            }            
        }
    }
}