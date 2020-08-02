using System;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Icon_Cps.Client.Models;
using Icon_Cps.Client.Remote;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Icon_Cps.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.ConfigureContainer(new AutofacServiceProviderFactory(), ConfigureBuilder);
            await builder.Build().RunAsync();
        }

        public static Action<ContainerBuilder> ConfigureBuilder = builder =>
        {
            builder.RegisterType<JsonServiceClient>().PropertiesAutowired();
            builder.RegisterType<IconServiceClient>().PropertiesAutowired();
            builder.RegisterTypes(typeof(Program).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(ModelBase))).ToArray()).PropertiesAutowired();
        };
    }
}