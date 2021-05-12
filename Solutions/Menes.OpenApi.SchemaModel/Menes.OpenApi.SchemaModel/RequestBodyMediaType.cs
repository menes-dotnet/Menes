// <copyright file="RequestBodyMediaType.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.OpenApi.SchemaModel
{
    /// <summary>
    /// A media type declaration in a request body.
    /// </summary>
    public class RequestBodyMediaType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestBodyMediaType"/> class.
        /// </summary>
        /// <param name="dotnetName">The pascal-cased dotnet name for this media type.</param>
        /// <param name="requestBodyFullyQualifiedDotnetTypeName">The fully-qualified dotnet type name for the request body type.</param>
        public RequestBodyMediaType(string dotnetName, string requestBodyFullyQualifiedDotnetTypeName)
        {
            this.DotnetName = dotnetName;
            this.RequestBodyFullyQualifiedDotnetTypeName = requestBodyFullyQualifiedDotnetTypeName;
        }

        /// <summary>
        /// Gets the pascal-cased dotnet name for this request body media type.
        /// </summary>
        public string DotnetName { get; }

        /// <summary>
        /// Gets the fully qualified dotnet type name for the request body type corresponding
        /// to this media type.
        /// </summary>
        public string RequestBodyFullyQualifiedDotnetTypeName { get; }
    }
}
