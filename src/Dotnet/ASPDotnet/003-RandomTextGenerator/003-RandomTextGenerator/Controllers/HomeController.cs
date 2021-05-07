using CSD.UtilLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _003_RandomTextGenerator.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Random()
        {
            ViewBag.TextTR = StringUtil.GetRandomTextTR(10);
            ViewBag.TextEN = StringUtil.GetRandomTextEN(10);

            return View();
        }
    }
}