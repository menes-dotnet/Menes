// <copyright file="OutputBuilderNotFoundException.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.OpenApi.Exceptions;
    using Microsoft.OpenApi.Models;

    /// <inheritdoc/>
    public class OutputBuilderNotFoundException : OpenApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputBuilderNotFoundException"/> class.
        /// </summary>
        /// <param name="result">The result being processed.</param>
        /// <param name="operation">The operation being executed.</param>
        public OutputBuilderNotFoundException(object result, OpenApiOperation operation)
        {
            this.RawResult = result;
            this.Operation = operation;

            var sb = new StringBuilder();
            bool firstTime = true;
            sb.Append("Expecting a Response with a Status Code in the range of ");

            foreach (KeyValuePair<string, OpenApiResponse> response in operation.Responses)
            {
                if (!firstTime)
                {
                    sb.Append(", ");
                }

                sb.Append(" ");
                sb.Append(response.Key);
                sb.Append(" - ");
                sb.Append(response.Value.Description);
                sb.Append(" ");

                firstTime = false;
            }

            sb.Append(". Recieved a Response with Status Code of ");

            if (this.RawResult is OpenApiResult oaiResult)
            {
                this.OpenApiResult = oaiResult;

                sb.Append(oaiResult.StatusCode);
            }
            else
            {
                sb.Append(this.RawResult.GetType());
            }

            sb.Append(". Check that your Operation implementation return value matches the OpenAPI operation response definition.");

            this.Message = sb.ToString();
        }

        /// <inheritdoc cref="Message"/>
        public new string Message { get; }

        /// <summary>
        /// Gets the OpenApiResult.
        /// </summary>
        public OpenApiResult? OpenApiResult { get; }

        /// <summary>
        /// Gets the Operation.
        /// </summary>
        public OpenApiOperation Operation { get; }

        /// <summary>
        /// Gets the raw Result.
        /// </summary>
        public object RawResult { get; }
    }
}