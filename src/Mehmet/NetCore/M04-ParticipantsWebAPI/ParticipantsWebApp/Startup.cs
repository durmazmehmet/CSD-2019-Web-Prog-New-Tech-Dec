using CSD.DbUtil.Provider;
using CSD.ParticipantsApp.Repository;
using CSD.Extensions.ColorfulConsoleLog;
using CSD.ParticipantsApp.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CSD.ParticipantsApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services
                .AddSingleton<IParticipantRepository, ParticipantRepository>()
                .AddSingleton<IParticipantService, ParticipantService>()
                .AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services
                .AddMvc()
                .AddXmlSerializerFormatters().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
                .AddMvcOptions(options =>
                    options.ModelMetadataDetailsProviders.Add(new DisableConvertEmptyStringToNullProvider()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/Home/Error");

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}