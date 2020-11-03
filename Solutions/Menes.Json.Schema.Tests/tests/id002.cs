// <copyright file="id002.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.Id002
{
///  <summary>
/// Unnormalized $ids are allowed but discouraged
/// </summary>
public static class Tests
{
/// <summary>
/// Unnormalized identifier
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"$ref\": \"http://localhost:1234/foo/baz\",\r\n                    \"$defs\": {\r\n                        \"A\": {\r\n                            \"$id\": \"http://localhost:1234/foo/bar/../baz\",\r\n                            \"type\": \"integer\"\r\n                        }\r\n                    }\r\n                }");
        var schema = new Menes.JsonAny(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Id002.Tests.Test0: Unnormalized identifier");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// Unnormalized identifier and no ref
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"$defs\": {\r\n                        \"A\": {\r\n                            \"$id\": \"http://localhost:1234/foo/bar/../baz\",\r\n                            \"type\": \"integer\"\r\n                        }\r\n                    }\r\n                }");
        var schema = new Menes.JsonAny(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Id002.Tests.Test1: Unnormalized identifier and no ref");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// Unnormalized identifier with empty fragment
/// </summary>
    public static bool Test2()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"$ref\": \"http://localhost:1234/foo/baz\",\r\n                    \"$defs\": {\r\n                        \"A\": {\r\n                            \"$id\": \"http://localhost:1234/foo/bar/../baz#\",\r\n                            \"type\": \"integer\"\r\n                        }\r\n                    }\r\n                }");
        var schema = new Menes.JsonAny(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Id002.Tests.Test2: Unnormalized identifier with empty fragment");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// Unnormalized identifier with empty fragment and no ref
/// </summary>
    public static bool Test3()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"$defs\": {\r\n                        \"A\": {\r\n                            \"$id\": \"http://localhost:1234/foo/bar/../baz#\",\r\n                            \"type\": \"integer\"\r\n                        }\r\n                    }\r\n                }");
        var schema = new Menes.JsonAny(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Id002.Tests.Test3: Unnormalized identifier with empty fragment and no ref");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
}
}