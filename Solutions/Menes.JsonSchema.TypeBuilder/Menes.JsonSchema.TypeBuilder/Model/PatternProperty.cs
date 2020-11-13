// <copyright file="PatternProperty.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder.Model
{
    /// <summary>
    /// A pattern and schema against which to validate.
    /// </summary>
    public class PatternProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PatternProperty"/> class.
        /// </summary>
        /// <param name="pattern">The <see cref="Pattern"/>.</param>
        /// <param name="schema">The <see cref="Schema"/>.</param>
        public PatternProperty(string pattern, TypeDeclaration schema)
        {
            this.Pattern = pattern;
            this.Schema = schema;
        }

        /// <summary>
        /// Gets the regex pattern to match against the property names.
        /// </summary>
        public string Pattern { get; }

        /// <summary>
        /// Gets the schema against which properties matching the pattern must validate.
        /// </summary>
        public TypeDeclaration Schema { get; }
    }
}
