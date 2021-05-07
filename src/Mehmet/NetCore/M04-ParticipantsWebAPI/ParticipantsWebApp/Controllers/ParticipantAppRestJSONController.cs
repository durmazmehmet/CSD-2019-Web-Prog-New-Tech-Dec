using CSD.Extensions.ColorfulConsoleLog;
using CSD.ParticipantsApp.Repository.Entities;
using CSD.ParticipantsApp.Service;
using CSD.Util.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CSD.ParticipantsApp.Controllers
{
    //[Route("api/[controller]")] // 03. API yönlendirici base URL. 
    [Route("api/participantsJSON")]
    [ApiController] // 01. Asıl olay bu attributeyi alması

    //03. için http:/192.168.1.5:50500/api/ParticipantAppRest

    // 02. Default json üretecek bir API'dir
    // 02. diğer formatlarda üretim için özlelikle eklemeler yapmamız gerekiyor
    public class ParticipantAppRestJSONController : ControllerBase
    {

        //04. Dependency Injection
        private readonly IParticipantService m_participantService;
        private readonly LogToConsole logToConsole = new LogToConsole();

        public ParticipantAppRestJSONController(IParticipantService participantService)
        {
            m_participantService = participantService;
            logToConsole.Stamp().Action(MemberName: "Rest Controller JSON");
        }

        //05. ilk yayınımız:

        [HttpGet("all")] //06. URL bilgimizi giriyoruz http:/192.168.1.5:50500/api/ParticipantAppRest/all
        public async Task<IActionResult> GetAllParticipants() 
            => new ObjectResult(await m_participantService.GetAllParticipant());

        //yayın
        //07. ör: http:/192.168.1.5:50500/api/participants/pinfo/mehmet@mehmetdurmaz.com
        [HttpGet("pinfo/{emailver}")]
        public async Task<IActionResult> GetParticipantByEmailData(string emailver) 
            => new ObjectResult(await m_participantService.FindParticipantByEmail(emailver));

        //08. ör: http:/192.168.1.5:50500/api/participants/info?emailby=mehmet@mehmetdurmaz.com
        [HttpGet("info")]
        public async Task<IActionResult> GetParticipantByEmail(string emailby)
            => new ObjectResult(await m_participantService.FindParticipantByEmail(emailby));

        //09. http:/192.168.1.5:50500/api/ParticipantAppRest/detail?"emailby=mehmet@mehmetdurmaz.com&isParticipate=False"
        //tırnaklara tikkat. Linuxde tek tırnakdır.
        [HttpGet("detail")]
        public async Task<IActionResult> GetParticipantByEmailAndParticipate(string emailby, bool isParticipate)
            => new ObjectResult(await m_participantService.FindParticipantByEmailAndParticipate(emailby, isParticipate));

        //10. http:/192.168.1.5:50500/api/participants/detail?"emailby=mehmet@mehmetdurmaz.com&participate=False"
        [HttpGet("bdetail")]
        public async Task<IActionResult> GetParticipantByEmailAndParticipateAutoBadRequest(string emailby, string participate)
        {
            if (!bool.TryParse(participate, out bool isParticipate))
                return new ObjectResult(new object());

            var p = await m_participantService.FindParticipantByEmailAndParticipate(emailby, isParticipate);

            return new ObjectResult(p ?? new object());
        }

        //11 Parametre alma - dinleyerek
        /*curl.exe -H "Content-Type: application/json" -X POST http:/192.168.1.5:50500/api/participants/add
         -d "{\"id\":\"deneme44444@deneme.com\",\"name\":\"Deneme\",\"date\":\"2020-05-13\",\"isParticipate\":true}"*/

        [HttpPost("add")]
        public async Task<IActionResult> AddParticipant([FromBody] Participant participant)
        {
            if (participant == null)
                return BadRequest();

            try
            {
                var p = await m_participantService.SaveParticipant(participant);
                //aşağıdaki satır cshtml'deki htmlaction gibi çalışacak ve yine bu controllerdeki metoda yönlenecek
                //FEKAT BU ÇALIŞMADI
                //return CreatedAtRoute(nameof(GetParticipantByEmail), new { emailby = p.Id});
                return new ObjectResult(p);
            }
            catch (ServiceException ex)
            {
                return BadRequest();
            }
        }
    }
}
