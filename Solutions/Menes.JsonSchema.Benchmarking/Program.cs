// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.Benchmarking
{
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Jobs;
    using BenchmarkDotNet.Running;
    using Menes.JsonSchema.Benchmarking.Benchmarks;

    /// <summary>
    /// Main program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point.
        /// </summary>
        /// <param name="args">Arguments.</param>
        public static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).RunAllJoined(
                ManualConfig.Create(DefaultConfig.Instance)
                .AddJob(Job.Dry
                    .WithLaunchCount(1)
                    .WithWarmupCount(5)
                    .WithIterationCount(20)));
        }
    }
}
