// <copyright file="OpenApiServiceBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.OpenApi.SchemaModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Menes.Json;
    using Menes.Json.SchemaModel;

    /// <summary>
    /// Builds OpenAPI service output.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This builds a list of <see cref="Operation"/> instances which can be passed to the <see cref="AspNetOperationEntityPartial"/>
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
    /// for which you have implemented a builder (currently Draft202012 and Draft201909).
    /// </para>
    /// </remarks>
    public class OpenApiServiceBuilder
    {
        private readonly Stack<Document.ServerValueArray> serverStack = new Stack<Document.ServerValueArray>();
        private readonly Stack<ImmutableList<Parameter>> parametersStack = new Stack<ImmutableList<Parameter>>();
        private readonly IDocumentResolver resolver;
        private readonly List<Operation> operations = new List<Operation>();
        private readonly IJsonSchemaBuilder schemaBuilder;
        private readonly Stack<string> locationStack = new Stack<string>();
        private ImmutableDictionary<string, (string, string)> generatedTypesForSchema;
        private string rootReference;
        private string rootNamespace;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiServiceBuilder"/> class.
        /// </summary>
        /// <param name="schemaBuilder">The JSON schema builder to use.</param>
        /// <param name="resolver">The document resolver to use.</param>
        public OpenApiServiceBuilder(IJsonSchemaBuilder schemaBuilder, IDocumentResolver resolver)
        {
            this.schemaBuilder = schemaBuilder;
            this.resolver = resolver;
            this.rootReference = "#";
            this.rootNamespace = "Menes.Generated";
            this.generatedTypesForSchema = ImmutableDictionary<string, (string, string)>.Empty;
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

            foreach (Property pathProperty in openApiDocument.Paths.EnumerateObject())
            {
                if (openApiDocument.Paths.MatchesPatternPathItemValue(pathProperty))
                {
                    Document.PathItemOrReferenceEntity pathItem = openApiDocument.Paths.AsPatternPathItemValue(pathProperty);
                    await this.ProcessPathItem(pathProperty.Name, pathItem).ConfigureAwait(false);
                }
            }

            this.locationStack.Pop();
        }

        private async Task ProcessPathItem(string path, Document.PathItemOrReferenceEntity pathItemOrReference)
        {
            this.PushPropertyLocation(path);

            Document.PathItemValue pathItem;

            bool pushedReference = false;
            if (pathItemOrReference.IsIfMatchReferenceValue)
            {
                JsonUri reference = pathItemOrReference.AsIfMatchReferenceValue.Ref;
                this.PushReferenceLocation(reference);
                pushedReference = true;
                pathItem = await this.ResolveReference<Document.PathItemValue>(reference).ConfigureAwait(false);
            }
            else
            {
                pathItem = pathItemOrReference.AsElseMatchPathItemValue;
            }

            if (pathItem.Servers.IsNotNullOrUndefined())
            {
                this.serverStack.Push(pathItem.Servers.As<Document.ServerValueArray>());
            }

            if (pathItem.Parameters.IsNotNullOrUndefined())
            {
                await this.ProcessPathItemParameters(pathItem).ConfigureAwait(false);
            }

            foreach (Property property in pathItem.EnumerateObject())
            {
                if (IsOperationValue(property))
                {
                    await this.ProcessOperation(property.ValueAs<Document.OperationValue>()).ConfigureAwait(false);
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

            static bool IsOperationValue(Property pathItemProperty)
            {
                return Document.PathItemValue.PatternPropertyOperationValue.IsMatch(pathItemProperty.Name);
            }
        }

        private async Task ProcessPathItemParameters(Document.PathItemValue pathItem)
        {
            this.PushPropertyLocation("parameters");
            ImmutableList<Parameter>.Builder parameterBuilder = ImmutableList.CreateBuilder<Parameter>();
            int index = 0;
            foreach (Document.ParameterOrReferenceEntity itemOrReference in pathItem.Parameters.EnumerateItems())
            {
                bool resolvedReference = false;
                this.PushArrayIndexLocation(index);
                index++;
                Document.ParameterValue parameterValue;
                if (itemOrReference.IsIfMatchReferenceValue)
                {
                    JsonUri reference = itemOrReference.AsIfMatchReferenceValue.Ref;
                    resolvedReference = true;
                    this.PushReferenceLocation(reference);
                    parameterValue = await this.ResolveReference<Document.ParameterValue>(reference).ConfigureAwait(false);
                }
                else
                {
                    parameterValue = itemOrReference.AsElseMatchParameterValue;
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

        private async Task ProcessOperation(Document.OperationValue operation)
        {
            if (operation.Servers.IsNotNullOrUndefined())
            {
                this.serverStack.Push(operation.Servers.As<Document.ServerValueArray>());
            }

            if (operation.Parameters.IsNotNullOrUndefined())
            {
                ImmutableList<Parameter> parameters = await this.ProcessOperationParameters(operation).ConfigureAwait(false);
                this.parametersStack.Push(parameters);
            }

            List<RequestBodyMediaType>? requestBodyMediaTypes = null;

            if (operation.RequestBody.IsNotNullOrUndefined())
            {
                requestBodyMediaTypes = await this.ProcessOperationRequestBody(operation).ConfigureAwait(false);
            }

            List<Response>? responses = null;

            if (operation.Responses.IsNotNullOrUndefined())
            {
                responses = await this.ProcessOperationResponses(operation).ConfigureAwait(false);
            }

            var operationModel = new Operation(
                dotnetTypeName: this.GetOperationDotnetTypeName(operation),
                requestBodyMediaTypes: requestBodyMediaTypes?.ToImmutableArray(),
                responses: responses?.ToImmutableArray(),
                parameters: this.MergeParameters());

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

        private async Task<List<Response>> ProcessOperationResponses(Document.OperationValue operation)
        {
            this.PushPropertyLocation("responses");

            var result = new List<Response>();

            foreach (Property property in operation.Responses.EnumerateObject())
            {
                if (operation.Responses.MatchesPatternResponseOrReferenceEntity(property))
                {
                    Response response = await this.ProcessOperationResponse(property.Name, operation.Responses.AsPatternResponseOrReferenceEntity(property)).ConfigureAwait(false);
                    result.Add(response);
                }
            }

            this.locationStack.Pop();

            return result;
        }

        private Task<Response> ProcessOperationResponse(string name, Document.ResponseOrReferenceEntity responseOrReferenceEntity)
        {
            throw new NotImplementedException();
        }

        private string GetOperationDotnetTypeName(Document.OperationValue operation)
        {
            ReadOnlySpan<char> baseName = Formatting.ToPascalCaseWithReservedWords(operation.OperationId);
            Span<char> name = stackalloc char[baseName.Length + 10];
            baseName.CopyTo(name);
            int length = baseName.Length;
            int extension = 0;

            while (ContainsName(this.operations, name.Slice(0, length)))
            {
                extension++;
                extension.TryFormat(name[baseName.Length..], out int charsWritten);
                length = baseName.Length + charsWritten;
            }

            return name.Slice(0, length).ToString();

            static bool ContainsName(List<Operation> operations, ReadOnlySpan<char> name)
            {
                foreach (Operation existingOperation in operations)
                {
                    if (name.SequenceEqual(existingOperation.DotnetTypeName))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        private async Task<List<RequestBodyMediaType>> ProcessOperationRequestBody(Document.OperationValue operation)
        {
            Document.RequestBodyValue requestBody;

            this.PushPropertyLocation("requestBody");

            bool pushedReference = false;
            if (operation.RequestBody.IsIfMatchReferenceValue)
            {
                JsonUri reference = operation.RequestBody.AsIfMatchReferenceValue.Ref;
                this.PushReferenceLocation(reference);
                pushedReference = true;
                requestBody = await this.ResolveReference<Document.RequestBodyValue>(reference).ConfigureAwait(false);
            }
            else
            {
                requestBody = operation.RequestBody.AsElseMatchRequestBodyValue;
            }

            var mediaTypes = new List<RequestBodyMediaType>();

            this.PushPropertyLocation("content");

            foreach (Property<Document.MediaTypeValue> mediaType in requestBody.Content.EnumerateProperties())
            {
                this.PushPropertyLocation(mediaType.Name);
                (string rootType, ImmutableDictionary<string, (string, string)> generatedTypes) = await this.schemaBuilder.BuildTypesFor(this.locationStack.Peek(), this.rootNamespace).ConfigureAwait(false);
                this.MergeTypesFrom(generatedTypes);
                mediaTypes.Add(new RequestBodyMediaType(mediaType.Name, Formatting.ToPascalCaseWithReservedWords(mediaType.Name.Replace("*", "Any")).ToString(), rootType));
                this.locationStack.Pop();
            }

            if (pushedReference)
            {
                this.locationStack.Pop();
            }

            this.locationStack.Pop();

            return mediaTypes;
        }

        private void MergeTypesFrom(ImmutableDictionary<string, (string, string)> generatedTypes)
        {
            this.generatedTypesForSchema = this.generatedTypesForSchema.Union(generatedTypes).ToImmutableDictionary();
        }

        private async Task<ImmutableList<Parameter>> ProcessOperationParameters(Document.OperationValue operation)
        {
            this.PushPropertyLocation("parameters");
            ImmutableList<Parameter>.Builder parameterBuilder = ImmutableList.CreateBuilder<Parameter>();
            int index = 0;
            foreach (Document.ParameterOrReferenceEntity itemOrReference in operation.Parameters.EnumerateItems())
            {
                this.PushArrayIndexLocation(index);
                index++;
                Document.ParameterValue parameterValue;

                bool matchedReference = false;

                if (itemOrReference.IsIfMatchReferenceValue)
                {
                    JsonUri reference = itemOrReference.AsIfMatchReferenceValue.Ref;
                    matchedReference = true;
                    this.PushReferenceLocation(reference);
                    parameterValue = await this.ResolveReference<Document.ParameterValue>(reference).ConfigureAwait(false);
                }
                else
                {
                    parameterValue = itemOrReference.AsElseMatchParameterValue;
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

        private Parameter ProcessParameter(Document.ParameterValue parameterValue, string location)
        {
            return parameterValue switch
            {
                var pv when pv.In == Document.ParameterValue.InEntity.EnumValues.Header => this.ProcessHeaderParameter(parameterValue, location),
                var pv when pv.In == Document.ParameterValue.InEntity.EnumValues.Cookie => this.ProcessCookieParameter(parameterValue, location),
                var pv when pv.In == Document.ParameterValue.InEntity.EnumValues.Path => this.ProcessPathParameter(parameterValue, location),
                var pv when pv.In == Document.ParameterValue.InEntity.EnumValues.Query => this.ProcessQueryParameter(parameterValue, location),
                _ => throw new InvalidOperationException($"Unexpected In value for parameter at '{location}'")
            };
        }

        private Parameter ProcessHeaderParameter(Document.ParameterValue parameterValue, string location)
        {
            throw new NotImplementedException();
        }

        private Parameter ProcessCookieParameter(Document.ParameterValue parameterValue, string location)
        {
            throw new NotImplementedException();
        }

        private Parameter ProcessPathParameter(Document.ParameterValue parameterValue, string location)
        {
            throw new NotImplementedException();
        }

        private Parameter ProcessQueryParameter(Document.ParameterValue parameterValue, string location)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates the merged list of parameters for the current context.
        /// </summary>
        /// <returns>A list of parameter values which represents the set for the current context.</returns>
        private ImmutableArray<Parameter> MergeParameters()
        {
            ImmutableList<Parameter>.Builder result = ImmutableList.CreateBuilder<Parameter>();
            foreach (ImmutableList<Parameter> parameters in this.parametersStack.Reverse())
            {
                foreach (Parameter parameter in parameters)
                {
                    int index = result.FindIndex(r => r.ParameterValue.In == parameter.ParameterValue.In && r.ParameterValue.Name == parameter.ParameterValue.Name);
                    if (index >= 0)
                    {
                        result.RemoveAt(index);
                    }

                    result.Add(parameter);
                }
            }

            return result.ToImmutableArray();
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
                    Document.ServerValueArray.From(Document.ServerValue.Create("/")));
            }
        }

        private async Task<T> ResolveReference<T>(string reference)
            where T : struct, IJsonValue
        {
            JsonElement? openApiElement = await this.resolver.TryResolve(new JsonReference(reference)).ConfigureAwait(false);

            if (openApiElement is JsonElement element)
            {
                T entity = new JsonAny(element).As<T>();
                if (!entity.IsValid())
                {
                    throw new ArgumentException($"The entity at '{reference}' is not a valid {typeof(T).Name}.", nameof(reference));
                }

                return entity;
            }

            throw new ArgumentException($"Unable to resolve the {typeof(T).Name} at '{reference}'.", nameof(reference));
        }
    }
}
