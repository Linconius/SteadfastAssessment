using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SteadFastAssessment.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            if (builder.HostEnvironment.BaseAddress.Contains("linconius.github.io"))
            {
                builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://steadfastassessmentserver.azurewebsites.net/") });
            }
            else
            {
                builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });       
            }

            await builder.Build().RunAsync();
        }
    }
}
