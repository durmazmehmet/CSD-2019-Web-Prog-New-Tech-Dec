using CSD.DevicesAppRestService.Models;
using CSD.Extensions.ColorfulConsoleLog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Threading.Tasks;

namespace CSD.DevicesAppRestService.Controllers
{
    [Route("api/connection")]
    [ApiController]
    public class ConnectionInfoController : ControllerBase
    {
        private readonly IActionContextAccessor m_actionContextAccessor;
        private readonly LogToConsole logToConsole = new LogToConsole();

        public ConnectionInfoController(IActionContextAccessor actionContextAccessor) => m_actionContextAccessor = actionContextAccessor;

        private ConnectionInformation GetConnectionInformation()
        {
            var host = m_actionContextAccessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString();
            var localHost = m_actionContextAccessor.ActionContext.HttpContext.Connection.LocalIpAddress.ToString();
            var port = m_actionContextAccessor.ActionContext.HttpContext.Connection.RemotePort.ToString();
            var localPort = m_actionContextAccessor.ActionContext.HttpContext.Connection.LocalPort.ToString();

            return new ConnectionInformation { Host = host, LocalHost = localHost, Port = port, LocalPort = localPort };
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetConnectionInfo()
        {
            try
            {
                var task = new Task<ConnectionInformation>(() => GetConnectionInformation());

                task.Start();
                logToConsole.Stamp().Action().WriteLine();
                return new ObjectResult(await task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}