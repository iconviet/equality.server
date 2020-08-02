using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Icon_Cps.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);
            builder
                .ConfigureWebHostDefaults(x => x.UseStartup<Startup>())
                .UseServiceProviderFactory(new AutofacServiceProviderFactory(Client.Program.ConfigureBuilder));
            builder.Build().Run();
        }
    }
}