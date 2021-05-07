using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormdanModele.Model.Entity;

namespace FormdanModele.Controllers
{
    public class HomeController : Controller
    {
         // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Ürün Bilgi Formu";
            ViewData["Date"] = DateTime.Today;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, string stock, string unitPrice, string cost)
        {
            var actionResult = View();

            try
            {
                var stockVal = uint.Parse(stock);
                var unitPriceVal = decimal.Parse(unitPrice);
                var costVal = decimal.Parse(unitPrice);

                var product = new Product {Name = name, Stock = stockVal, UnitPrice = unitPriceVal, Cost = costVal};

                actionResult = View("Result", product);
            }
            catch (Exception ex)
            {
                actionResult = View("Error", (object)ex.Message);
            }

            return actionResult;
        }
    }
}