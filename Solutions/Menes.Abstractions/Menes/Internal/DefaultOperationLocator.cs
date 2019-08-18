// <copyright file="DefaultOperationLocator.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// A default OpenAPI operation locator.
    /// </summary>
    public class DefaultOperationLocator : IOpenApiServiceOperationLocator
    {
        private readonly ILogger<DefaultOperationLocator> logger;
        private readonly IEnumerable<IOpenApiService> services;
        private readonly OpenApiConfiguration configuration;
        private readonly Lazy<IDictionary<string, OpenApiServiceOperation>> operations;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultOperationLocator"/> class.
        /// </summary>
        /// <param name="services">The registered Open API Service.</param>
        /// <param name="configuration">The Open API configuration.</param>
        /// <param name="logger">The logger.</param>
        public DefaultOperationLocator(IEnumerable<IOpenApiService> services, OpenApiConfiguration configuration, ILogger<DefaultOperationLocator> logger)
        {
            this.logger = logger;
            this.services = services;
            this.configuration = configuration;
            this.operations = new Lazy<IDictionary<string, OpenApiServiceOperation>>(() => this.LocateOperations());
        }

        /// <inheritdoc/>
        public bool TryGetOperation(string operationId, out OpenApiServiceOperation operation)
        {
            if (!this.operations.Value.TryGetValue(operationId, out operation))
            {
                // we didn't find an implementation of the operation
                this.logger.LogError(
                    "Failed to find [{match}] in service operations",
                    operationId);
                return false;
            }

            return true;
        }

        private IDictionary<string, OpenApiServiceOperation> LocateOperations()
        {
            var result = new Dictionary<string, OpenApiServiceOperation>();

            if (this.logger.IsEnabled(LogLevel.Trace))
            {
                this.logger.LogTrace("Locating operations in [{services}]", this.services);
            }

            foreach (IOpenApiService service in this.services)
            {
                var methods =
                    service.GetType().GetMethods()
                    .Where(m => m.IsPublic && !m.IsStatic && !m.IsAbstract).ToList();

                if (this.logger.IsEnabled(LogLevel.Trace))
                {
                    this.logger.LogTrace("Located methods [{methods}] in service [{service}]", methods, service.GetType());
                }

                foreach (MethodInfo method in methods)
                {
                    OperationIdAttribute attr = method.GetCustomAttributes(typeof(OperationIdAttribute), false).Cast<OperationIdAttribute>().SingleOrDefault();

                    if (attr == null)
                    {
                        continue;
                    }

                    result.Add(attr.OperationId, new OpenApiServiceOperation(service, method, this.configuration));
                }
            }

            return result;
        }
    }
}