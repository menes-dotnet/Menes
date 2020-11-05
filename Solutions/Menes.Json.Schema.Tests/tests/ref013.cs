// <copyright file="ref013.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.Ref013
{
///  <summary>
/// ref creates new scope when adjacent to keywords
/// </summary>
public static class Tests
{
/// <summary>
/// referenced subschema doesn't see annotations from properties
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"prop1\": \"match\"\r\n                }");
        var schema = new Menes.JsonAny(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Ref013.Tests.Test0: referenced subschema doesn't see annotations from properties");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
}
}