using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NumberFun.Services.NumberFilterService;
using NumberFun.Services.StringRotatorService;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NumberFun
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<NumberFilterService>();
            builder.Services.AddScoped<StringRotatorService>();

            await builder.Build().RunAsync();
        }
    }
}
