// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#pragma warning disable

namespace Menes
{
    using System.Text.Json;
    using DefsFeature.ValidDefinition;
    using Menes.Json;
    using static DefsFeature.ValidDefinition.Validation;

    class Program
    {
        static void Main(string[] args)
        {
            var data = JsonAny.Parse(@"{
                    ""$id"": ""http://localhost:1234/root"",
                    ""$ref"": ""http://localhost:1234/nested.json#/$defs/B"",
                    ""$defs"": {
                ""A"": {
                    ""$id"": ""nested.json"",
                            ""$defs"": {
                        ""B"": {
                            ""$id"": ""#"",
                                    ""type"": ""integer""
                                }
                    }
                }
            }
        }");
            Schema schema = data.As<Schema>();
            var validated = schema.Validate();

            schema = schema.WithAdditionalItems(true);

            schema = schema.WithType(SimpleTypesEntity.EnumValues.Array);
        }
    }
}
