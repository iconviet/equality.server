using System;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using IconIcps.Client.Models;
using IconIcps.Client.Remote;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using Syncfusion.Licensing;

namespace IconIcps.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddSyncfusionBlazor();
            builder.ConfigureContainer(new AutofacServiceProviderFactory(), ConfigureBuilder);
            BackgroundJob.Start();
            await builder.Build().RunAsync();
        }

        public static Action<ContainerBuilder> ConfigureBuilder = builder =>
        {
            builder.RegisterType<IconexWallet>().PropertiesAutowired();
            builder.RegisterType<JsonServiceClient>().PropertiesAutowired();
            builder.RegisterType<IconServiceClient>().PropertiesAutowired();
            SyncfusionLicenseProvider.RegisterLicense("MzM0NzMwQDMxMzgyZTMzMmUzMEI1RHdoYk1rZkNqRnVrTEJHQ0tSdnNKL0tGS0Z5OWlQdG4zS3pDWHVtSVE9");
            builder.RegisterTypes(typeof(Program).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(ViewModelBase))).ToArray()).PropertiesAutowired();
            builder.RegisterTypes(typeof(Program).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(PageModelBase))).ToArray()).PropertiesAutowired();
        };
    }
}