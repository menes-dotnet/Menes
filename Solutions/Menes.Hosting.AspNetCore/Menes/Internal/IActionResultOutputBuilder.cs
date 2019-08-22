// <copyright file="IActionResultOutputBuilder.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

namespace Endjin.OpenApi.Internal
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Interface implemented by types that are used to build <see cref="IActionResult"/> based output.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This can be used by any host that implements the AspNetCore 2.x model, such as
    /// Functions V2 and AspNetCore itself.
    /// </para>
    /// </remarks>
    public interface IActionResultOutputBuilder
    {
        /// <summary>
        /// Gets the priority of the output builder.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The candidate output builders will be executed in priority order, lowest to highest.
        /// </para>
        /// </remarks>
        int Priority { get; }

        /// <summary>
        /// Indicates whether the builder can build a result for the given operation and result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="operation">The operation.</param>
        /// <returns>True if the builder can handle the operation and result.</returns>
        bool CanBuildOutput(object result, OpenApiOperation operation);

        /// <summary>
        /// Build the result for the operation.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="operation">The operation.</param>
        /// <returns>The <see cref="IActionResult"/> constructed from the operation and result.</returns>
        IActionResult BuildOutput(object result, OpenApiOperation operation);
    }
}