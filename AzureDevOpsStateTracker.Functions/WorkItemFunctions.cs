using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AzureDevopsStateTracker.Services;
using AzureDevOpsStateTracker.Functions.Extensions;
using Newtonsoft.Json;
using AzureDevopsStateTracker.DTOs.Create;
using AzureDevopsStateTracker.DTOs.Update;
using System.Net;
using System;

namespace AzureDevOpsStateTracker.Functions
{
    public class WorkItemFunctions
    {
        private readonly AzureDevopsStateTrackerService _azureDevopsStateTrackerService;

        public WorkItemFunctions(
            AzureDevopsStateTrackerService azureDevopsStateTrackerService)
        {
            _azureDevopsStateTrackerService = azureDevopsStateTrackerService;
        }

        [FunctionName("workitem")]
        public IActionResult Create(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            try
            {
                var workItemDTO = JsonConvert.DeserializeObject<CreateWorkItemDTO>(req.GetBody());
                _azureDevopsStateTrackerService.Create(workItemDTO);
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message);
            }

            return new OkObjectResult(HttpStatusCode.OK);
        }

        [FunctionName("workitem-update")]
        public IActionResult Update(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                var workItemDTO = JsonConvert.DeserializeObject<UpdatedWorkItemDTO>(req.GetBody());
                _azureDevopsStateTrackerService.Update(workItemDTO);
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