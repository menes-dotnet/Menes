//-----------------------------------------------------------------------
// <copyright file="ValidationError.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// <license>https://github.com/rsuter/NJsonSchema/blob/master/LICENSE.md</license>
// <author>Derived from code (c) Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

namespace Menes.Validation
{
    using Microsoft.OpenApi.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;

    /// <summary>A validation error. </summary>
    public class ValidationError
    {
        /// <summary>Initializes a new instance of the <see cref="ValidationError"/> class. </summary>
        /// <param name="errorKind">The error kind. </param>
        /// <param name="propertyName">The property name, or null if the failure is at the root level.</param>
        /// <param name="propertyPath">The property path. </param>
        /// <param name="token">The token that failed to validate. </param>
        /// <param name="schema">The schema that contains the validation rule.</param>
        public ValidationError(ValidationErrorKind errorKind, string? propertyName, string propertyPath, JToken token, OpenApiSchema schema)
        {
            this.Kind = errorKind;
            this.Property = propertyName;
            this.Path = propertyPath != null ? "#/" + propertyPath : "#";

            var lineInfo = token as IJsonLineInfo;
            if (lineInfo?.HasLineInfo() == true)
            {
                this.HasLineInfo = true;
                this.LineNumber = lineInfo.LineNumber;
                this.LinePosition = lineInfo.LinePosition;
            }
            else
            {
                this.LineNumber = 0;
                this.LinePosition = 0;
            }

            this.Schema = schema;
        }

        /// <summary>Gets the error kind. </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ValidationErrorKind Kind { get; }

        /// <summary>Gets the property name. </summary>
        public string? Property { get; }

        /// <summary>Gets the property path. </summary>
        public string Path { get; }

        /// <summary>Gets a value indicating whether the error contains line information.</summary>
        public bool HasLineInfo { get; }

        /// <summary>Gets the line number the validation failed on. </summary>
        public int LineNumber { get; }

        /// <summary>Gets the line position the validation failed on. </summary>
        public int LinePosition { get; }

        /// <summary>Gets the schema element that contains the validation rule. </summary>
        public OpenApiSchema Schema { get; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>2.</filterpriority>
        public override string ToString()
        {
            return $"{this.Kind}: {this.Path}";
        }
    }
}