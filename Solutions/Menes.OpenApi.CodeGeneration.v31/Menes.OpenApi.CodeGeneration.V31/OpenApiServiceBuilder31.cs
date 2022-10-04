// <copyright file="OpenApiServiceBuilder31.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Collections.Immutable;
using System.Diagnostics;
using System.Text.Json;
using Corvus.Json;
using Corvus.Json.CodeGeneration;
using Menes.OpenApi.CodeGeneration;
using Menes.OpenApiSchema.V31;
using static Menes.OpenApiSchema.V31.Document;

namespace Menes.OpenApi.CodeGenerator.V31;

/// <summary>
/// Builds OpenAPI service output.
/// </summary>
/// <remarks>
/// <para>
/// This builds a list of <see cref="Operation"/> instances which can be passed to the code generator partials.
/// to build types for those operations.
/// </para>
/// <para>
/// It maintains a <see cref="locationStack"/> which keeps track of where in the current document we are (for reference resolution across documents).
/// </para>
/// <para>
/// It maintains a <see cref="serverStack"/> which captures the "servers" defined throughout the structure, pushing
/// and popping them as they go in and out of scope.
/// </para>
/// <para>
/// Similarly, it maintains a <see cref="parametersStack"/> which pushes/pops the parameters defined at a path and operation level
/// depending on scope.
/// </para>
/// <para>
/// For types defined by JSON schema it will use a <see cref="IJsonSchemaBuilder"/>. This allows us to support any schema/dialect
/// for which you have implemented a builder.
/// </para>
/// </remarks>
public class OpenApiServiceBuilder31
{
    private readonly Stack<ServerArray> serverStack = new();
    private readonly Stack<ImmutableList<MenesParameter>> parametersStack = new();
    private readonly IDocumentResolver resolver;
    private readonly List<MenesOperation> operations = new();
    private readonly IJsonSchemaBuilder schemaBuilder;
    private readonly Stack<string> locationStack = new();
    private ImmutableDictionary<JsonReference, TypeAndCode> generatedTypesForSchema;
    private string rootReference;
    private string rootNamespace;

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenApiServiceBuilder31"/> class.
    /// </summary>
    /// <param name="schemaBuilder">The JSON schema builder to use.</param>
    /// <param name="resolver">The document resolver to use.</param>
    public OpenApiServiceBuilder31(IJsonSchemaBuilder schemaBuilder, IDocumentResolver resolver)
    {
        this.schemaBuilder = schemaBuilder;
        this.resolver = resolver;
        this.rootReference = "#";
        this.rootNamespace = "Menes.Generated";
        this.generatedTypesForSchema = ImmutableDictionary<JsonReference, TypeAndCode>.Empty;
    }

    /// <summary>
    /// Build services for the given OpenApi document.
    /// </summary>
    /// <param name="rootReference">The root reference from which to load the document.</param>
    /// <param name="rootNamespace">The (optional) root namespace.</param>
    /// <returns>A <see cref="Task"/> which completes when the services are built.</returns>
    public async Task BuildServices(string rootReference, string? rootNamespace = null)
    {
        Document openApiDocument = await this.ResolveReference<Document>(rootReference).ConfigureAwait(false);
        this.rootReference = rootReference;

        if (!string.IsNullOrEmpty(rootNamespace))
        {
            this.rootNamespace = rootNamespace;
        }

        this.PushReferenceLocation(rootReference);
        this.PushRootServers(openApiDocument);

        await this.ProcessPaths(openApiDocument).ConfigureAwait(false);
    }

    private void PushReferenceLocation(string rootReference)
    {
        if (this.locationStack.IsEmpty())
        {
            this.locationStack.Push(rootReference);
        }
        else
        {
            this.locationStack.Push(new JsonReference(this.locationStack.Peek()).Apply(new JsonReference(rootReference)));
        }
    }

    private void PushPropertyLocation(string propertyName)
    {
        if (this.locationStack.IsEmpty())
        {
            this.locationStack.Push(propertyName);
        }
        else
        {
            this.locationStack.Push(new JsonReference(this.locationStack.Peek()).AppendUnencodedPropertyNameToFragment(propertyName));
        }
    }

