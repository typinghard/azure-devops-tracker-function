using AzureDevopsStateTracker.Configurations;
using AzureDevopsStateTracker.Data;
using AzureDevopsStateTracker.Services;
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
            var configuration = builder.GetContext().Configuration;

            builder.Services.AddScoped<ServiceToInject>();
            builder.Services.AddScoped<AzureDevopsStateTrackerService>();

            builder.Services.AddAzureDevopsStateTracker(new DataBaseConfig(configuration["ConnectionStrings:DefaultConnection1"], "StateTracker"));
        }
    }
}