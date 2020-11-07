// <copyright file="SpecDirectories.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.SpecGenerator
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Directories for spec generation.
    /// </summary>
    internal struct SpecDirectories
    {
        private SpecDirectories(string testsDirectory, string remotesDirectory, string outputDirectory)
        {
            this.TestsDirectory = testsDirectory;
            this.RemotesDirectory = remotesDirectory;
            this.OutputDirectory = outputDirectory;
        }

        /// <summary>
        /// Gets the directory contain the JSON schema specs.
        /// </summary>
        public string TestsDirectory { get; }

        /// <summary>
        /// Gets or sets  the direcotry containing the JSON schema remote files.
        /// </summary>
        public string RemotesDirectory { get; set; }

        /// <summary>
        /// Gets or sets  the output directory for the feature files.
        /// </summary>
        public string OutputDirectory { get; set; }

        /// <summary>
        /// Set up the directories from the program arguments.
        /// </summary>
        /// <param name="args">The program arguments.</param>
        /// <returns>The spec directories.</returns>
        public static SpecDirectories SetupDirectories(string[] args)
        {
            string inputDirectory = Environment.CurrentDirectory;
            if (args.Length > 0)
            {
                inputDirectory = Path.Combine(inputDirectory, args[0]);
            }

            string testsDirectory = Path.Combine(inputDirectory, "tests\\draft2019-09");
            string remotesDirectory = Path.Combine(inputDirectory, "remotes");

            if (!Directory.Exists(testsDirectory))
            {
                throw new InvalidOperationException($"Unable to find the tests directory: '{testsDirectory}'");
            }

            if (!Directory.Exists(remotesDirectory))
            {
                throw new InvalidOperationException($"Unable to find the remotes directory: '{remotesDirectory}'");
            }

            string outputDirectory = Environment.CurrentDirectory;
            if (args.Length > 1)
            {
                outputDirectory = Path.Combine(outputDirectory, args[1]);
            }

            try
            {
                Directory.CreateDirectory(outputDirectory);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Unable to create the output directory: '{outputDirectory}'", ex);
            }

            return new SpecDirectories(testsDirectory, remotesDirectory, outputDirectory);
        }

        /// <summary>
        /// Gets the output feature file for the given input file.
        /// </summary>
        /// <param name="file">The input file.</param>
        /// <returns>The output feature file name.</returns>
        public string GetOutputFeatureFileFor(string file)
        {
            return Path.Combine(this.OutputDirectory, Path.ChangeExtension(Path.GetFileName(file), ".feature"));
        }

        /// <summary>
        /// Enumerates the input test files.
        /// </summary>
        /// <returns>An enumerable of the input test files and their corresponding output feature files.</returns>
        public IEnumerable<(string inputFile, string outputFile)> EnumerateTests()
        {
            foreach (string inputFile in Directory.EnumerateFiles(this.TestsDirectory))
            {
                yield return (inputFile, this.GetOutputFeatureFileFor(inputFile));
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return obj is SpecDirectories other &&
                   this.TestsDirectory == other.TestsDirectory &&
                   this.RemotesDirectory == other.RemotesDirectory &&
                   this.OutputDirectory == other.OutputDirectory;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.TestsDirectory, this.RemotesDirectory, this.OutputDirectory);
        }
    }
}
