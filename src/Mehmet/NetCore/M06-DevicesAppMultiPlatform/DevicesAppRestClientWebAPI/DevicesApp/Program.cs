using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CSD.DevicesApp.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //This line allows Windows Terminal to show colors
            ConsoleEnableVT100.Enable();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.CaptureStartupErrors(true);
                    webBuilder.PreferHostingUrls(true);
                    webBuilder.UseUrls("http://192.168.1.3:60500");
                });
    }
}
