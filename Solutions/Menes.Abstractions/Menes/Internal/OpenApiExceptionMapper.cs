// <copyright file="OpenApiExceptionMapper.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Menes.ExceptionMappers;
    using Menes.Exceptions;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;

    /// <summary>
    ///     The open api exception mapper.
    /// </summary>
    public class OpenApiExceptionMapper : IOpenApiExceptionMapper
    {
        private readonly ICollection<OpenApiMappedException> exceptionMappings;

        private readonly Lazy<IEnumerable<IExceptionMapper>> exceptionMappers;
        private readonly ILogger<OpenApiExceptionMapper> logger;

        /// <summary>
        ///     Initializes a new instance of the <see cref="OpenApiExceptionMapper" /> class.
        /// </summary>
        /// <param name="serviceProvider">The <see cref="IServiceProvider"/> for the context.</param>
        /// <param name="logger">
        ///     Target for diagnostic messages.
        /// </param>
        public OpenApiExceptionMapper(IServiceProvider serviceProvider, ILogger<OpenApiExceptionMapper> logger)
        {
            this.exceptionMappings = new List<OpenApiMappedException>();
            this.exceptionMappers = new Lazy<IEnumerable<IExceptionMapper>>(() => serviceProvider.GetServices<IExceptionMapper>().OrderBy(b => b.Priority).ToList());
            this.logger = logger;
        }

        /// <inheritdoc />
        public void Map<TException>(int statusCode, string operationId = null)
            where TException : Exception
        {
            Type type = typeof(TException);

            this.ValidateStatusCode(statusCode);
            this.ValidateMappingDoesNotExist(type, operationId);
            this.exceptionMappings.Add(new OpenApiMappedException
            {
                ExceptionType = type,
                FormatterType = null,
                OperationId = operationId,
                StatusCode = statusCode,
            });
        }

        /// <inheritdoc cref="Map{TException}" />
        public void Map<TException, TFormatter>(int statusCode, string operationId = null)
            where TException : Exception
            where TFormatter : IExceptionMapper
        {
            Type type = typeof(TException);

            this.ValidateStatusCode(statusCode);
            this.ValidateMappingDoesNotExist(type, operationId);
            this.exceptionMappings.Add(new OpenApiMappedException
            {
                ExceptionType = type,
                FormatterType = typeof(TFormatter),
                OperationId = operationId,
                StatusCode = statusCode,
            });
        }

        /// <inheritdoc/>
        public OpenApiResult GetResponse(Exception exception, OpenApiOperation operation)
        {
            Type exceptionType = exception.GetType();
            OpenApiMappedException mappedException = this.GetMappedException(operation, exceptionType);

            IExceptionMapper mapper = this.GetExceptionMapperFor(mappedException, exception, operation);
            if (mapper == null)
            {
                string operationId = operation.GetOperationId();
                this.logger.LogError(
                    "Unmapped exception thrown by [{operationId}]: [{exception}]",
                    operationId,
                    exception);
                throw new OpenApiServiceMismatchException($"Operation {operationId} has thrown an exception of type {exception.GetType().FullName}. You should either handle this in your service, or add an exception mapping defining which status code this exception corresponds to.");
            }

            return mapper.MapException(operation.Responses, exception, mappedException?.StatusCode);
        }

        private OpenApiMappedException GetMappedException(OpenApiOperation operation, Type exceptionType)
        {
            return this.exceptionMappings.FirstOrDefault(x => x.ExceptionType == exceptionType && x.OperationId == operation.OperationId) ??
                   this.exceptionMappings.FirstOrDefault(x => x.ExceptionType == exceptionType && string.IsNullOrEmpty(x.OperationId));
        }

        private void ValidateMappingDoesNotExist(Type exceptionType, string operationId)
        {
            if (this.exceptionMappings.Any(x => x.ExceptionType == exceptionType && x.OperationId == operationId))
            {
                throw new ArgumentException($"Exception type {exceptionType.FullName} has already been mapped for operation Id {operationId ?? "*"}. You can only map each exception type once.");
            }
        }

        private IExceptionMapper GetExceptionMapperFor(OpenApiMappedException mappedException, Exception ex, OpenApiOperation operation)
        {
            if (mappedException?.FormatterType != null)
            {
                return this.exceptionMappers.Value.FirstOrDefault(x => x.GetType() == mappedException.FormatterType);
            }

            return this.exceptionMappers.Value.FirstOrDefault(x => x.CanMapException(operation.Responses, ex, mappedException?.StatusCode));
        }

        private void ValidateStatusCode(int statusCode)
        {
            if (statusCode < 100 || statusCode >= 600)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(statusCode),
                    $"The specified status code {statusCode} is outside the range of potentially valid codes");
            }

            if (statusCode == 500)
            {
                throw new ArgumentException(
                    nameof(statusCode),
                    $"Do not explicitly map exceptions to the 500 status code.");
            }
        }
    }
}