using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.AppDomain.NetCoreApp;

namespace NetCoreWebApplication
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                Type thisType = typeof(Program);

                var assemblies = AppDomain.CurrentDomain.GetAssemblies(thisType);
                await context.Response.WriteAsync(string.Join("<br>", assemblies.Select(a => a.FullName)));
            });
        }
    }
}