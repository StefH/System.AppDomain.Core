using System;
using System.AppDomain.NetCoreApp;

namespace NetCoreApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("--start--");

            Type thisType = typeof(Program);

            var assemblies = AppDomain.CurrentDomain.GetAssemblies(thisType);
            foreach (var assembly in assemblies)
            {
                Console.WriteLine(assembly.FullName);
            }

            Console.WriteLine("--end--");
        }
    }
}