    private void PushArrayIndexLocation(int index)
    {
        if (this.locationStack.IsEmpty())
        {
            this.locationStack.Push(index.ToString());
        }
        else
        {
            this.locationStack.Push(new JsonReference(this.locationStack.Peek()).AppendArrayIndexToFragment(index));
        }
    }

    private async Task ProcessPaths(Document openApiDocument)
    {
        this.PushPropertyLocation("paths");

        foreach (JsonObjectProperty pathProperty in openApiDocument.PathsValue.EnumerateObject())
        {
            if (openApiDocument.PathsValue.TryAsPatternPathItem(pathProperty, out PathItem pathItemValue))
            {
                await this.ProcessPathItem(pathProperty.Name, pathItemValue).ConfigureAwait(false);
            }
        }

        this.locationStack.Pop();
    }

    private async Task ProcessPathItem(string path, PathItemOrReference pathItemOrReference)
    {
        this.PushPropertyLocation(path);

        PathItem pathItem;

        bool pushedReference = false;
        if (pathItemOrReference.TryMatchIfEntity(out Reference referenceValue))
        {
            JsonUriReference reference = referenceValue.Ref;
            this.PushReferenceLocation(reference);
            pushedReference = true;
            pathItem = await this.ResolveReference<PathItem>(reference).ConfigureAwait(false);
        }
        else
        {
            pathItem = pathItemOrReference.AsPathItem;
        }

        if (pathItem.Servers.IsNotNullOrUndefined())
        {
            this.serverStack.Push(pathItem.Servers.As<ServerArray>());
        }

        if (pathItem.Parameters.IsNotNullOrUndefined())
        {
            await this.ProcessPathItemParameters(pathItem).ConfigureAwait(false);
        }

        foreach (JsonObjectProperty property in pathItem.EnumerateObject())
        {
            if (pathItem.TryAsPatternOperation(property, out Operation operation))
            {
                await this.ProcessOperation(property.Name, path, operation).ConfigureAwait(false);
            }
        }

        if (pathItem.Servers.IsNotNullOrUndefined())
        {
            this.serverStack.Pop();
        }

        if (pathItem.Parameters.IsNotNullOrUndefined())
        {
            this.parametersStack.Pop();
        }

        if (pushedReference)
        {
            this.locationStack.Pop();
        }

        this.locationStack.Pop();
    }

    private async Task ProcessPathItemParameters(PathItem pathItem)
    {
        this.PushPropertyLocation("parameters");
        ImmutableList<MenesParameter>.Builder parameterBuilder = ImmutableList.CreateBuilder<MenesParameter>();
        int index = 0;
        foreach (ParameterOrReference itemOrReference in pathItem.Parameters.EnumerateArray())
        {
            bool resolvedReference = false;
            this.PushArrayIndexLocation(index);
            index++;
            Parameter parameterValue;
            if (itemOrReference.TryMatchIfEntity(out Reference referenceValue))
            {
                JsonUriReference reference = referenceValue.Ref;
                resolvedReference = true;
                this.PushReferenceLocation(reference);
                parameterValue = await this.ResolveReference<Parameter>(reference).ConfigureAwait(false);
            }
            else
            {
                parameterValue = itemOrReference.AsParameter;
            }

            parameterBuilder.Add(this.ProcessParameter(parameterValue, this.locationStack.Peek()));

            if (resolvedReference)
            {
                this.locationStack.Pop();
            }

            this.locationStack.Pop();
        }

        this.parametersStack.Push(parameterBuilder.ToImmutable());

        this.locationStack.Pop();
    }

