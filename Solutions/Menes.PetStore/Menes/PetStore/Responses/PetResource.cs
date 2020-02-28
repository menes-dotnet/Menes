// <copyright file="PetResource.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.PetStore.Responses
{
    using System;

    /// <summary>
    /// Pet DTO.
    /// </summary>
    public class PetResource
    {
        /// <summary>
        /// Base content type for all pets.
        /// </summary>
        public const string ContentTypeBase = "application/vnd.menes.petstore.pet";

        /// <summary>
        /// Initializes a new instance of the <see cref="PetResource"/> class.
        /// </summary>
        /// <param name="name">The <see cref="Name"/>.</param>
        /// <param name="tag">The <see cref="Tag"/>.</param>
        public PetResource(
            string name,
            string tag)
        {
            this.Name = name;
            this.Tag = tag;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets globally unique ID for the pet.
        /// </summary>
        public Guid GlobalIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// Gets or sets the size of the pet.
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// Gets the content type of this pet.
        /// </summary>
        public string ContentType => $"{ContentTypeBase}.{this.Tag.ToLowerInvariant()}";
    }
}