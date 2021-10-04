using AzureDevOpsStateTracker.Functions.Extensions;
using AzureDevopsTracker.DTOs.Create;
using AzureDevopsTracker.DTOs.Update;
using AzureDevopsTracker.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AzureDevOpsTracker.Functions
{
    public class WorkItemFunctions
    {
        private readonly AzureDevopsTrackerService _azureDevopsTrackerService;

        public WorkItemFunctions(
            AzureDevopsTrackerService azureDevopsTrackerService)
        {
            _azureDevopsTrackerService = azureDevopsTrackerService;
        }

        [FunctionName("workitem")]
        public async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            try
            {
                var workItemDTO = JsonConvert.DeserializeObject<CreateWorkItemDTO>(req.GetBody());
                await _azureDevopsTrackerService.Create(workItemDTO);
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message);
            }

            return new OkObjectResult(HttpStatusCode.OK);
        }

        [FunctionName("workitem-update")]
        public async Task<IActionResult> Update(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                var workItemDTO = JsonConvert.DeserializeObject<UpdatedWorkItemDTO>(req.GetBody());
                await _azureDevopsTrackerService.Update(workItemDTO);
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message);
            }

            return new OkObjectResult(HttpStatusCode.OK);
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