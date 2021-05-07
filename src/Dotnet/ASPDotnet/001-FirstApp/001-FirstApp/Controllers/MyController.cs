using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _001_FirstApp.Controllers
{
    public class MyController : Controller
    {
        private Random m_rand = new Random();

        // GET: My
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rand()
        {
            int val = m_rand.Next(1, 100);

            return View("Random");            
        }
    }
}