// <copyright file="Benchmark1.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace UnevaluatedPropertiesDraft201909Feature.NestedUnevaluatedPropertiesOuterTrueInnerFalsePropertiesOutside
{
    using System.Threading.Tasks;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using Menes.JsonSchema.Benchmarking.Benchmarks;
    /// <summary>
    /// Additional properties benchmark.
    /// </summary>
    [MemoryDiagnoser]
    public class Benchmark1 : BenchmarkBase
    {
        /// <summary>
        /// Global setup.
        /// </summary>
        /// <returns>A <see cref="Task"/> which completes once setup is complete.</returns>
        [GlobalSetup]
        public Task GlobalSetup()
        {
            return this.GlobalSetup("unevaluatedProperties.json", "#/20/schema", "#/020/tests/001/data", false);
        }
        /// <summary>
        /// Validates using the Menes types.
        /// </summary>
        [Benchmark]
        public void ValidateMenes()
        {
            this.ValidateMenesCore<UnevaluatedPropertiesDraft201909Feature.NestedUnevaluatedPropertiesOuterTrueInnerFalsePropertiesOutside.Schema>();
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
