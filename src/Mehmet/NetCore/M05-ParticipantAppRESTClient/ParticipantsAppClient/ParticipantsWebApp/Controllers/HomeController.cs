using CSD.ParticipansAppRestClientService.Models;
using CSD.ParticipantsAppRestClient.Services;
using Microsoft.AspNetCore.Http;
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

        public async Task<IActionResult> Delete(string id) => View(await m_participantService.FindByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Delete(ParticipantModel participant)
        {
            if (await m_participantService.FindByIdAsync(participant.Id) == null)
                return View("Error", (object)"Kayıt daha önce silinmiş yada yok...");

            await m_participantService.DeleteParticipant(participant);

            ViewData["Process"] = $"Participant {participant.Id} deleted";

            return View("List", await m_participantService.FindAllAsync());
        }

        public async Task<IActionResult> Details(ParticipantModel participant) => View(participant);       

        public async Task<IActionResult> Edit(string id) => View(await m_participantService.FindByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Edit(ParticipantModel participant)
        {                       
            try
            {
                var p = await m_participantService.FindByIdAsync(participant.Id);

                if (p.Id == null)
                    return View("Error", (object)"Kayıt silinmiş yada yok...");

                if (!ModelState.IsValid)
                {
                    foreach (var key in ModelState.Keys)
                        ModelState[key].Errors.ToList().ForEach(error => ModelState.AddModelError("", error.ErrorMessage));
                    return View();
                }

                var editedRecord = await m_participantService.UpdateParticipant(participant);

                return View("Details", editedRecord);
            }
            catch (Exception ex)
            {
                ViewData["Message"] = $"Exception: {ex.Message}";
            }
            return View("Error");
        }

        public IActionResult Insert() => View();

        [HttpPost]
        public async Task<IActionResult> Insert(ParticipantModel participant)
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

                var savedRecord = await m_participantService.SaveParticipant(participant);

                return View("Details", savedRecord);
            }
            catch (Exception ex)
            {
                ViewData["Message"] = $"Exception: {ex.Message}";
            }
            return View("Error");
        }

        public IActionResult Index() => View();        

        public async Task<IActionResult> List()
        {
            var participants = await m_participantService.FindAllAsync();

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