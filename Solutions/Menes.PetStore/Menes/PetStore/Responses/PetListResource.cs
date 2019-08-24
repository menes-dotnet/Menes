// <copyright file="PetListResource.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.PetStore.Responses
{
    using Menes.Links;
    using Menes.PetStore.Abstractions;
    using Newtonsoft.Json;

    /// <summary>
    /// Wire representation of a list of pets.
    /// </summary>
    public class PetListResource : HalDocument
    {
        private const string PetsKey = "pets";

        /// <summary>
        /// Initializes a new instance of the <see cref="PetListResource"/> class.
        /// </summary>
        public PetListResource()
        {
        }

        /// <summary>
        /// Gets the total number of available pets.
        /// </summary>
        public long TotalCount { get; internal set; }

        /// <summary>
        /// Gets the current page size.
        /// </summary>
        public int PageSize { get; internal set; }

        /// <summary>
        /// Gets or sets the list of pets.
        /// </summary>
        [JsonIgnore]
        public HalDocument<Pet>[] Pets
        {
            get
            {
                HalDocument<Pet>[] pets = this.GetEmbeddedResource<HalDocument<Pet>[]>(PetsKey);

                if (pets == null)
                {
                    pets = new HalDocument<Pet>[0];
                    this.SetEmbeddedResource(PetsKey, pets);
                }

                return pets;
            }

            set
            {
                this.SetEmbeddedResource(PetsKey, value);
            }
        }
    }
}
