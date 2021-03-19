using Autofac.Extensions.DependencyInjection;
using Equality.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Equality.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .Enrich.FromLogContext()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .CreateLogger();
            var builder = Host.CreateDefaultBuilder(args);
            builder
                .UseSerilog()
                .ConfigureWebHostDefaults(x => x.UseStartup<Startup>())
                .UseServiceProviderFactory(new AutofacServiceProviderFactory(Client.Program.ConfigureBuilder));
            BackgroundJob.Start();
            builder.Build().Run();
        }
    }
}