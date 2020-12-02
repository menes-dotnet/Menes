// <copyright file="Benchmark7.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace AllOfFeature.AllOfCombinedWithAnyOfOneOf
{
    using System.Threading.Tasks;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using Menes.JsonSchema.Benchmarking.Benchmarks;
    /// <summary>
    /// Additional properties benchmark.
    /// </summary>
    [MemoryDiagnoser]
    public class Benchmark7 : BenchmarkBase
    {
        /// <summary>
        /// Global setup.
        /// </summary>
        /// <returns>A <see cref="Task"/> which completes once setup is complete.</returns>
        [GlobalSetup]
        public Task GlobalSetup()
        {
            return this.GlobalSetup("allOf.json", "#/11/schema", "#/011/tests/007/data", true);
        }
        /// <summary>
        /// Validates using the Menes types.
        /// </summary>
        [Benchmark]
        public void ValidateMenes()
        {
            this.ValidateMenesCore<AllOfFeature.AllOfCombinedWithAnyOfOneOf.RootEntity>();
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
