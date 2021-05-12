// <copyright file="Operation.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.OpenApi.SchemaModel
{
    using System.Collections.Immutable;

    /// <summary>
    /// An Open API operation for generation.
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Operation"/> class.
        /// </summary>
        /// <param name="dotnetTypeName">The dotnet name for the operation.</param>
        /// <param name="requestBodyMediaTypes">The request body media types.</param>
        /// <param name="responses">The operation response.</param>
        /// <param name="parameters">The operation parameters.</param>
        public Operation(string dotnetTypeName, ImmutableArray<RequestBodyMediaType>? requestBodyMediaTypes, ImmutableArray<Response>? responses, ImmutableArray<Parameter>? parameters)
        {
            this.DotnetTypeName = dotnetTypeName;
            this.RequestBodyMediaTypes = requestBodyMediaTypes ?? default;
            this.Responses = responses ?? default;
            this.Parameters = parameters;
        }

        /// <summary>
        /// Gets a value indicating whether this operation has a request body parameter.
        /// </summary>
        public bool HasRequestBodyParameter => !this.RequestBodyMediaTypes.IsDefault;

        /// <summary>
        /// Gets a value indicating whether this operation has multiple request body media types.
        /// </summary>
        public bool HasMultipleRequestBodyMediaTypes => this.RequestBodyMediaTypes.Length > 1;

        /// <summary>
        /// Gets the dotnet name for the operation.
        /// </summary>
        public string DotnetTypeName { get; }

        /// <summary>
        /// Gets a value indicating whether this operation has responses.
        /// </summary>
        public bool HasResponses => !this.Responses.IsDefault;

        /// <summary>
        /// Gets the request body media types.
        /// </summary>
        public ImmutableArray<RequestBodyMediaType> RequestBodyMediaTypes { get; }

        /// <summary>
        /// Gets the responses for the operation.
        /// </summary>
        public ImmutableArray<Response> Responses { get; }

        /// <summary>
        /// Gets the parameters for the operation.
        /// </summary>
        public ImmutableArray<Parameter>? Parameters { get; }
    }
}
