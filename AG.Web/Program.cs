using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace AG.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
               .UseKestrel()
               .UseContentRoot(Directory.GetCurrentDirectory())
               .UseSetting("detailedErrors", "true")
               .UseIISIntegration()
               .UseStartup<Startup>()
               .UseApplicationInsights()
               .CaptureStartupErrors(true)
               .UseUrls("http://localhost:5000/")
               .Build();

            host.Run();
        }
    }
}
