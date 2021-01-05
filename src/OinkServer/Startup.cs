using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OinkServer.Players;

namespace OinkServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<OinkMiddleware>();
            services.AddSingleton<SoundProvider>();

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                services.AddTransient<IPlayer, WindowsPlayer>();
            }
            else if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                services.AddTransient<IPlayer, AlsaPlayer>();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                var subPipe = endpoints.CreateApplicationBuilder().UseMiddleware<OinkMiddleware>().Build();
                endpoints.MapPost("/oink", subPipe);
            });
        }
    }
}