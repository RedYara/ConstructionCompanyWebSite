using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Persistence;

namespace Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();

            await InitializeDatabaseAsync(host);

            host.Run();
        }

        private static async Task InitializeDatabaseAsync(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var serviceProvider = scope.ServiceProvider;
            try
            {
                var context = serviceProvider.GetRequiredService<WebDbContext>();
                var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

                await DbInitializer.Initialize(context, userManager);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
