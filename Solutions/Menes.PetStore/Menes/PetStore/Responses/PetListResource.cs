// <copyright file="PetListResource.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.PetStore.Responses
{
    /// <summary>
    /// Wire representation of a list of pets.
    /// </summary>
    public class PetListResource
    {
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
    }
}
