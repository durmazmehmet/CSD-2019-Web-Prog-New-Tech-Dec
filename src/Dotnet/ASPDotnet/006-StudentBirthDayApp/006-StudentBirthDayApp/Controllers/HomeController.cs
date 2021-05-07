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

            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, string citizenId, string birthDate)
        {
            try
            {
                using (StudentRepository studentRepository = new StudentRepository())
                {
                    var birthDateVal = DateTime.Parse(birthDate);
                    var today = DateTime.Today;
                    var birthDay = new DateTime(today.Year, birthDateVal.Month, birthDateVal.Day);

                    ViewBag.Message = "Doğum gününüz kutlu olsun";

                    if (birthDay > today)
                    {
                        ViewBag.Message = "Doğum gününüz şimdiden kutlu olsun";
                    }
                    else if (birthDay < today)
                    {
                        ViewBag.Message = "Geçmiş doğum gününüz kutlu olsun";
                    }

                    var student = new Student { Name = name, BirthDate = birthDateVal, CitizenId = citizenId };
                    studentRepository.Save(student); 

                    ViewBag.StudentList = studentRepository.All;
                }                       
            }
            catch (Exception ex) { 
                //...
            }

            return View();
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
    }
}