using Autofac.Extensions.DependencyInjection;
using Equality.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Equality.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);
            builder
                .ConfigureWebHostDefaults(x => x.UseStartup<Startup>())
                .UseServiceProviderFactory(new AutofacServiceProviderFactory(Client.Program.ConfigureBuilder));
            BackgroundJob.Start();
            builder.Build().Run();
        }
    }
}