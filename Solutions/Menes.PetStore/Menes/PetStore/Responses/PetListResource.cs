// <copyright file="PetListResource.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.PetStore.Responses
{
    using Newtonsoft.Json;

    /// <summary>
    /// Wire representation of a list of pets.
    /// </summary>
    public class PetListResource
    {
        /// <summary>
        /// Creates a <see cref="PetListResource"/>.
        /// </summary>
        /// <param name="pets">The <see cref="Pets"/>.</param>
        public PetListResource(PetResource[] pets)
        {
            this.Pets = pets;
        }

        /// <summary>
        /// The registered content type for the pet list resource.
        /// </summary>
        public const string RegisteredContentType = "application/vnd.menes.demo.petlistresource";

        /// <summary>
        /// Gets the total number of available pets.
        /// </summary>
        public long TotalCount { get; internal set; }

        /// <summary>
        /// Gets the current page size.
        /// </summary>
        public int PageSize { get; internal set; }

        /// <summary>
        /// Gets the pets in the pet resource.
        /// </summary>
        /// <remarks>These are serialized as embedded resources.</remarks>
        [JsonIgnore]
        public PetResource[] Pets { get; internal set; }

        /// <summary>
        /// Gets the current continuation token related to the resource.
        /// </summary>
        /// <remarks>The is serialized in the links.</remarks>
        [JsonIgnore]
        public string? CurrentContinuationToken { get; internal set; }

        /// <summary>
        /// Gets the current continuation token related to the resource.
        /// </summary>
        /// <remarks>The is serialized in the links.</remarks>
        [JsonIgnore]
        public string? NextContinuationToken { get; internal set; }
    }
}
