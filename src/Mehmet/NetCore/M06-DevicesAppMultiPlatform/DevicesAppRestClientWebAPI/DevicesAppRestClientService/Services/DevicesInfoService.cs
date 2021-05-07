using CSD.DevicesApp.RestClientService.Models;
using CSD.Extensions.Net.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Tuple;

namespace CSD.DevicesApp.RestClientService.Services
{
    public class DevicesInfoService : IDevicesInfoService
    {
        private const string ms_baseURL = "http://192.168.1.11:65000/devices/";
        private readonly HttpClient m_httpClient;

        public DevicesInfoService(HttpClient httpClient) => m_httpClient = httpClient;

        public async Task<DevicesInfo> GetAllSync()
            => await m_httpClient.GetJsonSuccessAsync<DevicesInfo>($"{ms_baseURL}all", "Can not get all devices");

        public async Task<DevicesInfo> GetByName(string name)
         => await m_httpClient.GetJsonSuccessAsync<DevicesInfo>($"{ms_baseURL}names", "Can not get devices name", Create("name", name));

        public async Task<DevicesInfo> GetByDayAndMonth(string day, string mon)
            => await m_httpClient.GetJsonSuccessAsync<DevicesInfo>($"{ms_baseURL}sinfo", "Can not get devices By Day And Month", Create("day", day), Create("mon", mon));

        public async Task<List<DeviceInfo>> GetByDayAndMonthStr(string day, string mon)
           => await m_httpClient.GetJsonSuccessAsync<List<DeviceInfo>>($"{ms_baseURL}sinfo", "Can not get devices By Day And Month", Create("day", day), Create("mon", mon));

        public async Task<DeviceInfo> SaveDevice(DeviceInfo deviceInfo)
            => await m_httpClient.PostJsonWithResultSuccessAsync<DeviceInfo>($"{ms_baseURL}", deviceInfo, "can not save");

    }
}
