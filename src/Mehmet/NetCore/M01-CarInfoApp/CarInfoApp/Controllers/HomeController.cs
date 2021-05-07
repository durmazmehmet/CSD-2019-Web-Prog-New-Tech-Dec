using System.Threading.Tasks;
using CSD.CarInfoApp.Models;
using CSD.CarInfoApp.Services;
using CSD.Util.Service;
using Microsoft.AspNetCore.Mvc;
using static CSD.CarInfoApp.Globals.Global;


namespace CSD.CarInfoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarInfoService m_carInfoService;

        public HomeController(ICarInfoService carInfoService) => m_carInfoService = carInfoService;

        public IActionResult Index() => View();

        public IActionResult Insert() => View();

        [HttpPost]
        public async Task<IActionResult> Insert(CarInfo carInfo)
        {
            IActionResult actionResult = View(ERROR);

            try
            {
                await m_carInfoService.SaveCar(carInfo);

                actionResult = View(DETAILS, carInfo);
            }
            catch (ServiceException ex)
            {
                ViewData[MESSAGE] = ex.Message;
            }

            return actionResult;
        }

        public async Task<IActionResult> List() => View(await m_carInfoService.All());

        public async Task<IActionResult> Edit(int id)
        {
            IActionResult actionResult = View(ERROR);

            try
            {
                actionResult = View(await m_carInfoService.GetCarInfoById(id));
            }
            catch (ServiceException ex)
            {
                ViewData[MESSAGE] = ex.Message;
            }

            return actionResult;
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarInfo carInfo)
        {
            IActionResult actionResult = View(ERROR);
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var car = await m_carInfoService.GetCarInfoById(carInfo.Id);

                if (car == null)
                    return View(ERROR);

                car.Model = carInfo.Model;
                car.Date = carInfo.Date;
                car.EngineId = carInfo.EngineId;
                car.Brand = carInfo.Brand;

                await m_carInfoService.SaveCar(car);

                actionResult = View(LIST, await m_carInfoService.All());
            }
            catch (ServiceException ex)
            {
                ViewData[MESSAGE] = ex.Message;
            }

            return actionResult;
        }

        public async Task<IActionResult> Delete(int id) => View(await m_carInfoService.GetCarInfoById(id));

        [HttpPost]
        public async Task<IActionResult> Delete(CarInfo carInfo)
        {
            IActionResult actionResult = View(ERROR);

            try
            {
                await m_carInfoService.Delete(carInfo);
                actionResult = View(LIST, await m_carInfoService.All());
            }
            catch (ServiceException ex)
            {
                ViewData[MESSAGE] = ex.Message;
            }

            return actionResult;
        }

        public IActionResult Details(CarInfo car)
        {
            IActionResult actionResult = View(ERROR);

            try
            {
                actionResult = View(car);
            }
            catch (ServiceException ex)
            {
                ViewData[MESSAGE] = ex.Message;
            }

            return actionResult;
        }
    }
}