using CSD.DevicesApp.RestClientService.Services;
using CSD.DevicesApp.WebApp.Models;
using CSD.Extensions.ColorfulConsoleLog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Threading.Tasks;

namespace CSD.DevicesApp.WebApp.Controllers
{


    [Route("api/devices")]
    [ApiController]
    public class DevicesAppRestController : ControllerBase
    {
        private readonly IDevicesInfoService m_devicesInfoService;
        private readonly IActionContextAccessor m_actionContextAccessor;
        private readonly LogToConsole logToConsole = new LogToConsole();

        public DevicesAppRestController(IDevicesInfoService devicesInfoService, IActionContextAccessor actionContextAccessor) 
        {
            m_devicesInfoService = devicesInfoService;
            m_actionContextAccessor = actionContextAccessor;
        }

        [HttpGet("hello")]
        public async Task<IActionResult> Hello()
        {
            return new ObjectResult("Hi");
        }

        [HttpGet("alldevices")]
        public async Task<IActionResult> GetAllDevices()
        {
            try
            {               
                var devices = await m_devicesInfoService.GetAllSync();
                var connectionInfo = m_actionContextAccessor.ActionContext.HttpContext.Connection;
                var host = connectionInfo.RemoteIpAddress.ToString();
                logToConsole
                    .Stamp().Action().WriteLine()
                    .RemoteInfo(connectionInfo).HostInfo(connectionInfo).WriteLine();
                return new ObjectResult(devices);
            }
            catch (Exception ex)
            { 
                return BadRequest(ex);
            }
        }

        [HttpGet("names")]
        public async Task<IActionResult> GetDevicesByName(string name)
        {
            try
            {
                var d = await m_devicesInfoService.GetByName(name);
                var connectionInfo = m_actionContextAccessor.ActionContext.HttpContext.Connection;
                var host = connectionInfo.RemoteIpAddress.ToString();
                logToConsole
                    .Stamp().Action(ActionDescription: $"name = {name}").WriteLine()
                    .RemoteInfo(connectionInfo).HostInfo(connectionInfo).WriteLine();
                return new ObjectResult(new DevicesInfoModel { DevicesInfo = d, MyHost = host });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("info")] 
        public async Task<IActionResult> GetDevicesByNameAndMonth(string day, string mon)
        {
            try
            {
                var d = await m_devicesInfoService.GetByDayAndMonthStr(day, mon);
                var connectionInfo = m_actionContextAccessor.ActionContext.HttpContext.Connection;
                var host = connectionInfo.RemoteIpAddress.ToString();
                logToConsole
                    .Stamp().Action(ActionDescription: $"day = {day} & mon = {mon}").WriteLine()
                    .RemoteInfo(connectionInfo).HostInfo(connectionInfo).WriteLine();
                return new ObjectResult(d);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
