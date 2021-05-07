using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarGalleryApp.Repository.Repository;
using CSD.CarGalleryApp.Models;

namespace CSD.CarGalleryApp.Controllers
{
    public class HomeController : Controller
    {
        private CarInfoRepository m_repository;

        public HomeController()
        {
            m_repository = new CarInfoRepository();
        }

        // GET: Home
        public ActionResult AllCars()
        {
            ViewBag.Title = "All Cars";
            return View("Cars", m_repository.AllCars);
        }
    }
}