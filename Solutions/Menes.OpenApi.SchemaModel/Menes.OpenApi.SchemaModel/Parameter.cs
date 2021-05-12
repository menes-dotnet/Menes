// <copyright file="Parameter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.OpenApi.SchemaModel
{
    /// <summary>
    /// A parameter for an operation.
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class.
        /// </summary>
        /// <param name="parameterValue">The parameter value for the operation.</param>
        /// <param name="location">The absolute location in the source document of the parameter value.</param>
        public Parameter(Document.ParameterValue parameterValue, string location)
        {
            this.ParameterValue = parameterValue;
            this.Location = location;
        }

        /// <summary>
        /// Gets the parameter value for the operation.
        /// </summary>
        public Document.ParameterValue ParameterValue { get; }

        /// <summary>
        /// Gets the location for the parameter value (for reference resolution).
        /// </summary>
        public string Location { get; }
    }
}
