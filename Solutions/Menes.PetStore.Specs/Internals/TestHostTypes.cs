// <copyright file="TestHostTypes.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.PetStore.Specs.Internals
{
    /// <summary>
    /// Host types for which test suites may be executed.
    /// </summary>
    /// <remarks>
    /// Menes supports two modes of ASP.NET Core hosting, and we want to run certain sets of tests
    /// against each of these. This enumeration type is used to determine which mode a suite is
    /// being executed for.
    /// </remarks>
    public enum TestHostTypes
    {
        EmulateFunctionWithActionResult,
        AspNetDirectPipeline,
    }
}