using _005_FormAppWithAllData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _005_FormAppWithAllData.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Ürün bilgi Formu";
            ViewData["Date"] = DateTime.Today;

            return View();
        }


        [HttpPost]
        public ActionResult Index(string name, string stock, string unitPrice, string cost)
        {
            var actionResult = View();

            try
            {
                //...
                var stockVal = uint.Parse(stock);
                var unitPriceVal = decimal.Parse(unitPrice);
                var costVal = decimal.Parse(cost);

                actionResult = View("Result",
                    new Product { Name = name, Stock = stockVal, Cost = costVal, UnitPrice = unitPriceVal });
                
            }
            catch (Exception ex) {
                actionResult = View("Error", (object)ex.Message);
            }

            return actionResult;
        }
    }
}