// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ServiceBuilder
{
    using System.Threading.Tasks;
    using McMaster.Extensions.CommandLineUtils;
    using Menes.ServiceBuilder.Commands;

    /// <summary>
    /// Program entry point.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">Program arguments.</param>
        private static Task Main(string[] args)
        {
            return CommandLineApplication.ExecuteAsync<ServiceBuilder>(args);
        }
    }
}
