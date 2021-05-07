using CSD.Extensions.ColorfulConsoleLog;
using CSD.ParticipantsApp.Repository.Entities;
using CSD.ParticipantsApp.Service;
using CSD.Util.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CSD.ParticipantsApp.Controllers
{
    [FormatFilter]
    [Produces("application/xml", "application/son")]
    [Route("api/participants")]
    [ApiController] 

    public class ParticipantAppRestController : ControllerBase
    {
        private readonly IParticipantService m_participantService;
        private readonly LogToConsole logToConsole = new LogToConsole();

        public ParticipantAppRestController(IParticipantService participantService) => m_participantService = participantService;

        private async Task<IActionResult> getAllParticipants()
        {
            logToConsole.Stamp().Action().WriteLine();
            return new ObjectResult(await m_participantService.GetAllParticipant());
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllParticipants() => await getAllParticipants();

        //kullanım: ...all.XML yada all.JSON

        [HttpGet("all.{format}")]
        public async Task<IActionResult> GetAllParticipantsByFormat() => await getAllParticipants();

        [HttpGet("pinfo/{emailver}")]
        public async Task<IActionResult> GetParticipantByEmailData(string emailver)
        {
            logToConsole.Stamp().Action().WriteLine();
            return new ObjectResult(await m_participantService.FindParticipantByEmail(emailver));

        }

        [HttpGet("info")]
        public async Task<IActionResult> GetParticipantByEmail(string emailby)
        {
            logToConsole.Stamp().Action().WriteLine();
            return new ObjectResult(await m_participantService.FindParticipantByEmail(emailby));
        }
            

        [HttpGet("detail")]
        public async Task<IActionResult> GetParticipantByEmailAndParticipate(string emailby, bool isParticipate)
        {
            logToConsole.Stamp().Action().WriteLine();
            return new ObjectResult(await m_participantService.FindParticipantByEmailAndParticipate(emailby, isParticipate));
        }
            

        [HttpGet("bdetail")]
        public async Task<IActionResult> GetParticipantByEmailAndParticipateAutoBadRequest(string emailby, string participate)
        {
            if (!bool.TryParse(participate, out bool isParticipate))
                return new ObjectResult(new object());

            var p = await m_participantService.FindParticipantByEmailAndParticipate(emailby, isParticipate);
            logToConsole.Stamp().Action().WriteLine();
            return new ObjectResult(p ?? new object());
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddParticipant([FromBody] Participant participant)
        {
            if (participant == null)
                return BadRequest();

            try
            {
                var p = await m_participantService.SaveParticipant(participant);
                logToConsole.Stamp().Action().WriteLine();
                return new ObjectResult(p);
            }
            catch (ServiceException ex)
            {
                return BadRequest();
            }
        }
    }
}
