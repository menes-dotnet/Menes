// <copyright file="IOpenApiHostConfiguration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    /// <summary>
    /// Provides the means to configure the OpenApi service host.
    /// </summary>
    public interface IOpenApiHostConfiguration
    {
        /// <summary>
        /// Gets the document provider.
        /// </summary>
        IOpenApiDocuments Documents { get; }

        /// <summary>
        /// Gets the exception mapper.
        /// </summary>
        IOpenApiExceptionMap Exceptions { get; }

        /// <summary>
        /// Gets the operation link mapper.
        /// </summary>
        IOpenApiLinkOperationMap Links { get; }
    }
}