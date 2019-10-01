// <copyright file="ServiceBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ServiceBuilder.Commands
{
    using System.Threading.Tasks;
    using McMaster.Extensions.CommandLineUtils;

    /// <summary>
    /// The claims setup application.
    /// </summary>
    [Command(FullName = "ServiceBuilder", Description = "Generate OpenAPI services", ThrowOnUnexpectedArgument = false, ShowInHelpText = true)]
    [HelpOption]
    [Subcommand(typeof(BuildCSharp))]
    [Subcommand(typeof(DiffCSharp))]
    public class ServiceBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBuilder"/> class.
        /// </summary>
        public ServiceBuilder()
        {
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Conventional form for command line application.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Code Quality", "IDE0051:Remove unused private members", Justification = "Conventional form for command line application.")]
        private Task<int> OnExecuteAsync(CommandLineApplication app, IConsole console)
        {
            app.ShowHelp();
            return Task.FromResult(1);
        }
    }
}
