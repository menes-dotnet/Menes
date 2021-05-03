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
        }
    }
}
