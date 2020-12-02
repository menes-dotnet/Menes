// <copyright file="BenchmarkBase.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.Benchmarking.Benchmarks
{
    using System;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Drivers;
    using Menes.Json;
    using Menes.Json.Schema;
    using Menes.JsonSchema.TypeBuilder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Schema;

    /// <summary>
    /// Base class for validation benchmarks.
    /// </summary>
    public class BenchmarkBase
    {
        private IServiceProvider? serviceProvider;
        private JsonSchemaBuilderDriver? driver;
        private JSchema? newtonsoftSchema;
        private bool? isValid;
        private string? data;

        /// <summary>
        /// Setup the benchmark.
        /// </summary>
        /// <param name="filename">The filename for the benchmark data.</param>
        /// <param name="referenceFragment">The pointer to the schema in the reference file.</param>
        /// <param name="inputDataReference">The pointer to the data in the reference file.</param>
        /// <param name="isValid">Whether the item should be valid or not.</param>
        /// <returns>A <see cref="Task"/> which completes once setup is complete.</returns>
        protected async Task GlobalSetup(string filename, string referenceFragment, string inputDataReference, bool isValid)
        {
            this.serviceProvider = CreateServices().BuildServiceProvider();
            this.driver = this.serviceProvider.GetRequiredService<JsonSchemaBuilderDriver>();
            JsonElement? schema = await this.driver.GetElement(filename, referenceFragment).ConfigureAwait(false);
            if (schema is null)
            {
                throw new InvalidOperationException($"Unable to find the element in file '{filename}' at location '{referenceFragment}'");
            }

            IConfiguration configuration = this.serviceProvider.GetRequiredService<IConfiguration>();
            License.RegisterLicense(configuration["newtonsoft:licenseKey"]);

            JsonElement? data = await this.driver.GetElement(filename, inputDataReference).ConfigureAwait(false);
            if (data is not JsonElement d)
            {
                throw new InvalidOperationException($"Unable to find the element in file '{filename}' at location '{inputDataReference}'");
            }

            this.data = d.ToString();

            this.newtonsoftSchema = JSchema.Parse(schema.Value.ToString(), new JSchemaUrlResolver());
            this.isValid = isValid;
        }

        /// <summary>
        /// Validate using the Menes type.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="IJsonValue"/> to validate.</typeparam>
        protected void ValidateMenesCore<T>()
            where T : struct, IJsonValue
        {
            using var document = JsonDocument.Parse(this.data!);
            T value = document.RootElement.As<T>();

            if (value.Validate(ValidationContext.ValidContext).IsValid != this.isValid)
            {
                throw new InvalidOperationException("Unable to validate.");
            }
        }

        /// <summary>
        /// Validate using the Newtonsoft type.
        /// </summary>
        protected void ValidateNewtonsoftCore()
        {
            var newtonsoftJToken = JToken.Parse(this.data!);
            if (newtonsoftJToken.IsValid(this.newtonsoftSchema) != this.isValid)
            {
                throw new InvalidOperationException("Unable to validate.");
            }
        }

        private static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<IDocumentResolver>(serviceProvider => new CompoundDocumentResolver(new FakeWebDocumentResolver(serviceProvider.GetRequiredService<IConfiguration>()["jsonSchemaBuilderDriverSettings:remotesBaseDirectory"]), new FileSystemDocumentResolver(), new HttpClientDocumentResolver(new HttpClient())));
            services.AddTransient<JsonSchemaBuilder>();
            services.AddTransient<JsonSchemaBuilderDriver>();
            services.AddTransient<IConfiguration>(sp =>
            {
                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                configurationBuilder.AddJsonFile("appsettings.json", true);
                configurationBuilder.AddJsonFile("appsettings.local.json", true);
                return configurationBuilder.Build();
            });

            return services;
        }
    }
}
