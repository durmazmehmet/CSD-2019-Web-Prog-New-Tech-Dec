using System;
using System.Threading.Tasks;
using CSD.AppointmentApp.Entities;
using CSD.AppointmentApp.Service;
using CSD.AppointmentApp.ViewModels;
using CSD.Util.Service;
using Microsoft.AspNetCore.Mvc;
using static CSD.AppointmentApp.Globals.Globals;

namespace CSD.AppointmentApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppointmentAppService m_appointmentAppService;

        public HomeController(IAppointmentAppService appointmentAppService) =>
            m_appointmentAppService = appointmentAppService;


        private Client GetClient(ClientViewModel clientViewModel)
        {
            var client = new Client
            {
                Id = clientViewModel.Client.Id,
                Email = clientViewModel.Client.Email,
                Phone = clientViewModel.Client.Phone
            };

            client.Appointments.Add(new Appointment {Date = clientViewModel.Date}); //navigasyon propertisi çalıştırdık

            return client;
        }

        public IActionResult Index()
        {
            ViewBag.Today = DateTime.Today;

            return View();
        }

        public IActionResult BookAppointment() => View();

        [HttpPost]
        public async Task<IActionResult> BookAppointment(ClientViewModel clientViewModel)
        {
            IActionResult actionResult = View(ERROR);

            try
            {
                if (!ModelState.IsValid)
                    return View();

                var client = await m_appointmentAppService.FindByCitizenID(clientViewModel.Client.Id);

                if (client != null)
                {
                    clientViewModel.Client = client;
                    actionResult = View(BOOK, clientViewModel);
                }
                else
                {
                    client = GetClient(clientViewModel);
                    await m_appointmentAppService.SaveClient(client);
                    actionResult = View(ACCEPTED, clientViewModel);
                }
            }
            catch (ServiceException ex)
            {
                ViewData[ERROR] = ex.Message;
            }
            catch (Exception ex)
            {
                ViewData[ERROR] = ex.Message;
            }

            return actionResult;
        }

        [HttpPost]
        public async Task<IActionResult> Book(ClientViewModel clientViewModel)
        {
            IActionResult actionResult = View(ERROR);

            try
            {
                clientViewModel.Client = await m_appointmentAppService.FindByCitizenID(clientViewModel.Client.Id);
                clientViewModel.Client.Appointments.Add(new Appointment {Date = clientViewModel.Date});

                await m_appointmentAppService.SaveClient(clientViewModel.Client);

                actionResult = View(ACCEPTED, clientViewModel);
            }
            catch (ServiceException ex)
            {
                ViewData[MESSAGE] = ex.Message;
            }
            catch (Exception ex)
            {
                ViewData[MESSAGE] = ex.Message;
            }

            return actionResult;
        }

        public async Task<IActionResult> Edit(string CitizenID) => View(await m_appointmentAppService.FindByCitizenID(CitizenID));
        
        [HttpPost] public async Task<IActionResult> Edit(Client client)
        {
            IActionResult actionResult = View(ERROR);

            try
            {
                var theClient = await m_appointmentAppService.FindByCitizenID(client.Id);

                theClient.Email = client.Email;
                theClient.Phone = client.Phone;

                await m_appointmentAppService.SaveClient(theClient);

                var cvm = new ClientViewModel{Client = theClient, Date = DateTime.Now};

                actionResult = View(ACCEPTED, cvm);
            }
            catch (ServiceException ex)
            {
                ViewData[ERROR] = ex.Message;
            }
            catch (Exception ex)
            {
                ViewData[ERROR] = ex.Message;
            }

            return actionResult;

        }
        public async Task<IActionResult> ListClients() => View(await m_appointmentAppService.GetAllClients());

        public async Task<IActionResult> ListClientsAppointments(Client client)
        {
            ViewBag.Client = client.Id;
            return View(await m_appointmentAppService.FindAppointmentsByClient(client));
        }

        public async Task<IActionResult> ListAllAppointments(Client client) =>
            View(await m_appointmentAppService.GetAllAppointments());

        public async Task<IActionResult> DeleteClient(string CitizenID)
        {
            var citizen = await m_appointmentAppService.FindByCitizenID(CitizenID);
            return View("DeleteClient", citizen);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteClient(Client client)
        {
            await m_appointmentAppService.DeleteClient(client);
            return View("ListClients", await m_appointmentAppService.GetAllClients());
        }
    }
}