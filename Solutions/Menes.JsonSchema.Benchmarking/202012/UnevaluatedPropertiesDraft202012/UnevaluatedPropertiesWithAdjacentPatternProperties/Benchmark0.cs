// <copyright file="Benchmark0.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace UnevaluatedPropertiesDraft202012Feature.UnevaluatedPropertiesWithAdjacentPatternProperties
{
    using System.Threading.Tasks;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using Menes.JsonSchema.Benchmarking.Benchmarks;
    /// <summary>
    /// Additional properties benchmark.
    /// </summary>
    [MemoryDiagnoser]
    public class Benchmark0 : BenchmarkBase
    {
        /// <summary>
        /// Global setup.
        /// </summary>
        /// <returns>A <see cref="Task"/> which completes once setup is complete.</returns>
        [GlobalSetup]
        public Task GlobalSetup()
        {
            return this.GlobalSetup("draft2020-12\\unevaluatedProperties.json", "#/4/schema", "#/004/tests/000/data", true);
        }
        /// <summary>
        /// Validates using the Menes types.
        /// </summary>
        [Benchmark]
        public void ValidateMenes()
        {
            this.ValidateMenesCore<UnevaluatedPropertiesDraft202012Feature.UnevaluatedPropertiesWithAdjacentPatternProperties.Schema>();
        }
        /// <summary>
        /// Validates using the Newtonsoft types.
        /// </summary>
        [Benchmark]
        public void ValidateNewtonsoft()
        {
            this.ValidateNewtonsoftCore();
        }
    }
}