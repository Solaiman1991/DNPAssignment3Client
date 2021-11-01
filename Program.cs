using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Assingment1 {
public class Program {
    static async Task Main(string[] args) {
        CreateHostBuilder(args).Build().Run();
        // Task data = new AdultService().GetAdults();
        // await data;
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}
}