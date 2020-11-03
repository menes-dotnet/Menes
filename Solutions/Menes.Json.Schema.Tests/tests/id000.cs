// <copyright file="id000.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.Id000
{
///  <summary>
/// Invalid use of fragments in location-independent $id
/// </summary>
public static class Tests
{
/// <summary>
/// Identifier name
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"$ref\": \"#foo\",\r\n                    \"$defs\": {\r\n                        \"A\": {\r\n                            \"$id\": \"#foo\",\r\n                            \"type\": \"integer\"\r\n                        }\r\n                    }\r\n                }");
        var schema = new Menes.JsonAny(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Id000.Tests.Test0: Identifier name");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// Identifier name and no ref
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"$defs\": {\r\n                        \"A\": { \"$id\": \"#foo\" }\r\n                    }\r\n                }");
        var schema = new Menes.JsonAny(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Id000.Tests.Test1: Identifier name and no ref");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// Identifier path
/// </summary>
    public static bool Test2()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"$ref\": \"#/a/b\",\r\n                    \"$defs\": {\r\n                        \"A\": {\r\n                            \"$id\": \"#/a/b\",\r\n                            \"type\": \"integer\"\r\n                        }\r\n                    }\r\n                }");
        var schema = new Menes.JsonAny(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Id000.Tests.Test2: Identifier path");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// Identifier name with absolute URI
/// </summary>
    public static bool Test3()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"$ref\": \"http://localhost:1234/bar#foo\",\r\n                    \"$defs\": {\r\n                        \"A\": {\r\n                            \"$id\": \"http://localhost:1234/bar#foo\",\r\n                            \"type\": \"integer\"\r\n                        }\r\n                    }\r\n                }");
        var schema = new Menes.JsonAny(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Id000.Tests.Test3: Identifier name with absolute URI");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// Identifier path with absolute URI
/// </summary>
    public static bool Test4()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"$ref\": \"http://localhost:1234/bar#/a/b\",\r\n                    \"$defs\": {\r\n                        \"A\": {\r\n                            \"$id\": \"http://localhost:1234/bar#/a/b\",\r\n                            \"type\": \"integer\"\r\n                        }\r\n                    }\r\n                }");
        var schema = new Menes.JsonAny(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Id000.Tests.Test4: Identifier path with absolute URI");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// Identifier name with base URI change in subschema
/// </summary>
    public static bool Test5()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"$id\": \"http://localhost:1234/root\",\r\n                    \"$ref\": \"http://localhost:1234/nested.json#foo\",\r\n                    \"$defs\": {\r\n                        \"A\": {\r\n                            \"$id\": \"nested.json\",\r\n                            \"$defs\": {\r\n                                \"B\": {\r\n                                    \"$id\": \"#foo\",\r\n                                    \"type\": \"integer\"\r\n                                }\r\n                            }\r\n                        }\r\n                    }\r\n                }");
        var schema = new Menes.JsonAny(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Id000.Tests.Test5: Identifier name with base URI change in subschema");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// Identifier path with base URI change in subschema
/// </summary>
    public static bool Test6()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"$id\": \"http://localhost:1234/root\",\r\n                    \"$ref\": \"http://localhost:1234/nested.json#/a/b\",\r\n                    \"$defs\": {\r\n                        \"A\": {\r\n                            \"$id\": \"nested.json\",\r\n                            \"$defs\": {\r\n                                \"B\": {\r\n                                    \"$id\": \"#/a/b\",\r\n                                    \"type\": \"integer\"\r\n                                }\r\n                            }\r\n                        }\r\n                    }\r\n                }");
        var schema = new Menes.JsonAny(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Id000.Tests.Test6: Identifier path with base URI change in subschema");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
}
}