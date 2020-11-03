// <copyright file="unevaluatedItems000.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.UnevaluatedItems000
{
///  <summary>
/// unevaluatedItems true
/// </summary>
public static class Tests
{
/// <summary>
/// with no unevaluated items
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[]");
        var schema = new Menes.JsonArray<Menes.JsonAny>(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UnevaluatedItems000.Tests.Test0: with no unevaluated items");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// with unevaluated items
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[\"foo\"]");
        var schema = new Menes.JsonArray<Menes.JsonAny>(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UnevaluatedItems000.Tests.Test1: with unevaluated items");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
}
}