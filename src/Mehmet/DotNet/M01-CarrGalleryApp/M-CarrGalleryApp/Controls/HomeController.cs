using System.Web.Mvc;
using CarGalleryApp.Repository;

namespace CarGalleryApp.Controls
{
    public class HomeController : Controller
    {
        private CarInfoRepository m_repository;

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllCars()
        {
            m_repository = new CarInfoRepository();
            return View(m_repository.AllCars);
        }

    }
}