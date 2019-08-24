// <copyright file="Pet.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.PetStore.Abstractions
{
    using System;

    /// <summary>
    /// Pet DTO.
    /// </summary>
    public class Pet
    {
        /// <summary>
        /// Base content type for all pets.
        /// </summary>
        public const string ContentTypeBase = "application/vnd.menes.petstore.pet";

        /// <summary>
        /// Initializes a new instance of the <see cref="Pet"/> class.
        /// </summary>
        public Pet()
        {
            this.GlobalIdentifier = Guid.NewGuid();
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