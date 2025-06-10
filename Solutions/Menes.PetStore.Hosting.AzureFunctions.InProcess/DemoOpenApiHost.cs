using System.Threading.Tasks;
using Menes.Hosting.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Menes.PetStore.Hosting.AzureFunctions.InProcess;

/// <summary>
/// An example openAPI host.
/// </summary>
public class DemoOpenApiHost
{
    private readonly IOpenApiHost<HttpRequest, IActionResult> host;

    /// <summary>
    /// Initializes a new instance of the <see cref="DemoOpenApiHost"/> class.
    /// </summary>
    /// <param name="host">The OpenApi host.</param>
    public DemoOpenApiHost(IOpenApiHost<HttpRequest, IActionResult> host)
    {
        this.host = host;
    }

    /// <summary>
    /// Azure Functions entry point.
    /// </summary>
    /// <param name="req">The <see cref="HttpRequest"/>.</param>
    /// <param name="executionContext">The context for the function execution.</param>
    /// <returns>An action result which comes from executing the function.</returns>
    [FunctionName("DemoOpenApiHost-OpenApiHostRoot")]
    public Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "{*path}")] HttpRequest req, ExecutionContext executionContext)
    {
        return this.host.HandleRequestAsync(req, new { ExecutionContext = executionContext });
    }
}