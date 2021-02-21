using System;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Equality.Client.Models;
using Equality.Client.Remote;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Syncfusion.Blazor;
using Syncfusion.Licensing;

namespace Equality.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddMudServices();
            builder.Services.AddSyncfusionBlazor();
            builder.RootComponents.Add<App>("app");
            builder.ConfigureContainer(new AutofacServiceProviderFactory(), ConfigureBuilder);
            builder.Services.AddScoped(x => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            BackgroundJob.Start();
            await builder.Build().RunAsync();
        }

        public static Action<ContainerBuilder> ConfigureBuilder = builder =>
        {
            builder.RegisterType<IconexWallet>().PropertiesAutowired();
            builder.RegisterType<JsonServiceClient>().PropertiesAutowired();
            builder.RegisterType<IconServiceClient>().PropertiesAutowired();
            SyncfusionLicenseProvider.RegisterLicense("MzcyNTI2QDMxMzgyZTM0MmUzMFd3RUhHdzZXS1pYZjhmS2ZVTzkyMEVzbHNnU0hnMURWNEI3cm1EdkhFekE9");
            builder.RegisterTypes(typeof(Program).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(ViewModelBase))).ToArray()).PropertiesAutowired();
            builder.RegisterTypes(typeof(Program).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(PageModelBase))).ToArray()).PropertiesAutowired();
        };
    }
}