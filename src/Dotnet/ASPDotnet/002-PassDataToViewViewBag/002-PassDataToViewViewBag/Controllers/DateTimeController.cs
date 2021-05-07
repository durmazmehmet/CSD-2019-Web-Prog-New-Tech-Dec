using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _002_PassDataToViewViewBag.Controllers
{
    public class DateTimeController : Controller
    {
        // GET: DateTime
        public ActionResult Now()
        {
            ViewBag.Now = DateTime.Now;

            return View();
        }
    }
}