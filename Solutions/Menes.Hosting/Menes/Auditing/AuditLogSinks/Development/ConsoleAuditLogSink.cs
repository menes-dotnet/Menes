// <copyright file="ConsoleAuditLogSink.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Auditing.AuditLogSinks.Development
{
    using System;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>
    /// Audit service that writes messages via <see cref="Console.WriteLine(string)"/>.
    /// </summary>
    public class ConsoleAuditLogSink : IAuditLogSink
    {
        private readonly IOpenApiConfiguration openApiConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleAuditLogSink"/> class.
        /// </summary>
        /// <param name="openApiConfiguration">The OpenApi configuration.</param>
        public ConsoleAuditLogSink(IOpenApiConfiguration openApiConfiguration)
        {
            this.openApiConfiguration = openApiConfiguration;
        }

        /// <inheritdoc />
        public Task LogAsync(AuditLog log)
        {
            string data = JsonConvert.SerializeObject(log, Formatting.Indented, this.openApiConfiguration.SerializerSettings);
            Console.WriteLine(data);
            return Task.CompletedTask;
        }
    }
}
