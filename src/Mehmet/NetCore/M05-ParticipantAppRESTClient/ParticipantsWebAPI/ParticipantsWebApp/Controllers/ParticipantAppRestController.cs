using CSD.ParticipantsApp.Repository.Entities;
using CSD.ParticipantsApp.Service;
using CSD.Util.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSD.ParticipantsApp.Controllers
{
    //[Route("api/[controller]")] // 03. API yönlendirici base URL. 
    [Route("api/participants")]
    [ApiController] // 01. Asıl olay bu attributeyi alması

    //03. için http:/192.168.1.5:50500/api/ParticipantAppRest

    // 02. Default json üretecek bir API'dir
    // 02. diğer formatlarda üretim için özlelikle eklemeler yapmamız gerekiyor
    public class ParticipantAppRestController : ControllerBase
    {

        private readonly IParticipantService m_participantService;

        public ParticipantAppRestController(IParticipantService participantService) => m_participantService = participantService;                    
       
        private void LogToConsole(string Msg) 
            => Console.WriteLine($"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}, {Msg}");
        
        
        // http:/192.168.1.5:50500/api/participants/all
        [HttpGet("all")]
        public async Task<IActionResult> GetAllParticipants()
        {            
            LogToConsole($"All Participants sent");
            return new ObjectResult(await m_participantService.GetAllParticipant() ?? new object());
        }

        [HttpGet("hello")]
        public async Task<IActionResult> Hello()
        {           
            return new ObjectResult("hi");
        }
        // http:/192.168.1.5:50500/api/participants/info?email=mehmet@mehmetdurmaz.com
        [HttpGet("info")]
        public async Task<IActionResult> GetParticipantByEmail(string email)
        {
            var p = await m_participantService.FindParticipantByEmail(email);
            LogToConsole($"Requested Participant: {p.Name}:{p.Id}");
            return new ObjectResult(p ?? new object());
        }

        //http:/192.168.1.5:50500/api/participants/deleteParticipant?"email=mehmet2@mehmetdurmaz.com"  
        [HttpGet("deleteParticipant")]
        public async Task<IActionResult> DeleteParticipant(string email)
        {
            var p = await m_participantService.FindParticipantByEmail(email);

            await m_participantService.DeleteParticipant(p);

            LogToConsole($"Deleted Participant: {p.Name}:{p.Id}");

            return new ObjectResult(p ?? new object());
        }      

        [HttpGet("isParticipated")]
        public async Task<IActionResult> GetParticipantsByParticipate(string participate = "true")
        {
            if(!bool.TryParse(participate, out bool isParticipate)) //komuttan gelen yaz booleane çevirme denemesi
                return new ObjectResult(new List<Participant>());

            var participants = isParticipate
                ? await m_participantService.FindParticipateds()
                : await m_participantService.FindNotParticipateds();

            LogToConsole($"Participants that Participanted = {isParticipate} are sent");
            return new ObjectResult(participants ?? new List<Participant>());
        }

        /*curl.exe -H "Content-Type: application/json" -X POST http:/192.168.1.5:50500/api/participants/add -d "{\"id\":\"deneme44444@deneme.com\",\"name\":\"Deneme\",\"date\":\"2020-05-13\",\"isParticipate\":true}"*/
        [HttpPost("add")]
        public async Task<IActionResult> AddParticipant([FromBody] Participant participant)
        {
            if (participant == null)
                return BadRequest();
            try
            {
                var p = await m_participantService.SaveParticipant(participant);

                LogToConsole($"Saved Participant: {p.Name}:{p.Id}");

                return new ObjectResult(p);
            }
            catch (ServiceException)
            {
                return new ObjectResult(new Participant());
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateParticipant([FromBody] Participant participant)
        {
            if (participant == null)
                return BadRequest();
            try
            {                
                var ParticipantToUpdate = await m_participantService.FindParticipantByEmail(participant.Id);

                LogToConsole($"Participant is being updating from {ParticipantToUpdate.Name}:{ParticipantToUpdate.Id} to {participant.Name}:{ participant.Id}");

                ParticipantToUpdate.Name = participant.Name;
                ParticipantToUpdate.Date = participant.Date;
                ParticipantToUpdate.IsParticipate = participant.IsParticipate;

                LogToConsole($"Participant updating as {ParticipantToUpdate.Name}:{ParticipantToUpdate.Id}");

                var p = await m_participantService.SaveParticipant(ParticipantToUpdate);

                LogToConsole($"Updated Participant: {p.Name}:{p.Id}");

                return new ObjectResult(p);
            }
            catch (ServiceException)
            {
                return new ObjectResult(new Participant());
            }
        }       
    }
}
