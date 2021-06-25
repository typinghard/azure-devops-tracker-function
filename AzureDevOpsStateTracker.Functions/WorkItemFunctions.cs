using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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

            return new OkObjectResult("Ok");
        }
    }
}
