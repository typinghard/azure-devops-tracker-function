# Azure DevOps Tracker Function

Nesse repositório temos uma Azure Function que utiliza o [![Nuget](https://img.shields.io/badge/Azure%20DevOps%20Tracker-nuget-blue)](https://www.nuget.org/packages/AzureDevOpsTracker/) que também pode ser encontrado no [![Azure DevOps Tracker](https://img.shields.io/badge/Azure%20DevOps%20Tracker-github-0099cc)](https://github.com/typinghard/azure-devops-tracker) para mostrar um exemplo prático de utilização do mesmo.

O objetivo é demonstrar a utilização do ADT através de uma Azure Function e, além disso, mostrar os passos necessários para a criação dessa Azure Function no Portal Azure.
Para mais informações mais detalhadas e específicas sobre o Azure DevOps Tracker, consulte a nossa [Wiki](https://github.com/typinghard/azure-devops-tracker/wiki).

## Etapa 1

### Configuração da Azure Function 

Diferente de uma startup de um projeto MVC ou API, requer que a startup herde de uma FunctionsStartup. 

```c#
 public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<ServiceToInject>();
            builder.Services.AddScoped<AzureDevopsTrackerService>(); 
            builder.Services.AddAzureDevopsTracker(new DataBaseConfig("[YOUR_CONNECTION_STRING]"));
        }
    }
```

Novamente, diferente de um projeto MVC ou API, dentro da controller ao invés de injetar a interface será injetado a classe concreta.

```c#
    public class WorkItemFunctionsController
    {
        private readonly AzureDevopsTrackerService _azureDevopsTrackerService;

        public WorkItemFunctionsController(
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
    }
```

Como resultado final, os endpoints ficarão da seguinte forma

![Endpoints Azure Functions](https://drive.google.com/uc?export=view&id=1aKPWYHzqPVsnxcMdvN-dhtodL6l1BT_z)


## Etapa 2
Criação da Azure Function no Portal Azure

### Passo 1

Crie um recurso do tipo Function App com as configurações que desejar.

![Passo 2](https://drive.google.com/uc?export=view&id=13xJhLb5_-dMzRGQwx-gN7FC7U3Pjz1_w)

### Passo 2: 

Suba a Azure Function para o DevOps. Você pode ver um exemplo de como fazer isso pelo Azure DevOps em [typinghard.azure-devops-tracker-function](https://dev.azure.com/TypingHard/Typing%20Hard%20Project/_build?definitionId=7) e o exemplo do [yalm](https://github.com/typinghard/azure-devops-tracker-function/blob/main/azure-pipelines.yml).

### Passo 3: 

Após isso, as Functions poderão ser visualizadas no Azure Portal. No exemplo abaixo, estão as Functions criadas nesse repositório.

![Passo 3](https://drive.google.com/uc?export=view&id=1MpChtcrI1MI4mvoWR3QXAtz6g2bUbMsX)

### Passo 4:

Configurar no Azure DevOps as URLs, procedimento que também pode ser visto na Wiki na seção [Configurando o DevOps](https://github.com/typinghard/azure-devops-tracker/wiki/Portugu%C3%AAs#configurando-o-devops)
