using Menes.Hosting.AspNetCore;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Menes.PetStore.Hosting.AzureFunctions.Isolated;

public class DemoOpenApiHost
{
    private readonly ILogger<DemoOpenApiHost> logger;
    private readonly IOpenApiHost<HttpRequest, IActionResult> openApiHost;

    public DemoOpenApiHost(ILogger<DemoOpenApiHost> logger, IOpenApiHost<HttpRequest, IActionResult> openApiHost)
    {
        this.logger = logger;
        this.openApiHost = openApiHost;
    }

    [Function("DemoOpenApiHost")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "{*path}")] HttpRequest req)
    {
        this.logger.LogInformation("C# HTTP trigger function processed a request.");
        return await this.openApiHost.HandleRequestAsync(req, new {});
    }
}