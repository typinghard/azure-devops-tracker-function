using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AzureDevOpsStateTracker.Functions
{
    public class WorkItemFunctions
    {
        private readonly ServiceToInject _serviceToInject;

        public WorkItemFunctions(ServiceToInject serviceToInject)
        {
            _serviceToInject = serviceToInject;
        }

        [FunctionName("workitem")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            _serviceToInject.DoSomething();

            return new OkObjectResult("Ok - Run");
        }

        [FunctionName("ping")]
        public IActionResult Ping(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
        ILogger log)
        {
            return new OkObjectResult("Ok - Ping");
        }
    }
}