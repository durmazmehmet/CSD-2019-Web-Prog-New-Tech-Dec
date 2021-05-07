using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _002_PassDataToViewViewBag.Controllers
{
    public class HomeController : Controller
    {
        private Random m_rand = new Random();

        // GET: Home
        public ActionResult Rand()
        {
            int val = m_rand.Next(1, 100);

            ViewBag.Val = val; //ViewData["Val"] = val;

            return View("Random");
        }
    }
}