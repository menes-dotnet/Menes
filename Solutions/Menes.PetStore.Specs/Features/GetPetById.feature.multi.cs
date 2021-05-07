// <copyright file="GetPetById.feature.multi.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.PetStore.Specs.Features
{
    using Menes.PetStore.Specs.Internals;

    using NUnit.Framework;

    /// <summary>
    /// Adds in multi-form execution.
    /// </summary>
    [TestFixtureSource(nameof(FixtureArgs))]
    public partial class GetPetByIdFeature : MultiTestHostBase
    {
        /// <summary>
        /// Creates a <see cref="GetPetByIdFeature"/>.
        /// </summary>
        /// <param name="hostType">
        /// Hosting style to test for.
        /// </param>
        public GetPetByIdFeature(TestHostTypes hostType)
            : base(hostType)
        {
        }
    }
}