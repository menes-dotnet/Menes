// <copyright file="additionalProperties001.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.AdditionalProperties001
{
public readonly struct Schema : Menes.IJsonObject, System.IEquatable<Schema>
{
    public static readonly Schema Null = new Schema(default(System.Text.Json.JsonElement));
    public static readonly System.Func<System.Text.Json.JsonElement, Schema> FromJsonElement = e => new Schema(e);
    private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>>.Empty;
    private static readonly System.Text.RegularExpressions.Regex PatternPropertyRegex0 = new System.Text.RegularExpressions.Regex("^á", System.Text.RegularExpressions.RegexOptions.Compiled);
    public Schema(System.Text.Json.JsonElement jsonElement)
    {
        this.JsonElement = jsonElement;
    }
    public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
    public Schema? AsOptional => this.IsNull ? default(Schema?) : this;
    public int PropertiesCount => KnownProperties.Length;
    public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
    public System.Text.Json.JsonElement JsonElement { get; }
    public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
    {
        return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
    }
    public static Schema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new Schema(property)
                : Null)
            : Null;
    public static Schema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new Schema(property)
                : Null)
            : Null;
    public static Schema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                ? new Schema(property)
                : Null)
        : Null;
    public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
    {
        if (this.HasJsonElement)
        {
            this.JsonElement.WriteTo(writer);
        }
        else
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
    }
    public bool Equals(Schema other)
    {
        if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
        {
            return false;
        }
        if (this.HasJsonElement && other.HasJsonElement)
        {
            return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
        }
        return true;
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        if (this.IsNull)
        {
            return validationContext.WithError($"6.1.1. type: the element with type {{this.JsonElement.ValueKind}} is not convertible to {{JsonValueKind.Object}}");
        }
        Menes.ValidationContext context = validationContext;
        System.Collections.Generic.HashSet<string> matchedProperties = new System.Collections.Generic.HashSet<string>(this.PropertiesCount);
        if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
        {
            int propCount = 0;
            int targetPropCount = KnownProperties.Length;
            var additionalPropertyEnumerator = this.JsonElement.EnumerateObject();
            while (additionalPropertyEnumerator.MoveNext())
            {
                var patternContext = this.ValidatePatternProperty(Menes.ValidationContext.Root, additionalPropertyEnumerator.Current.Name, Menes.JsonAny.FromJsonElement(additionalPropertyEnumerator.Current.Value), "." + additionalPropertyEnumerator.Current.Name);
                if (patternContext.LastWasValid)
                {
                    continue;
                }
                propCount++;
                if (propCount > targetPropCount)
                {
                    context = context.WithError("core 9.3.2.3. No additional properties were expected.");
                    break;
                }
            }
        }
        return context;
    }
    public override string ToString()
    {
        return Menes.JsonAny.From(this).ToString();
    }
    private Menes.ValidationContext ValidatePatternProperty<TItem>(in Menes.ValidationContext validationContext, string propertyName, in TItem value, string propertyPathToAppend)
       where TItem : struct, IJsonValue
    {
        var anyValue = Menes.JsonAny.From(value);
        if (PatternPropertyRegex0.IsMatch(propertyName) && anyValue.As<Menes.JsonAny>().Validate(Menes.ValidationContext.Root).IsValid)
        {
            return validationContext;
        }
        return validationContext.WithError("core 9.3.2.2. patternProperties: Unable to match any of the provided patternProperties.");
    }
}///  <summary>
/// non-ASCII pattern with additionalProperties
/// </summary>
public static class Tests
{
/// <summary>
/// matching the pattern is valid
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"ármányos\": 2}");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed AdditionalProperties001.Tests.Test0: matching the pattern is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// not matching the pattern is invalid
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"élmény\": 2}");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed AdditionalProperties001.Tests.Test1: not matching the pattern is invalid");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
}
}