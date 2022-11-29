// <copyright file="OutputBuilderNotFoundException.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.OpenApi.Models;

    /// <inheritdoc/>
    public class OutputBuilderNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputBuilderNotFoundException"/> class.
        /// </summary>
        /// <param name="result">The result being processed.</param>
        /// <param name="operation">The operation being executed.</param>
        public OutputBuilderNotFoundException(object result, OpenApiOperation operation)
            : base(BuildMessage(result, operation))
        {
            this.RawResult = result;
            this.OpenApiResult = result as OpenApiResult;
            this.Operation = operation;
        }

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

        private static string BuildMessage(object result, OpenApiOperation operation)
        {
            var sb = new StringBuilder();
            bool appendComma = false;
            sb.Append("Expecting a response with a status code of: ");

            foreach (KeyValuePair<string, OpenApiResponse> response in operation.Responses)
            {
                if (appendComma)
                {
                    sb.Append(", ");
                }

                sb.Append(response.Key);
                if (!string.IsNullOrWhiteSpace(response.Value.Description))
                {
                    sb.Append(" - ");
                    sb.Append(response.Value.Description);
                }

                appendComma = true;
            }

            sb.Append('.');

            if (result is OpenApiResult oaiResult)
            {
                sb.AppendLine();
                sb.Append("Received a response with a status code of: ");
                sb.Append(oaiResult.StatusCode);
                sb.Append('.');

                sb.AppendLine();

                if (oaiResult.Results.Count == 0)
                {
                    sb.Append("There were no content result media types provided.");
                }
                else
                {
                    sb.Append("The following content result media types were provided: ");
                    appendComma = false;
                    foreach (string item in oaiResult.Results.Keys)
                    {
                        if (appendComma)
                        {
                            sb.Append(", ");
                        }

                        appendComma = true;
                        sb.Append(item);
                    }
                }

                sb.AppendLine();

                sb.Append("One of the following content result media types was expected: ");
                sb.AppendLine();
                foreach (KeyValuePair<string, OpenApiResponse> item in operation.Responses)
                {
                    sb.Append(item.Key);
                    sb.Append(": ");

                    if (item.Value.Content.Count == 0)
                    {
                        sb.Append("No content.");
                        continue;
                    }

                    appendComma = false;

                    foreach (string mediaType in item.Value.Content.Keys)
                    {
                        if (appendComma)
                        {
                            sb.Append(", ");
                        }

                        sb.Append(mediaType);
                        appendComma = true;
                    }

                    sb.AppendLine();
                }
            }
            else
            {
                sb.AppendLine();
                sb.Append("Received a response with a type of ");
                sb.Append(result.GetType());
            }

            sb.AppendLine();
            sb.Append("Check that your service implementation return value matches the OpenAPI OperationResponse definition.");
            return sb.ToString();
        }
    }
}