    private async Task ProcessOperation(JsonPropertyName verb, string path, Operation operation)
    {
        if (operation.Servers.IsNotNullOrUndefined())
        {
            this.serverStack.Push(operation.Servers.As<ServerArray>());
        }

        if (operation.Parameters.IsNotNullOrUndefined())
        {
            ImmutableList<MenesParameter> parameters = await this.ProcessOperationParameters(operation).ConfigureAwait(false);
            this.parametersStack.Push(parameters);
        }

        List<MenesRequestBodyMediaType>? requestBodyMediaTypes = null;

        if (operation.RequestBody.IsNotNullOrUndefined())
        {
            requestBodyMediaTypes = await this.ProcessOperationRequestBody(operation).ConfigureAwait(false);
        }

        string dotnetTypeName = this.GetOperationDotnetTypeName(operation);
        List<MenesResponse> responses = await this.ProcessOperationResponses(dotnetTypeName, operation).ConfigureAwait(false);

        var operationModel = new MenesOperation(
            id: operation.OperationId,
            verb: verb,
            path: path,
            dotnetTypeName: dotnetTypeName,
            requestBodyMediaTypes: requestBodyMediaTypes?.ToImmutableArray(),
            responses: responses.ToImmutableArray(),
            parameters: this.MergeParameters(),
            summary: operation.Summary.AsOptionalString());

        this.operations.Add(operationModel);

        if (operation.Servers.IsNotNullOrUndefined())
        {
            this.serverStack.Pop();
        }

        if (operation.Parameters.IsNotNullOrUndefined())
        {
            this.parametersStack.Pop();
        }
    }

    private async Task<List<MenesResponse>> ProcessOperationResponses(string operationName, Operation operation)
    {
        this.PushPropertyLocation("responses");

        var result = new List<MenesResponse>();

        foreach (JsonObjectProperty property in operation.Responses.EnumerateObject())
        {
            if (operation.Responses.TryAsPatternResponseOrReference(property, out ResponseOrReference responseOrReference))
            {
                MenesResponse response = await this.ProcessOperationResponse(operationName, property.Name, responseOrReference).ConfigureAwait(false);
                result.Add(response);
            }
        }

        this.locationStack.Pop();

        return result;
    }

    private async Task<MenesResponse> ProcessOperationResponse(string operationName, string statusCode, ResponseOrReference responseOrReferenceEntity)
    {
        this.PushPropertyLocation(statusCode);

        bool pushedReference = false;

        Response response;
        if (responseOrReferenceEntity.TryMatchIfEntity(out Reference referenceValue))
        {
            JsonUriReference reference = referenceValue.Ref;
            this.PushReferenceLocation(reference);
            pushedReference = true;
            response = await this.ResolveReference<Response>(reference).ConfigureAwait(false);
        }
        else
        {
            response = responseOrReferenceEntity.AsResponse;
        }

        ImmutableArray<MenesResponseHeader> headers = await this.ProcessResponseHeaders(response.Headers).ConfigureAwait(false);

        // Enumerate the media types in the object
        foreach (JsonObjectProperty mediaTypeProperty in response.Content.EnumerateObject())
        {
            string mediaType = mediaTypeProperty.Name;
        }

        if (pushedReference)
        {
            this.locationStack.Pop();
        }

        this.locationStack.Pop();
    }

    private async Task<ImmutableArray<MenesResponseHeader>> ProcessResponseHeaders(Response.HeadersEntity headers)
    {
        ImmutableArray<MenesResponseHeader>.Builder result = ImmutableArray.CreateBuilder<MenesResponseHeader>();

        this.PushPropertyLocation("headers");
        foreach (JsonObjectProperty headerProperty in headers.EnumerateObject())
        {
            bool pushedReference = false;
            string headerName = headerProperty.Name;
            this.PushPropertyLocation(headerName);

            HeaderOrReference headerOrReference = headerProperty.ValueAs<HeaderOrReference>();
            Header header;
            if (headerOrReference.TryMatchIfEntity(out Reference referenceValue))
            {
                JsonUriReference reference = referenceValue.Ref;
                this.PushReferenceLocation(reference);
                pushedReference = true;
                header = await this.ResolveReference<Header>(reference).ConfigureAwait(false);
            }
            else
            {
                header = headerOrReference.AsHeader;
            }

            MenesResponseHeader responseHeader = await this.ProcessResponseHeader(headerName, header).ConfigureAwait(false);
            result.Add(responseHeader);

            this.locationStack.Pop();

            if (pushedReference)
            {
                this.locationStack.Pop();
            }
        }

        this.locationStack.Pop();

        return result.ToImmutable();
    }

