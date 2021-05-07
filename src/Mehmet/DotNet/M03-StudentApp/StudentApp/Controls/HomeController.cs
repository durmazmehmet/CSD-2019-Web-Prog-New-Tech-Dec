using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentApp.Entity.Model;
using StudentApp.Repository;

namespace StudentApp.Controls
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (StudentRepository students = new StudentRepository())
            {
                ViewBag.Students = students.AllStudents;
            }                
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, string passportid, string birthday)
        {
            try
            {
                using (StudentRepository students = new StudentRepository())
                {
                    DateTime BirthDayVal = DateTime.Parse(birthday);
                    Student student = new Student { Id = 0, Name = name, PassportId = passportid, BirthDate = BirthDayVal };

                    students.Save(student);

                    ViewBag.Message = students.CheckBirthDay(student);

                    ViewBag.Students = students.AllStudents;
                }                   
               
                return View();

            } catch (Exception ex)
            {
                return View("Error", (Object)ex.Message);
            }
        }
    }
}