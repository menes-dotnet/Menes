// <copyright file="DependentSchema.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder.Model
{
    /// <summary>
    /// A pattern and schema against which to validate.
    /// </summary>
    public class DependentSchema
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DependentSchema"/> class.
        /// </summary>
        /// <param name="propertyName">The <see cref="PropertyName"/>.</param>
        /// <param name="schema">The <see cref="Schema"/>.</param>
        public DependentSchema(string propertyName, TypeDeclaration schema)
        {
            this.PropertyName = propertyName;
            this.Schema = schema;
        }

        /// <summary>
        /// Gets the property name.
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// Gets the schema against which the entire object must validate if it contains a property matching the <see cref="PropertyName"/>.
        /// </summary>
        public TypeDeclaration Schema { get; }
    }
}
