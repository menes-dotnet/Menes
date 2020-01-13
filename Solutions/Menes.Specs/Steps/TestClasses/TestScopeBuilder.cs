namespace Menes.Specs.Steps.TestClasses
{
    using System;
    using System.Threading.Tasks;
    using Menes;
    using Microsoft.AspNetCore.Http;

    public class TestScopeBuilder : IOpenApiScopeBuilder<HttpRequest>
    {
        public Task BuildScope(IServiceProvider serviceProvider, string path, string method, HttpRequest request, object parameters, OpenApiOperationPathTemplate operationPathTemplate)
        {
            return Task.CompletedTask;
        }
    }
}
