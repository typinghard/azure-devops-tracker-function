using AzureDevOpsStateTracker.Functions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace AzureDevOpsStateTracker.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<ServiceToInject>();

            //builder.Services.AddHttpClient();

            //builder.Services.AddSingleton<IMyService>((s) => {
            //    return new MyService();
            //});

            //builder.Services.AddSingleton<ILoggerProvider, MyLoggerProvider>();
        }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {

        }
    }
}