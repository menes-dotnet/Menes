// <copyright file="IOpenApiDocumentProvider.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Diagnostics.CodeAnalysis;

    using Corvus.UriTemplates.TavisApi;

    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Provides services over a collection of OpenApi documents.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Clients can inject an instance of this document provider, supplied by the
    /// Open API hosting environment, and use it to obtain URI templates for operations
    /// exposed by that host.
    /// </para>
    /// <para>
    /// Having obtained a URI template, you can use <see cref="UriTemplate.SetParameter(string, object)"/>
    /// to build the URI for your operation, and <see cref="UriTemplate.Resolve()"/> to obtain the URI
    /// formatted with those parameters.
    /// </para>
    /// <para>
    /// Commonly, you will just use the <see cref="GetResolvedOperationRequestInfo"/> method which also handles query string parameters.
    /// to build that directly.
    /// </para>
    /// <para>
    /// </para>
    /// </remarks>
    public interface IOpenApiDocumentProvider : IOpenApiDocuments
    {
        /// <summary>
        /// Get the uri and <see cref="OperationType"/> for an operation exposed by the provider,
        /// using the supplied parameters for the uri.
        /// </summary>
        /// <param name="operationId">The ID of the operation.</param>
        /// <param name="parameters">The parameters with which to populate the template.</param>
        /// <returns>A string representing the URI for the operation with the supplied parameters.</returns>
        /// <remarks>This will also build any query string parameters.</remarks>
        ResolvedOperationRequestInfo GetResolvedOperationRequestInfo(string operationId, params (string Name, object? Value)[] parameters);

        /// <summary>
        /// Get a URI template for an operation.
        /// </summary>
        /// <param name="operationId">The unique ID of the operation exposed by the host.</param>
        /// <returns>A URI template for that operation.</returns>
        UriTemplate GetUriTemplateForOperation(string operationId);

        /// <summary>
        /// Match a request path to an operation path template.
        /// </summary>
        /// <param name="requestPath">The request path.</param>
        /// <param name="method">The HTTP method (e.g. get, post).</param>
        /// <param name="operationPathTemplate">The <see cref="OpenApiOperationPathTemplate"/>, or null if no match is found.</param>
        /// <returns>True if a match was found.</returns>
        bool GetOperationPathTemplate(string requestPath, string method, [NotNullWhen(true)] out OpenApiOperationPathTemplate? operationPathTemplate);
    }
}