// <copyright file="id001.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.Id001
{
///  <summary>
/// Valid use of empty fragments in location-independent $id
/// </summary>
public static class Tests
{
/// <summary>
/// Identifier name with absolute URI
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"$ref\": \"http://localhost:1234/bar\",\r\n                    \"$defs\": {\r\n                        \"A\": {\r\n                            \"$id\": \"http://localhost:1234/bar#\",\r\n                            \"type\": \"integer\"\r\n                        }\r\n                    }\r\n                }");
        var schema = new Menes.JsonAny(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Id001.Tests.Test0: Identifier name with absolute URI");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// Identifier name with base URI change in subschema
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"$id\": \"http://localhost:1234/root\",\r\n                    \"$ref\": \"http://localhost:1234/nested.json#/$defs/B\",\r\n                    \"$defs\": {\r\n                        \"A\": {\r\n                            \"$id\": \"nested.json\",\r\n                            \"$defs\": {\r\n                                \"B\": {\r\n                                    \"$id\": \"#\",\r\n                                    \"type\": \"integer\"\r\n                                }\r\n                            }\r\n                        }\r\n                    }\r\n                }");
        var schema = new Menes.JsonAny(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Id001.Tests.Test1: Identifier name with base URI change in subschema");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
}
}