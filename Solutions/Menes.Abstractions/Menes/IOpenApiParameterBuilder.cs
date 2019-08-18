// <copyright file="IOpenApiParameterBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// An interface implemented by types that can build a set of named parameter values for an Open Api request
    /// from the Open API operation specification and an incoming request.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    public interface IOpenApiParameterBuilder<TRequest>
    {
        /// <summary>
        /// Build the named parameters for an operation.
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <param name="operationPathTemplate">The matching operation.</param>
        /// <returns>A Task which completes with a dictionary of names to parameter values.</returns>
        Task<IDictionary<string, object>> BuildParametersAsync(TRequest request, OpenApiOperationPathTemplate operationPathTemplate);
    }
}