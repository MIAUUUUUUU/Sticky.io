using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace MiauCore.IO
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
                //.UseUrls("*.*.*.*:9999")
                .Build();

            host.Run();
        }
    }
}
