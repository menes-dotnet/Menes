// <copyright file="IOpenApiService.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    /// <summary>
    /// Implemented by types that provide the implementation of a service described by an OpenAPI document.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Endjin's Open API service provides you with a hosting-agnostic mechanism for contract-first
    /// web services.
    /// </para>
    /// <para>
    /// It leverages the <see href="https://www.openapis.org/"/> specification. You build your web contracts in an
    /// Open API V2 or V3 document using YAML or JSON like the canonical petstore example below.
    /// </para>
    /// <para>
    /// <code language="yaml">
    /// openapi: "3.0.0"
    /// info:
    ///   version: 1.0.0
    ///   title: Swagger Petstore
    ///   license:
    ///     name: MIT
    /// servers:
    ///   - url: http:/// petstore.swagger.io/v1
    /// paths:
    ///   /pets:
    ///     get:
    ///       summary: List all pets
    ///       operationId: listPets
    ///       tags:
    ///         - pets
    ///       parameters:
    ///         - name: limit
    ///           in: query
    ///           description: How many items to return at one time(max 100)
    ///           required: false
    ///           schema:
    ///             type: integer
    ///             format: int32
    ///             maximum: 100
    ///             minimum: 1
    ///         - name: continuationToken
    ///           in: query
    ///           description: The continuation token for a paged result
    ///           required: false
    ///           schema:
    ///             type: string
    ///       responses:
    ///         '200':
    ///           description: A paged array of pets
    ///           headers:
    ///             x-next:
    ///               description: A link to the next page of responses
    ///               schema:
    ///                 type: string
    ///           content:
    ///             application/json:
    ///               schema:
    ///                 $ref: "#/components/schemas/Pets"
    ///         default:
    ///           description: unexpected error
    ///           content:
    ///             application/problem+json:
    ///               schema:
    ///                 $ref: "#/components/schemas/ProblemDetails"
    ///     post:
    ///       summary: Create a pet
    ///       operationId: createPets
    ///       requestBody:
    ///         required: true
    ///         content:
    ///           application/json:
    ///             schema:
    ///               $ref: "#/components/schemas/Pet"
    ///       tags:
    ///         - pets
    ///       responses:
    ///         '201':
    ///           description: Null response
    ///         default:
    ///           description: unexpected error
    ///           content:
    ///             application/problem+json:
    ///               schema:
    ///                 $ref: "#/components/schemas/ProblemDetails"
    ///   /pets/{petId
    /// }:
    ///     get:
    ///       summary: Info for a specific pet
    ///       operationId: showPetById
    ///       tags:
    ///         - pets
    ///       parameters:
    ///         - name: petId
    ///           in: path
    ///           required: true
    ///           description: The id of the pet to retrieve
    ///           schema:
    ///             type: string
    ///       responses:
    ///         '200':
    ///           description: Expected response to a valid request
    ///           content:
    ///             application/json:
    ///               schema:
    ///                 $ref: "#/components/schemas/Pets"
    ///         '404':
    ///           description: No pet with that ID
    ///         default:
    ///           description: unexpected error
    ///           content:
    ///             application/problem+json:
    ///               schema:
    ///                 $ref: "#/components/schemas/ProblemDetails"
    /// components:
    ///   schemas:
    ///     Pet:
    ///       required:
    ///         - id
    ///         - name
    ///       properties:
    ///         id:
    ///           type: integer
    ///           format: int64
    ///         name:
    ///           type: string
    ///         tag:
    ///           type: string
    ///     Pets:
    ///       type: array
    ///       items:
    ///         $ref: "#/components/schemas/Pet"
    ///     ProblemDetails:
    ///       required:
    ///         - status
    ///         - detail
    ///       properties:
    ///         status:
    ///           type: integer
    ///           format: int32
    ///         detail:
    ///           type: string
    ///         title:
    ///           type: string
    ///         instance:
    ///           type: string
    ///           format: url
    ///         type:
    ///           type: string
    ///           format: url
    ///       additionalProperties: true
    /// </code>
    /// </para>
    /// <para>
    /// You can then implement your services as plain .NET types.
    /// </para>
    /// <para>
    /// <code>
    /// public class PetStore : IOpenApiService
    /// {
    ///     [OperationId("showPetById")]
    ///     public Pet ShowPet(string petId)
    ///     {
    ///         return new Pet(petId);
    ///     }
    /// }
    /// </code>
    /// </para>
    /// <para>
    /// You implement <see cref="IOpenApiService"/>, and decorate methods that implement an operation with the unique operation ID from the Open API specification.
    /// It will then be discovered by the framework, and parameter binding made automatically by
    /// matching the parameter names and types. A special parameter name "body" is used to receive the request body.
    /// </para>
    /// <para>
    /// Any constraints you have applied in your Open API definition (e.g. min/max/range/count, required) will be validated
    /// by the framework and appropriate exceptions thrown. (see below for information on mapping exceptions to responses and status code.)
    /// </para>
    /// <para>
    /// Type serialization is handled by standard .NET serializers (for the body) or <see cref="Converters.IOpenApiConverter"/> for header, URI and query string parameters.
    /// </para>
    /// <para>
    /// Returning a POCO as above will result in a 200 result code, and the type serialized into the response body. For more control over the output (including setting headers
    /// and alternative result codes) you can return an <see cref="OpenApiResult"/>. There are also extension methods on <see cref="IOpenApiService"/> to assist with creating common result types.
    /// </para>
    /// <para>
    /// For example, here is an implementation of the pet store service "listPets" operation that builds a continuation token and adds the header for it.
    /// </para>
    /// <para>
    /// <code>
    /// [OperationId("listPets")]
    /// public OpenApiResult ListPets(int limit = 10, string continuationToken = null)
    /// {
    ///     var skip = ParseContinuationToken(continuationToken);
    ///
    ///     var result = this.OkResult(this.pets.Skip(skip).Take(limit).ToArray());
    ///
    ///     if (skip + limit &lt; this.pets.Count)
    ///     {
    ///         result.Results.Add("x-next", this.BuildNextUri(limit, BuildContinuationToken(limit + skip)));
    ///     }
    ///
    ///     return result;
    /// }
    /// </code>
    /// </para>
    /// <para>
    /// The framework looks at the response definition in the Open API document, and recognizes that "x-next" is the name of a header,
    /// and so it automatically writes that value into the reponse appropriately.
    /// </para>
    /// <para>
    /// You will notice that we are just passing the value we want as the response body into the <see cref="OpenApiServiceExtensions.OkResult"/> method.
    /// This causes it to be added as a response for the "application/json" media type. If you want a different media type, you can just pass it in as an extra string.
    /// <code>
    /// this.OkResult(this.pets.Skip(skip).Take(limit).ToArray(), "application/vnd.menes.sometype+json");
    /// </code>
    /// </para>
    /// <para>
    /// You can even set multiple different values for different content types, but at the moment the framework only supports JSON serialization. In the future it will be
    /// extended to support content type negotation, through this mechanism.
    /// </para>
    /// <para>
    /// A common requirement is to send a URI to a service operation in a response header (e.g. a "location" header to indicate where something has been created). In this
    /// example, we are return an "x-next" header which includes the URI at which you can get the next page of results. To avoid having to build these URIs by hand, we provide the
    /// <see cref="IOpenApiDocumentProvider.GetResolvedOperationRequestInfo"/> which leverages the Open API URI path templates and parameter definitions to generate URIs from the parameters you provide.
    /// You specify the operation id, and an arbitrary number of parameter name and value tuples to fulfil the needs of the parameter template. For example, here's the code to populate
    /// the URI for the "listPets" operation:
    /// </para>
    /// <para>
    /// <code>
    /// this.templateProvider.GetUri("listPets", ("limit", limit), ("continuationToken", continuationToken));
    /// </code>
    /// </para>
    /// <para>
    /// We currently support hosting in any environment that uses the aspnetcore <c>HttpRequest</c> model. At the time of writing, this means Azure Functions and  AspNetCore. This can and will be extended in future.
    /// </para>
    /// <para>
    /// To host in functions, you should provide a function entry point with a catch-all for your base URI, and any operation types you need to support (GET, POST etc.)
    /// </para>
    /// <para>
    /// <code>
    /// [FunctionName("openapihostroot")]
    /// public static Task&lt;IActionResult&gt; RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "{*path}")]HttpRequest req, ExecutionContext context, ILogger log)
    /// {
    ///     Initialize(context);
    ///
    ///     var host = ServiceRoot.ServiceProvider.GetRequiredService&lt;OpenApiHttpRequestHost&gt;();
    ///     return host.HandleRequest(req);
    /// }
    /// </code>
    /// </para>
    /// <para>
    /// Initialization is handled through the container.
    /// </para>
    /// <para>
    /// <code>
    /// private static void Initialize(ExecutionContext context)
    /// {
    ///     Functions.InitializeContainer(context, services =&gt;
    ///     {
    ///         services.AddOpenApiHttpHosting(host =&gt;
    ///         {
    ///             using (var stream = File.OpenRead(".\\yaml\\petstore.yaml"))
    ///             {
    ///                 var openApiDocument = new OpenApiStreamReader().Read(stream, out var diagnostics);
    ///                 host.AddDocument(openApiDocument);
    ///             }
    ///         });
    ///
    ///         // We can add all the services here
    ///         services.AddSingleton&lt;IOpenApiService, PetStoreService&gt;();
    ///     });
    /// }
    /// </code>
    /// </para>
    /// <para>
    /// You can add as many <see cref="IOpenApiService"/> instances to the container as you have, but the framework will
    /// <i>only</i> expose those that are bound to Open API documents that you have added to the host. While you typically
    /// add documents on startup, you can add more at runtime to light up services that are registered in the container, but not
    /// actually bound to Open API documents.
    /// </para>
    /// <para>
    /// By default, any exceptions thrown by the service will be bound to 500 errors on the outbound side. However, you can
    /// configure this behaviour so that well-known exceptions are bound to particular HTTP status codes. For example, this binds
    /// all <see cref="System.InvalidOperationException"/> to the "400 - BadRequest" status code, and all <c>PetNotFoundException</c> instances
    /// to "404 - Not Found".
    /// </para>
    /// <para>
    /// <code>
    /// services.AddOpenApiHttpHosting(host =&gt;
    /// {
    ///     using (var stream = File.OpenRead(".\\yaml\\petstore.yaml"))
    ///     {
    ///         var openApiDocument = new OpenApiStreamReader().Read(stream, out var diagnostics);
    ///         host.AddDocument(openApiDocument);
    ///         host.Map&lt;PetNotFoundException&gt;(404);
    ///         host.Map&lt;InvalidOperationException&gt;(400);
    ///     }
    /// });
    /// </code>
    /// </para>
    /// <para>
    /// These defaults will be used for all operations exposed by this service. If you want to scope the operation to a particular
    /// operation, just pass the operation ID as a second parameter e.g.
    /// </para>
    /// <para>
    /// <code>
    /// host.Map&lt;PetNotFoundException&gt;(404, "listPets");
    /// </code>
    /// </para>
    /// <para>
    /// If a status code is specified that is not found in the permitted status codes for a response in the Open API spec, a 500 response
    /// will be provided instead.
    /// </para>
    /// <para>
    /// It can often be useful to provide a reponse body in exceptional circumstances. Along with the status code, you can also specify an <see cref="ExceptionMappers.IExceptionMapper"/> to provide an <see cref="OpenApiResult"/> for a specific exception type.
    /// By default, we provide two exception mappers. We have already described one of these, which is used by default and maps to the provided exception code, or the 500 status code, with no response body. The other implements the ProblemDetails standard described in <see href=" https://datatracker.ietf.org/doc/rfc7807/?include_text=1">RFC7807</see>.
    /// </para>
    /// <para>
    /// To use behaviour, your OpenAPI response needs to conform the ProblemDetails schema. This requires the "application/problem+json" media type, and an object which can be recognized as the ProblemDetails schema. For example:
    /// </para>
    /// <para>
    /// <code>
    /// # ...a response...
    /// 404:
    ///   description: not found
    ///   content:
    ///     application/problem+json:
    ///       schema:
    ///         $ref: "#/components/schemas/ProblemDetails"
    /// # ...and in the schema section...
    /// ProblemDetails:
    ///   required:
    ///     - status
    ///     - detail
    ///   properties:
    ///     status:
    ///       type: integer
    ///       format: int32
    ///     detail:
    ///       type: string
    ///     title:
    ///       type: string
    ///     instance:
    ///       type: string
    ///       format: url
    ///     type:
    ///       type: string
    ///       format: url
    ///   additionalProperties: true
    /// </code>
    /// </para>
    /// <para>
    /// In order to add the standard type, title, detail and extension properties to your exception, we provide extension methods
    /// for <see cref="System.Exception"/> which help you.
    /// </para>
    /// <para>
    /// <code>
    /// throw new InvalidOperationException("Bad continuation token")
    ///     .AddProblemDetailsTitle("Bad continuation token")
    ///     .AddProblemDetailsExplanation("The continuation token could not be decoded")
    ///     .AddProblemDetailsType("/petstore/errors/continuation/unable-to-decode")
    ///     .AddProblemDetailsExtension("continuationToken", continuationToken);
    /// </code>
    /// </para>
    /// </remarks>
    public interface IOpenApiService
    {
    }
}