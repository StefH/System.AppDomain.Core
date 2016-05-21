using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.AppDomain.NetCoreApp;
using System.Diagnostics;

namespace NetCoreWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            Type thisType = typeof(Program);

            var assemblies = AppDomain.CurrentDomain.GetAssemblies(thisType);
            foreach (var assembly in assemblies)
            {
                Debug.WriteLine(assembly.FullName);
            }

            host.Run();
        }
    }
}