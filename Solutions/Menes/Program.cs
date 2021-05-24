﻿// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#pragma warning disable

namespace Menes
{
    using System;
    using System.Buffers;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;
    using BlogSample;
    using Marain.LineOfBusiness;
    using Menes.Json;
    using Menes.Json.UriTemplates;
    using Menes.OpenApi;
    using RefDraft201909Feature.RootPointerRef;

    ////using UnevaluatedItemsDraft202012Feature.ItemIsEvaluatedInAnUncleSchemaToUnevaluatedItems;

    class Program
    {
        static async Task Main(string[] args)
        {
            UriTemplate uriTemplate = new UriTemplate("/{var}/{int}/{hello}{?double,boolean,path,list*,keys*}");
            uriTemplate = uriTemplate.SetParameters(
                ("var", "value"),
                ("int", 3),
                ("double", 3.3),
                ("boolean", true),
                ("hello", "Hello World!"),
                ("path", "/foo/bar"),
                ("list", JsonArray.From("red", "green", "blue")),
                ("keys", JsonObject.From(("semi", ";"), ("dot", "."), ("comma", ","))));

            Console.WriteLine(uriTemplate.Resolve());

            UriTemplate uriTemplate2 = new UriTemplate("/{var}/{int}/{hello}{?double,boolean,path,list*,keys*}");
            uriTemplate2 = uriTemplate.SetParameters(new {
                var = "value`",
                @int = 4,
                @double = 4.4,
                hello = "Goobye, cruel world!",
                path = "/baz/bat",
                list = new [] { "cyan", "magenta", "yellow" },
                keys = new { notsemi = "&", notdot = "!", notcomma = "_" },
            });

            Console.WriteLine(uriTemplate2.Resolve());

            JsonObject someObject = 
                JsonAny.From(new {
                    var = "value`",
                    @int = 4,
                    @double = 4.4,
                    hello = "Goobye, cruel world!",
                    path = "/baz/bat",
                    list = new[] { "cyan", "magenta", "yellow" },
                    keys =
                    new { 
                        notsemi = "&",
                        notdot = "!",
                        notcomma = "_"
                    },
                });

            ////Schema schema = JsonAny.Parse(@"{""foo"": {""bar"": false}}");

            ////var result = schema.Validate();

            PersonEntity person = JsonAny.Parse(@"{
  ""primaryName"": {
    ""firstName"": ""Jonathan"",
    ""lastName"": ""Small""
  }
    }
");

            AddressHistoryEntity addressHistory = JsonAny.Parse(@"{
  ""addressHistory"": [
    {
                ""line1"": ""32 Andaman Street"",
      ""townOrCity"": ""London"",
      ""postalCode"": ""SE1 3JS""
    },
    {
                ""line1"": ""Wisteria Lodge"",
      ""line2"": ""32, Norwood Street"",
      ""townOrCity"": ""London"",
      ""postalCode"": ""SE3 5JB""
    }
  ]
}");

            AddressHistoryEntity.AddressValue address = addressHistory.AddressHistory.EnumerateItems().FirstOrDefault();

            var personDetails = PersonDetailsEntity.Create(
                primaryName: person.PrimaryName.As<PersonDetailsEntity.PersonNameValue>(),
                address: address.IsNotNullOrUndefined() ?
                    PersonDetailsEntity.AddressValue.Create(
                        line1: address.Line1,
                        line2: address.Line2.AsOptional(),
                        line3: address.TownOrCity.AsOptional(),
                        line4: address.Region.AsOptional(),
                        postalCode: address.PostalCode.AsOptional()) : null);


            System.Console.WriteLine(personDetails.AsJsonElement.GetRawText());

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