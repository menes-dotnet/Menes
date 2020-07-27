// <copyright file="StubPetStoreService.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.PetStore.Specs.Stubs
{
    using System;
    using Menes.Hal;
    using Menes.PetStore.Responses;
    using Menes.PetStore.Responses.Mappers;

    public class StubPetStoreService : IOpenApiService
    {
        private readonly PetResourceMapper petResourceMapper;

        public StubPetStoreService(PetResourceMapper petResourceMapper)
        {
            // Note that this is a dependency provided by the DI container for the service, not the specs.
            this.petResourceMapper = petResourceMapper;
        }

        [OperationId("listPets")]
        public OpenApiResult ListPets(int limit = 10, string? continuationToken = null)
        {
            return this.NotImplementedResult();
        }

        [OperationId("showPetById")]
        public OpenApiResult ShowPet(string petId)
        {
            var pet = new PetResource($"stub{petId}", "stub")
            {
                Id = long.Parse(petId),
                GlobalIdentifier = Guid.Empty,
                Size = Size.Small,
            };

            HalDocument response = this.petResourceMapper.Map(pet);
            return this.OkResult(response, "application/hal+json");
        }

        [OperationId("showPetByLongId")]
        public OpenApiResult ShowPet(
            [OpenApiParameter("petId")] long petIdWithParameterNameSetByAttribute)
        {
            return this.NotImplementedResult();
        }

        [OperationId("showPetByLongIdInHeader")]
        public OpenApiResult ShowPetWithIdInHeader(
            long xPetId)
        {
            return this.NotImplementedResult();
        }

        [OperationId("showPetByGlobalId")]
        public OpenApiResult ShowPet(Guid petId)
        {
            return this.NotImplementedResult();
        }

        [OperationId("showSecretPet")]
        public OpenApiResult ShowSecretPet(IOpenApiContext openApiContext)
        {
            return this.NotImplementedResult();
        }

        [OperationId("createPets")]
        public OpenApiResult CreatePets(PetResource body)
        {
            return this.NotImplementedResult();
        }

        [OperationId("petImage")]
        public OpenApiResult ShowPetImage(string petId)
        {
            return this.NotImplementedResult();
        }

        [OperationId("petImagePoco")]
        public OpenApiResult ShowPetImagePoco(string petId)
        {
            return this.NotImplementedResult();
        }
    }
}
