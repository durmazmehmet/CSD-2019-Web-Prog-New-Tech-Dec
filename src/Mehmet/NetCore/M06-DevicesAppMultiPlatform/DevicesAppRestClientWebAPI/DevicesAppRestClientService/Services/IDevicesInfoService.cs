using CSD.DevicesApp.RestClientService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSD.DevicesApp.RestClientService.Services
{
    public interface IDevicesInfoService
    {
        Task<DevicesInfo> GetAllSync();
        Task<DevicesInfo> GetByDayAndMonth(string day, string mon);
        Task<List<DeviceInfo>> GetByDayAndMonthStr(string day, string mon);
        Task<DevicesInfo> GetByName(string name);
        Task<DeviceInfo> SaveDevice(DeviceInfo deviceInfo);
    }
}