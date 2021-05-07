using CSD.DevicesApp.RestClientService.Services;

namespace CSD.DevicesApp.WebApp.Globals
{
    public class CheckDeviceService : ICheckDeviceService
    {
        private readonly IDevicesInfoService m_devicesInfoService; //inceyi gör: startupda singleton verince heryerde kullanılıyor.

        public CheckDeviceService(IDevicesInfoService devicesInfoService) => m_devicesInfoService = devicesInfoService;

        public void CheckServiceTimerProc(object o)
        {

        }
    }
}
