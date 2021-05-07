// <copyright file="CreatePet.feature.multi.cs" company="Endjin Limited">
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
    public partial class CreatePetFeature : MultiTestHostBase
    {
        /// <summary>
        /// Creates a <see cref="CreatePetFeature"/>.
        /// </summary>
        /// <param name="hostType">
        /// Hosting style to test for.
        /// </param>
        public CreatePetFeature(TestHostTypes hostType)
            : base(hostType)
        {
        }
    }
}