    private async Task<MenesResponseHeader> ProcessResponseHeader(string headerName, Header header)
    {
        string reference = string.Empty;
        string? contentMediaType = null;

        if (header.TryAsDependentSchemaForSchema(out Header.SchemaEntity _))
        {
            this.PushPropertyLocation("schema");
            reference = this.locationStack.Peek();
            (string _, ImmutableDictionary<JsonReference, TypeAndCode> generatedTypes) = await this.schemaBuilder.BuildTypesFor(new JsonReference(reference), this.rootNamespace).ConfigureAwait(false);
            this.MergeTypesFrom(generatedTypes);
            this.locationStack.Pop();
        }
        else
        {
            this.PushPropertyLocation("content");
            int count = 0;
            foreach (JsonObjectProperty contentProperty in header.Content.EnumerateObject())
            {
                count++;
                Debug.Assert(count < 2, "There must be only 1 content media type in a response header.");
                contentMediaType = contentProperty.Name;
                this.PushPropertyLocation(contentMediaType);
                reference = this.locationStack.Peek();
                (string _, ImmutableDictionary<JsonReference, TypeAndCode> generatedTypes) = await this.schemaBuilder.BuildTypesFor(new JsonReference(reference), this.rootNamespace).ConfigureAwait(false);
                this.MergeTypesFrom(generatedTypes);
                this.locationStack.Pop();
            }

            Debug.Assert(count != 0, "There must be a content media type in a response header, if there is no schema.");

            this.locationStack.Pop();
        }

        return new MenesResponseHeader(headerName, reference, header.Required, contentMediaType);
    }

    private string GetOperationDotnetTypeName(Operation operation)
    {
        ReadOnlySpan<char> baseName = Formatting.ToPascalCaseWithReservedWords(operation.OperationId);
        Span<char> name = stackalloc char[baseName.Length + 10];
        baseName.CopyTo(name);
        int length = baseName.Length;
        int extension = 0;

        while (ContainsName(this.operations, name[..length]))
        {
            extension++;
            extension.TryFormat(name[baseName.Length..], out int charsWritten);
            length = baseName.Length + charsWritten;
        }

        return name[..length].ToString();

        static bool ContainsName(List<MenesOperation> operations, ReadOnlySpan<char> name)
        {
            foreach (MenesOperation existingOperation in operations)
            {
                if (name.SequenceEqual(existingOperation.DotnetTypeName))
                {
                    return true;
                }
            }

            return false;
        }
    }

    private async Task<List<MenesRequestBodyMediaType>> ProcessOperationRequestBody(Operation operation)
    {
        RequestBody requestBody;

        this.PushPropertyLocation("requestBody");

        bool pushedReference = false;
        if (operation.RequestBody.TryMatchIfEntity(out Reference referenceValue))
        {
            JsonUriReference reference = referenceValue.Ref;
            this.PushReferenceLocation(reference);
            pushedReference = true;
            requestBody = await this.ResolveReference<RequestBody>(reference).ConfigureAwait(false);
        }
        else
        {
            requestBody = operation.RequestBody.AsRequestBody;
        }

        var mediaTypes = new List<MenesRequestBodyMediaType>();

        this.PushPropertyLocation("content");

        foreach (JsonObjectProperty mediaType in requestBody.Content.EnumerateObject())
        {
            this.PushPropertyLocation(mediaType.Name);
            (string rootType, ImmutableDictionary<JsonReference, TypeAndCode> generatedTypes) = await this.schemaBuilder.BuildTypesFor(new JsonReference(this.locationStack.Peek()), this.rootNamespace).ConfigureAwait(false);
            this.MergeTypesFrom(generatedTypes);
            mediaTypes.Add(new MenesRequestBodyMediaType(mediaType.Name, Formatting.ToPascalCaseWithReservedWords(((string)mediaType.Name).Replace("*", "Any")).ToString(), rootType));
            this.locationStack.Pop();
        }

        if (pushedReference)
        {
            this.locationStack.Pop();
        }

        this.locationStack.Pop();

        return mediaTypes;
    }

