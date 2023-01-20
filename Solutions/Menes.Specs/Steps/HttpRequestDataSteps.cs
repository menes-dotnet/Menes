// <copyright file="HttpRequestDataSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps;

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Corvus.Testing.SpecFlow;

using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.DependencyInjection;

using TechTalk.SpecFlow;

[Binding]
public class HttpRequestDataSteps
{
    private readonly IServiceProvider serviceProvider;
    private readonly FakeFunctionContext ctx;
    private readonly OpenApiParameterParsingSteps openApiSteps;
    private FakeHttpRequestData request;

    public HttpRequestDataSteps(
        ScenarioContext scenarioContext,
        OpenApiParameterParsingSteps openApiSteps)
    {
        this.serviceProvider = ContainerBindings.GetServiceProvider(scenarioContext);
        this.ctx = new();
        this.request = new FakeHttpRequestData(this.ctx, new Uri("https://example.com/pets"), "GET");
        this.openApiSteps = openApiSteps;
    }

    [When("I try to parse the value '([^']*)' as the HttpRequestData body")]
    public async Task WhenITryToParseTheValueAsTheHttpRequestDataBody(string body)
    {
        IOpenApiParameterBuilder<HttpRequestData> builder = this.serviceProvider.GetRequiredService<IOpenApiParameterBuilder<HttpRequestData>>();
        this.openApiSteps.Matcher.FindOperationPathTemplate("/pets", "POST", out OpenApiOperationPathTemplate? operationPathTemplate);

        this.request.Headers.Add("Content-Type", "application/json");
        using (StreamWriter w = new(this.request.Body, Encoding.UTF8, leaveOpen: true))
        {
            w.Write(body);
        }

        this.request.Body.Position = 0;

        this.openApiSteps.Parameters = await builder.BuildParametersAsync(this.request, operationPathTemplate!).ConfigureAwait(false);
    }

    [When("I try to parse the value '([^']*)' as the cookie '([^']*)' in an HttpRequestData")]
    public async Task WhenITryToParseTheValueAsTheCookieInAnHttpRequestData(string cookieValue, string cookieName)
    {
        IOpenApiParameterBuilder<HttpRequestData> builder = this.serviceProvider.GetRequiredService<IOpenApiParameterBuilder<HttpRequestData>>();
        this.openApiSteps.Matcher.FindOperationPathTemplate("/pets", "GET", out OpenApiOperationPathTemplate? operationPathTemplate);

        this.request.WritableCookies.Add(new HttpCookie(cookieName, cookieValue));

        this.openApiSteps.Parameters = await builder.BuildParametersAsync(this.request, operationPathTemplate!).ConfigureAwait(false);
    }

    [When("I try to parse the value '([^']*)' as the header '([^']*)' in an HttpRequestData")]
    public async Task WhenITryToParseTheValueAsTheHeaderInAnHttpRequestData(string headerValue, string headerName)
    {
        IOpenApiParameterBuilder<HttpRequestData> builder = this.serviceProvider.GetRequiredService<IOpenApiParameterBuilder<HttpRequestData>>();
        this.openApiSteps.Matcher.FindOperationPathTemplate("/pets", "GET", out OpenApiOperationPathTemplate? operationPathTemplate);

        this.request.Headers.Add(headerName, headerValue);

        this.openApiSteps.Parameters = await builder.BuildParametersAsync(this.request, operationPathTemplate!).ConfigureAwait(false);
    }

    [When("I try to parse the value '([^']*)' as the query parameter '([^']*)' in an HttpRequestData")]
    public async Task WhenITryToParseTheValueAsTheQueryParameterInAnHttpRequestData(string headerValue, string headerName)
    {
        IOpenApiParameterBuilder<HttpRequestData> builder = this.serviceProvider.GetRequiredService<IOpenApiParameterBuilder<HttpRequestData>>();
        this.openApiSteps.Matcher.FindOperationPathTemplate("/pets", "GET", out OpenApiOperationPathTemplate? operationPathTemplate);

        this.request = new FakeHttpRequestData(
            this.ctx,
            new Uri($"https://example.com/pets?{headerName}={headerValue}"),
            "GET");

        this.openApiSteps.Parameters = await builder.BuildParametersAsync(this.request, operationPathTemplate!).ConfigureAwait(false);
    }

    private class FakeHttpRequestData : HttpRequestData
    {
        public FakeHttpRequestData(
            FunctionContext functionContext,
            Uri url,
            string method)
            : base(functionContext)
        {
            this.Url = url;
            this.Method = method;
        }

        public override Stream Body { get; } = new MemoryStream();

        public override HttpHeadersCollection Headers { get; } = new();

        public override IReadOnlyCollection<IHttpCookie> Cookies => this.WritableCookies;

        public List<IHttpCookie> WritableCookies { get; } = new List<IHttpCookie>();

        public override Uri Url { get; }

        public override IEnumerable<ClaimsIdentity> Identities { get; } = new List<ClaimsIdentity>();

        public override string Method { get; }

        public override HttpResponseData CreateResponse()
        {
            throw new NotImplementedException();
        }
    }

    // Even though the test doesn't really do anything with this, it has to exist for us
    // to be able to construct our HttpRequestData implementation.
    private class FakeFunctionContext : FunctionContext
    {
        public override string InvocationId => throw new NotImplementedException();

        public override string FunctionId => throw new NotImplementedException();

        public override TraceContext TraceContext => throw new NotImplementedException();

        public override BindingContext BindingContext => throw new NotImplementedException();

        public override RetryContext RetryContext => throw new NotImplementedException();

        public override IServiceProvider InstanceServices
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public override FunctionDefinition FunctionDefinition => throw new NotImplementedException();

        public override IDictionary<object, object> Items
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public override IInvocationFeatures Features => throw new NotImplementedException();
    }
}