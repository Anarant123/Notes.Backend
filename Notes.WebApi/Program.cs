using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Notes.Persistence;

namespace Notes.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var app = CreateHostBuilder(args).Build();
            
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<NotesDbContext>();
                    DbInitialize.Initialize(context);
                }
                catch (Exception ex)
                {

                }
            }
            

            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}