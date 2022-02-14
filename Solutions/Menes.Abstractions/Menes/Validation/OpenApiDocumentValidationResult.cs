// <copyright file="OpenApiDocumentValidationResult.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Validation
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.OpenApi.Models;
    using Microsoft.OpenApi.Validations;

    /// <summary>
    /// Describes the results of attempting to validate an <see cref="OpenApiDocument"/>.
    /// </summary>
    public class OpenApiDocumentValidationResult
    {
        /// <summary>
        /// Creates a <see cref="OpenApiDocumentValidationResult"/>.
        /// </summary>
        /// <param name="errors">The <see cref="Errors"/>.</param>
        public OpenApiDocumentValidationResult(IEnumerable<OpenApiValidatorError> errors)
        {
            this.Errors = errors.ToList();
        }

        /// <summary>
        /// Gets a value indicating whether any problems were found in the document.
        /// </summary>
        public bool IsValid => this.Errors.Count == 0;

        /// <summary>
        /// Gets a list describing problems found with the <see cref="OpenApiDocument"/>.
        /// in the document.
        /// </summary>
        public List<OpenApiValidatorError> Errors { get; }
    }
}