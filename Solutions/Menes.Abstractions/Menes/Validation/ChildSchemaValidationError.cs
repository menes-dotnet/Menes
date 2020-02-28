//-----------------------------------------------------------------------
// <copyright file="ChildSchemaValidationError.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// <license>https://github.com/rsuter/NJsonSchema/blob/master/LICENSE.md</license>
// <author>Derived from code (c) Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

namespace Menes.Validation
{
    using System.Collections.Generic;
    using Microsoft.OpenApi.Models;
    using Newtonsoft.Json.Linq;

    /// <summary>A subschema validation error. </summary>
    public class ChildSchemaValidationError : ValidationError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChildSchemaValidationError"/> class.</summary>
        /// <param name="kind">The error kind. </param>
        /// <param name="propertyName">The property name. </param>
        /// <param name="path">The property path. </param>
        /// <param name="errors">The error list. </param>
        /// <param name="token">The token that failed to validate. </param>
        /// <param name="schema">The schema that contains the validation rule.</param>
        public ChildSchemaValidationError(ValidationErrorKind kind, string? propertyName, string path, IReadOnlyDictionary<OpenApiSchema, ICollection<ValidationError>> errors, JToken token, OpenApiSchema schema)
            : base(kind, propertyName, path, token, schema)
        {
            this.Errors = errors;
        }

        /// <summary>Gets the errors for each validated subschema.</summary>
        public IReadOnlyDictionary<OpenApiSchema, ICollection<ValidationError>> Errors { get; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>2.</filterpriority>
        public override string ToString()
        {
            string output = $"{this.Kind}: {this.Path}\n";

            foreach (KeyValuePair<OpenApiSchema, ICollection<ValidationError>> error in this.Errors)
            {
                output += "{\n";

                foreach (ValidationError validationError in error.Value)
                {
                    output += $"  {validationError.ToString().Replace("\n", "\n  ")}\n";
                }

                output += "}\n";
            }

            return output;
        }
    }
}