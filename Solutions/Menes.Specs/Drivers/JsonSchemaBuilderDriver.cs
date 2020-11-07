// <copyright file="JsonSchemaBuilderDriver.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Drivers
{
    using Menes.JsonSchema.TypeBuilder;
    using NUnit.Framework;

    /// <summary>
    /// A driver for specs for the <see cref="JsonSchemaBuilder"/>.
    /// </summary>
    public class JsonSchemaBuilderDriver
    {
        private readonly JsonSchemaBuilder builder;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaBuilderDriver"/> class.
        /// </summary>
        /// <param name="builder">The <see cref="JsonSchemaBuilder"/> instance to drive.</param>
        public JsonSchemaBuilderDriver(JsonSchemaBuilder builder)
        {
            this.builder = builder;
        }

        /// <summary>
        /// A quick test.
        /// </summary>
        public void Ping()
        {
            Assert.Fail();
        }
    }
}
