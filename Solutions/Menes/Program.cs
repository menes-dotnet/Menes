// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#pragma warning disable

namespace Menes
{
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Marain.LineOfBusiness;
    using Menes.Json;
    using Menes.OpenApi;
    using RefDraft201909Feature.RootPointerRef;

    ////using UnevaluatedItemsDraft202012Feature.ItemIsEvaluatedInAnUncleSchemaToUnevaluatedItems;

    class Program
    {
        static async Task Main(string[] args)
        {

            Schema schema = JsonAny.Parse(@"{""foo"": {""bar"": false}}");

            var result = schema.Validate();

            PersonResource personResource = PersonResource.Create(
                links: PersonResource.LinksValue.Create(
                    self: Link.Create("https://endjin.com/person/bar"),
                    primaryName: Link.Create("https://endjin.com/names/foo")),
                embedded: PersonResource.EmbeddedValue.Create(
                    primaryName: PersonNameResource.Create(
                        links: LinksProperty.Create(
                            self: Link.Create("https://endjin.com/names/foo")),
                        familyName: "Silver",
                        givenName: "John",
                        otherNames: JsonArray.Empty)));

            PersonResource personResource2 = PersonResource.Create(
                links: PersonResource.LinksValue.Create(
                    self: Link.Create("https://endjin.com/person/bat"),
                    primaryName: Link.Create("https://endjin.com/names/baz")),
                embedded: PersonResource.EmbeddedValue.Create(
                    primaryName: PersonNameResource.Create(
                        links: LinksProperty.Create(
                            self: Link.Create("https://endjin.com/names/baz")),
                        familyName: "Pugwash",
                        givenName: "Arthur",
                        otherNames: JsonArray.From("Willam", "Henry"))));

            var personListResource = PersonListResource.Create(
                links: PagedListResource.LinksValue.Create(
                    items: LinkArray.From(personResource.Links.Self, personResource2.Links.Self),
                    self: Link.Create("https://endjin.com/people"),
                    next: Link.Create("https://endjin.com/people?continuationToken=2342fsjdvbawe==")),
                embedded: PersonListResource.EmbeddedValue.Create(
                    items: PersonListResource.PersonResourceArray.From(personResource, personResource2)));
        }
    }
}
