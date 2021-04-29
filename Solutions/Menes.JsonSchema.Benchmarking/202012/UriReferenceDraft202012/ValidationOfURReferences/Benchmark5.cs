// <copyright file="Benchmark5.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace UriReferenceDraft202012Feature.ValidationOfURReferences
{
    using System.Threading.Tasks;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using Menes.JsonSchema.Benchmarking.Benchmarks;
    /// <summary>
    /// Additional properties benchmark.
    /// </summary>
    [MemoryDiagnoser]
    public class Benchmark5 : BenchmarkBase
    {
        /// <summary>
        /// Global setup.
        /// </summary>
        /// <returns>A <see cref="Task"/> which completes once setup is complete.</returns>
        [GlobalSetup]
        public Task GlobalSetup()
        {
            return this.GlobalSetup("draft2020-12\\uri-reference.json", "#/0/schema", "#/000/tests/005/data", true);
        }
        /// <summary>
        /// Validates using the Menes types.
        /// </summary>
        [Benchmark]
        public void ValidateMenes()
        {
            this.ValidateMenesCore<UriReferenceDraft202012Feature.ValidationOfURReferences.Schema>();
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
