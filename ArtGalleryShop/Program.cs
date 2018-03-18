using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ArtGalleryShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(SetUpConfiguration)
                .UseStartup<Startup>()
                .Build();

        private static void SetUpConfiguration(WebHostBuilderContext context, IConfigurationBuilder appBuilder)
        {
            appBuilder.Sources.Clear();

            appBuilder.AddJsonFile("Config/config.json", optional: false, reloadOnChange: true);
                
        }
    }
}
