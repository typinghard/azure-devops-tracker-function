using AzureDevOpsStateTracker.Functions;
using AzureDevopsTracker.Configurations;
using AzureDevopsTracker.Data;
using AzureDevopsTracker.Services;
using AzureDevOpsTracker.Functions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace AzureDevOpsTracker.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = builder.GetContext().Configuration;

            builder.Services.AddScoped<ServiceToInject>();
            builder.Services.AddScoped<AzureDevopsTrackerService>();

            builder.Services.AddAzureDevopsTracker(new DataBaseConfig(configuration["ConnectionStrings:DefaultConnection"]));
        }
    }
}
