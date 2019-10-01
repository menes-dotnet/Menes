// <copyright file="Pet.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps.TestClasses
{
    /// <summary>
    /// Pet DTO.
    /// </summary>
    public class Pet
    {
        /// <summary>
        /// Base content type for all pets.
        /// </summary>
        public const string ContentTypeBase = "menes/vnd.petstore.pet";

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// Gets the content type of this pet.
        /// </summary>
        public string ContentType => $"{ContentTypeBase}.{this.Tag.ToLowerInvariant()}";
    }
}