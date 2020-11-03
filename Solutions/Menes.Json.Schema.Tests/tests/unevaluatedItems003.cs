// <copyright file="unevaluatedItems003.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.UnevaluatedItems003
{
public readonly struct Schema : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Menes.JsonString>, System.Collections.IEnumerable, System.IEquatable<Schema>, System.IEquatable<Menes.JsonArray<Menes.JsonString>>
{
    public static readonly System.Func<System.Text.Json.JsonElement, Schema> FromJsonElement = e => new Schema(e);
    public static readonly Schema Null = new Schema(default(System.Text.Json.JsonElement));
    private readonly Menes.JsonArray<Menes.JsonString>? value;
    public Schema(Menes.JsonArray<Menes.JsonString> jsonArray)
    {
        if (jsonArray.HasJsonElement)
        {
            this.JsonElement = jsonArray.JsonElement;
            this.value = null;
        }
        else
        {
            this.value = jsonArray;
            this.JsonElement = default;
        }
    }
    public Schema(System.Text.Json.JsonElement jsonElement)
    {
        this.value = null;
        this.JsonElement = jsonElement;
    }
    public int Length
    {
        get
        {
            if (this.HasJsonElement)
            {
                return this.JsonElement.GetArrayLength();
            }
            if (this.value is Menes.JsonArray<Menes.JsonString> value)
            {
                return value.Length;
            }
            return 0;
        }
    }
    public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
    public Schema? AsOptional => this.IsNull ? default(Schema?) : this;
    public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
    public System.Text.Json.JsonElement JsonElement { get; }
    public static implicit operator Schema(Menes.JsonArray<Menes.JsonString> value)
    {
        return new Schema(value);
    }
    public static implicit operator Menes.JsonArray<Menes.JsonString>(Schema value)
    {
        if (value.value is Menes.JsonArray<Menes.JsonString> clrValue)
        {
            return clrValue;
        }
        return new Menes.JsonArray<Menes.JsonString>(value.JsonElement);
    }
    public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
    {
        return Menes.JsonArray<Menes.JsonString>.IsConvertibleFrom(jsonElement);
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
    public bool Equals(Schema other)
    {
        return this.Equals((Menes.JsonArray<Menes.JsonString>)other);
    }
    public bool Equals(Menes.JsonArray<Menes.JsonString> other)
    {
        return ((Menes.JsonArray<Menes.JsonString>)this).Equals(other);
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        Menes.JsonArray<Menes.JsonString> array = this;
        Menes.ValidationContext context = validationContext;
        var newContext = array.Validate(context.ResetLastWasValid());
        if (!newContext.LastWasValid)
        {
            return newContext;
        }
        return array.ValidateItems(context);
    }
    public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
    {
        if (this.HasJsonElement)
        {
            this.JsonElement.WriteTo(writer);
        }
        if (this.value is Menes.JsonArray<Menes.JsonString> clrValue)
        {
            clrValue.WriteTo(writer);
        }
    }
    public Menes.JsonArray<Menes.JsonString>.JsonArrayEnumerator GetEnumerator()
    {
        return ((Menes.JsonArray<Menes.JsonString>)this).GetEnumerator();
    }
    System.Collections.Generic.IEnumerator<Menes.JsonString> System.Collections.Generic.IEnumerable<Menes.JsonString>.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    public Schema Add(params Menes.JsonString[] items)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
        foreach (Menes.JsonString item in this)
        {
            arrayBuilder.Add(item);
        }
        foreach (Menes.JsonString item in items)
        {
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Add(in Menes.JsonString item1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
        foreach (Menes.JsonString item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Add(in Menes.JsonString item1, in Menes.JsonString item2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
        foreach (Menes.JsonString item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Add(in Menes.JsonString item1, in Menes.JsonString item2, in Menes.JsonString item3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
        foreach (Menes.JsonString item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        arrayBuilder.Add(item3);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Add(in Menes.JsonString item1, in Menes.JsonString item2, in Menes.JsonString item3, in Menes.JsonString item4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
        foreach (Menes.JsonString item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        arrayBuilder.Add(item3);
        arrayBuilder.Add(item4);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Insert(int indexToInsert, params Menes.JsonString[] items)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
        int index = 0;
        foreach (Menes.JsonString item in this)
        {
            if (index == indexToInsert)
            {
                foreach (Menes.JsonString itemToInsert in items)
                {
                    arrayBuilder.Add(itemToInsert);
                }
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Insert(int indexToInsert, in Menes.JsonString item1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
        int index = 0;
        foreach (Menes.JsonString item in this)
        {
            if (index == indexToInsert)
            {
                arrayBuilder.Add(item1);
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Insert(int indexToInsert, in Menes.JsonString item1, in Menes.JsonString item2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
        int index = 0;
        foreach (Menes.JsonString item in this)
        {
            if (index == indexToInsert)
            {
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Insert(int indexToInsert, in Menes.JsonString item1, in Menes.JsonString item2, in Menes.JsonString item3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
        int index = 0;
        foreach (Menes.JsonString item in this)
        {
            if (index == indexToInsert)
            {
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                arrayBuilder.Add(item3);
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Insert(int indexToInsert, in Menes.JsonString item1, in Menes.JsonString item2, in Menes.JsonString item3, in Menes.JsonString item4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
        int index = 0;
        foreach (Menes.JsonString item in this)
        {
            if (index == indexToInsert)
            {
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                arrayBuilder.Add(item3);
                arrayBuilder.Add(item4);
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Remove(params Menes.JsonString[] items)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
        foreach (Menes.JsonString item in this)
        {
            bool found = false;
            foreach (Menes.JsonString itemToRemove in items)
            {
                if (itemToRemove.Equals(item))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                arrayBuilder.Add(item);
            }
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Remove(Menes.JsonString item1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
        foreach (Menes.JsonString item in this)
        {
            if (item1.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Remove(Menes.JsonString item1, Menes.JsonString item2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
        foreach (Menes.JsonString item in this)
        {
            if (item1.Equals(item) || item2.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Remove(Menes.JsonString item1, Menes.JsonString item2, Menes.JsonString item3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
        foreach (Menes.JsonString item in this)
        {
            if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Remove(Menes.JsonString item1, Menes.JsonString item2, Menes.JsonString item3, Menes.JsonString item4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
        foreach (Menes.JsonString item in this)
        {
            if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item) || item4.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema RemoveAt(int indexToRemove)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
        int index = 0;
        foreach (Menes.JsonString item in this)
        {
            if (index == indexToRemove)
            {
                index++;
                continue;
            }
            arrayBuilder.Add(item);
            index++;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema RemoveRange(int startIndex, int length)
    {
        if (startIndex < 0 || startIndex > this.Length - 1)
        {
            throw new System.ArgumentOutOfRangeException(nameof(startIndex));
        }
        if (length < 1 || startIndex + length > this.Length - 1)
        {
            throw new System.ArgumentOutOfRangeException(nameof(length));
        }
        System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
        int index = 0;
        foreach (Menes.JsonString item in this)
        {
            if (index >= startIndex && index < startIndex + length)
            {
                index++;
                continue;
            }
            arrayBuilder.Add(item);
            index++;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Remove(System.Predicate<Menes.JsonString> removeIfTrue)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
        foreach (Menes.JsonString item in this)
        {
            if (removeIfTrue(item))
            {
                continue;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
}
///  <summary>
/// unevaluatedItems with uniform items
/// </summary>
public static class Tests
{
/// <summary>
/// unevaluatedItems doesn't apply
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[\"foo\", \"bar\"]");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UnevaluatedItems003.Tests.Test0: unevaluatedItems doesn't apply");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
}
}