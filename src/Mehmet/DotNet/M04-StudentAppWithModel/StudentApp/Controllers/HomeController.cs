using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentApp.Entity.Model;
using StudentApp.Repository;

namespace StudentApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (var students = new StudentRepository())
            {
                ViewBag.StudentsList = students.All;
                return View();
            }                
           
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }
        
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                using (var repo = new StudentRepository())
                {
                    var toDelete = repo.FindById(id.Value);
                    return View(toDelete);
                }
            }
            else
            {
                return View("Error", (object)"Silinecek veri bulunamadı");
            }
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            var actionResult = View();

            using (var repo = new StudentRepository())
            {
                if (repo.Delete(student))
                    return actionResult = View("Success", (Object)"Silme İşlemi Başarılı");
                else
                    return actionResult = View("Error", (Object)"Sİlme işlemi başarısız");
            }

            return actionResult;
        }

        public ActionResult Update(int? id)
        {
            if (id.HasValue)
            {
                using (var repo = new StudentRepository())
                {
                    var toUpdate = repo.FindById(id.Value);
                    return View(toUpdate);
                }                        
            } 
            else
            {
                return View("Error",(object)"Düzenlenecek veri yok");
            }            
        }

        [HttpPost]
        public ActionResult Update(Student student)
        {
            var actionResult = View();

            using (var studentRepo = new StudentRepository())
            {
                if (studentRepo.Update(student))
                    actionResult = View("Success", (object)"Güncelleme işlemi başarılı");
                else
                    actionResult = View("Error", (object)"Güncelleme işlemi gerçekleşemedi");
            }   
            
            return actionResult;
        }


        [HttpPost]
        public ActionResult Search(string keyword, bool searchName, bool searchCitizenID, bool searchAge)
        {
            IEnumerable<Student> results;
            using (var studentRepository = new StudentRepository())
            {
                results = studentRepository.Search(keyword, searchName, searchCitizenID, searchAge);                
            }
            ViewBag.FormerKeyword = keyword;
            return View(results);
        }

        [HttpPost]
        public ActionResult Index(Student student)
        {
            try
            {
                using (var studentRepo = new StudentRepository())
                {
                    studentRepo.Save(student);

                    ViewBag.Message = studentRepo.CheckBirthDay(student);

                    ViewBag.StudentsList = studentRepo.All;
                }                   
               
                return View();

            } catch (Exception ex)
            {
                return View("Error", (Object)ex.Message);
            }
        }
    }
}