    private void MergeTypesFrom(ImmutableDictionary<JsonReference, TypeAndCode> generatedTypes)
    {
        this.generatedTypesForSchema = this.generatedTypesForSchema.Union(generatedTypes).ToImmutableDictionary();
    }

    private async Task<ImmutableList<MenesParameter>> ProcessOperationParameters(Operation operation)
    {
        this.PushPropertyLocation("parameters");
        ImmutableList<MenesParameter>.Builder parameterBuilder = ImmutableList.CreateBuilder<MenesParameter>();
        int index = 0;
        foreach (ParameterOrReference itemOrReference in operation.Parameters.EnumerateArray())
        {
            this.PushArrayIndexLocation(index);
            index++;
            Parameter parameterValue;

            bool matchedReference = false;

            if (itemOrReference.TryMatchIfEntity(out Reference referenceValue))
            {
                JsonUriReference reference = referenceValue.Ref;
                matchedReference = true;
                this.PushReferenceLocation(reference);
                parameterValue = await this.ResolveReference<Parameter>(reference).ConfigureAwait(false);
            }
            else
            {
                parameterValue = itemOrReference.AsParameter;
            }

            parameterBuilder.Add(this.ProcessParameter(parameterValue, this.locationStack.Peek()));

            if (matchedReference)
            {
                this.locationStack.Pop();
            }

            this.locationStack.Pop();
        }

        this.locationStack.Pop();
        return parameterBuilder.ToImmutable();
    }

    private MenesParameter ProcessParameter(Parameter parameterValue, string location)
    {
        return parameterValue switch
        {
            var pv when pv.In == Parameter.InEntity.EnumValues.Header => this.ProcessHeaderParameter(parameterValue, location),
            var pv when pv.In == Parameter.InEntity.EnumValues.Cookie => this.ProcessCookieParameter(parameterValue, location),
            var pv when pv.In == Parameter.InEntity.EnumValues.Path => this.ProcessPathParameter(parameterValue, location),
            var pv when pv.In == Parameter.InEntity.EnumValues.Query => this.ProcessQueryParameter(parameterValue, location),
            _ => throw new InvalidOperationException($"Unexpected In value for parameter at '{location}'"),
        };
    }

    private MenesParameter ProcessHeaderParameter(Parameter parameterValue, string location)
    {
        throw new NotImplementedException();
    }

    private MenesParameter ProcessCookieParameter(Parameter parameterValue, string location)
    {
        throw new NotImplementedException();
    }

    private MenesParameter ProcessPathParameter(Parameter parameterValue, string location)
    {
        throw new NotImplementedException();
    }

    private MenesParameter ProcessQueryParameter(Parameter parameterValue, string location)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Creates the merged list of parameters for the current context.
    /// </summary>
    /// <returns>A list of parameter values which represents the set for the current context.</returns>
    private ImmutableDictionary<string, MenesParameter> MergeParameters()
    {
        ImmutableDictionary<string, MenesParameter>.Builder result = ImmutableDictionary.CreateBuilder<string, MenesParameter>();
        foreach (ImmutableList<MenesParameter> parameters in this.parametersStack.Reverse())
        {
            foreach (MenesParameter parameter in parameters)
            {
                result[parameter.Name] = parameter;
            }
        }

        return result.ToImmutable();
    }

    private void PushRootServers(Document openApiDocument)
    {
        if (openApiDocument.Servers.IsNotNullOrUndefined())
        {
            this.serverStack.Push(openApiDocument.Servers);
        }
        else
        {
            this.serverStack.Push(
                ServerArray.FromItems(Server.Create("/")));
        }
    }

    private async Task<T> ResolveReference<T>(string reference)
        where T : struct, IJsonValue<T>
    {
        JsonElement? openApiElement = await this.resolver.TryResolve(new JsonReference(reference)).ConfigureAwait(false);

        if (openApiElement is JsonElement element)
        {
            var entity = T.FromJson(element);
            if (!entity.IsValid())
            {
                throw new ArgumentException($"The entity at '{reference}' is not a valid {typeof(T).Name}.", nameof(reference));
            }

            return entity;
        }

        throw new ArgumentException($"Unable to resolve the {typeof(T).Name} at '{reference}'.", nameof(reference));
    }
}