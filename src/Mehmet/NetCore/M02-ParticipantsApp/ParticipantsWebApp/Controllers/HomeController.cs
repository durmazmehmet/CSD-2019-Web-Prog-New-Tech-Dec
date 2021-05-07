using CSD.ParticipantsApp.Repository.Entities;
using CSD.ParticipantsApp.Service;
using CSD.Util.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.DbUtil.Controllers
{
    public class HomeController : Controller
    {
        private readonly IParticipantService m_participantService;

        public HomeController(IParticipantService participantService) => m_participantService = participantService;

        public async Task<IActionResult> Delete(Participant participant)
        {

            var p = await m_participantService.FindParticipantByEmail(participant.Id);

            if (p == null)
                return View("Error", (object)"Kayıt daha önce silinmiş yada yok...");

            await m_participantService.DeleteParticipant(participant);

            ViewData["Process"] = $"Participant {participant.Id} deleted";

            var participants = await m_participantService.GetAllParticipant();

            return View("List", participants);
        }

        public IActionResult Details(Participant participant)
        {
            if (participant.Id == null)
                return View("Error", (object)"Kayıt silinmiş yada yok...");

            return View(participant);
        }

        public async Task<IActionResult> Edit(string Id)
        {
            var p = await m_participantService.FindParticipantByEmail(Id);

            if (p == null)
                return View("Error", (object)"Kayıt silinmiş yada yok...");

            return View(p);           
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Participant participant)
        {            
            var p = await m_participantService.FindParticipantByEmail(participant.Id);

            if (p == null)
                return View("Error", (object)"Kayıt silinmiş yada yok...");

            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var key in ModelState.Keys)
                        ModelState[key].Errors.ToList().ForEach(error => ModelState.AddModelError("", error.ErrorMessage));
                    return View();
                }

                p.Name = participant.Name;
                p.IsParticipate = participant.IsParticipate;

                await m_participantService.SaveParticipant(p);

                return View("Details", p);
            }
            catch (ServiceException ex)
            {
                ViewData["Message"] = $"Service Exception: {ex.Message}";
            }
            catch (Exception ex)
            {
                ViewData["Message"] = $"Exception: {ex.Message}";
            }
            return View("Error");
        }

        public IActionResult Insert() => View();

        [HttpPost]
        public async Task<IActionResult> Insert(Participant participant)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var key in ModelState.Keys)
                        ModelState[key].Errors.ToList().ForEach(error => ModelState.AddModelError("", error.ErrorMessage));
                    return View();
                }

                participant.Date = DateTime.Now;

                await m_participantService.SaveParticipant(participant);

                return View("Details", participant);
            }
            catch (ServiceException ex)
            {
                ViewData["Message"] = $"Service Exception: {ex.Message}";
            }
            catch (Exception ex)
            {
                ViewData["Message"] = $"Exception: {ex.Message}";
            }
            return View("Error");
        }

        public IActionResult Index()
        {
            ViewBag.Today = DateTime.Today;
            return View();
        }

        public async Task<IActionResult> List()
        {
            var participants = await m_participantService.GetAllParticipant();

            ViewBag.Title = "List of All Recordss";

            return View(participants);
        }

        public async Task<IActionResult> ListParticipants()
        {
            var participants = await m_participantService.FindParticipateds();

            ViewBag.Title = "List of Participants";
            return View("List", participants);
        }

        public async Task<IActionResult> ListNonParticipants()
        {
            var participants = await m_participantService.FindNotParticipateds();

            ViewBag.Title = "List of Non Participants"; 

            return View("List", participants);
        }


    }
}