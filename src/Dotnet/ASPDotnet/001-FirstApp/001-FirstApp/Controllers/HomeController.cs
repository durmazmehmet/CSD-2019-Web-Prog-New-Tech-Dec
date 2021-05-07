using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _001_FirstApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home        
        public string Index()
        {
            return "Merhaba ASP.NET";
        }

        public string Hello() 
        {
            return "Merhaba";
        }
    }
}