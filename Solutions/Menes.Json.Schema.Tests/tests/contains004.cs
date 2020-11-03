// <copyright file="contains004.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.Contains004
{
public readonly struct Schema : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Schema.SchemaValue>, System.Collections.IEnumerable, System.IEquatable<Schema>, System.IEquatable<Menes.JsonArray<Schema.SchemaValue>>
{
    public static readonly System.Func<System.Text.Json.JsonElement, Schema> FromJsonElement = e => new Schema(e);
    public static readonly Schema Null = new Schema(default(System.Text.Json.JsonElement));
    private readonly Menes.JsonArray<Schema.SchemaValue>? value;
    public Schema(Menes.JsonArray<Menes.JsonAny> jsonArray)
    {
        if (jsonArray.HasJsonElement)
        {
            this.JsonElement = jsonArray.JsonElement;
            this.value = null;
        }
        else
        {
            System.Collections.Immutable.ImmutableArray<Schema.SchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaValue>();
            foreach (Menes.JsonAny item in jsonArray)
            {
                arrayBuilder.Add(item);
            }
            this.value = Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            this.JsonElement = default;
        }
    }
    public Schema(Menes.JsonArray<Schema.SchemaValue> jsonArray)
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
            if (this.value is Menes.JsonArray<Schema.SchemaValue> value)
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
    public static implicit operator Schema(Menes.JsonArray<Menes.JsonAny> value)
    {
        return new Schema(value);
    }
    public static implicit operator Schema(Menes.JsonArray<Schema.SchemaValue> value)
    {
        return new Schema(value);
    }
    public static implicit operator Menes.JsonArray<Schema.SchemaValue>(Schema value)
    {
        if (value.value is Menes.JsonArray<Schema.SchemaValue> clrValue)
        {
            return clrValue;
        }
        return new Menes.JsonArray<Schema.SchemaValue>(value.JsonElement);
    }
    public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
    {
        return Menes.JsonArray<Schema.SchemaValue>.IsConvertibleFrom(jsonElement);
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
        return this.Equals((Menes.JsonArray<Schema.SchemaValue>)other);
    }
    public bool Equals(Menes.JsonArray<Schema.SchemaValue> other)
    {
        return ((Menes.JsonArray<Schema.SchemaValue>)this).Equals(other);
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        Menes.JsonArray<Schema.SchemaValue> array = this;
        Menes.ValidationContext context = validationContext;
        var newContext = array.Validate(context.ResetLastWasValid());
        if (!newContext.LastWasValid)
        {
            return newContext;
        }
        return array.ValidateRangeContains<Schema.SchemaValue>(context, 1, 2147483647, false, true);
    }
    public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
    {
        if (this.HasJsonElement)
        {
            this.JsonElement.WriteTo(writer);
        }
        if (this.value is Menes.JsonArray<Schema.SchemaValue> clrValue)
        {
            clrValue.WriteTo(writer);
        }
    }
    public Menes.JsonArray<Schema.SchemaValue>.JsonArrayEnumerator GetEnumerator()
    {
        return ((Menes.JsonArray<Schema.SchemaValue>)this).GetEnumerator();
    }
    System.Collections.Generic.IEnumerator<Schema.SchemaValue> System.Collections.Generic.IEnumerable<Schema.SchemaValue>.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    public Schema Add(params Schema.SchemaValue[] items)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaValue>();
        foreach (Schema.SchemaValue item in this)
        {
            arrayBuilder.Add(item);
        }
        foreach (Schema.SchemaValue item in items)
        {
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Add(in Schema.SchemaValue item1)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaValue>();
        foreach (Schema.SchemaValue item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Add(in Schema.SchemaValue item1, in Schema.SchemaValue item2)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaValue>();
        foreach (Schema.SchemaValue item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Add(in Schema.SchemaValue item1, in Schema.SchemaValue item2, in Schema.SchemaValue item3)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaValue>();
        foreach (Schema.SchemaValue item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        arrayBuilder.Add(item3);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Add(in Schema.SchemaValue item1, in Schema.SchemaValue item2, in Schema.SchemaValue item3, in Schema.SchemaValue item4)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaValue>();
        foreach (Schema.SchemaValue item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        arrayBuilder.Add(item3);
        arrayBuilder.Add(item4);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Insert(int indexToInsert, params Schema.SchemaValue[] items)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaValue>();
        int index = 0;
        foreach (Schema.SchemaValue item in this)
        {
            if (index == indexToInsert)
            {
                foreach (Schema.SchemaValue itemToInsert in items)
                {
                    arrayBuilder.Add(itemToInsert);
                }
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Insert(int indexToInsert, in Schema.SchemaValue item1)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaValue>();
        int index = 0;
        foreach (Schema.SchemaValue item in this)
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
    public Schema Insert(int indexToInsert, in Schema.SchemaValue item1, in Schema.SchemaValue item2)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaValue>();
        int index = 0;
        foreach (Schema.SchemaValue item in this)
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
    public Schema Insert(int indexToInsert, in Schema.SchemaValue item1, in Schema.SchemaValue item2, in Schema.SchemaValue item3)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaValue>();
        int index = 0;
        foreach (Schema.SchemaValue item in this)
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
    public Schema Insert(int indexToInsert, in Schema.SchemaValue item1, in Schema.SchemaValue item2, in Schema.SchemaValue item3, in Schema.SchemaValue item4)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaValue>();
        int index = 0;
        foreach (Schema.SchemaValue item in this)
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
    public Schema Remove(params Schema.SchemaValue[] items)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaValue>();
        foreach (Schema.SchemaValue item in this)
        {
            bool found = false;
            foreach (Schema.SchemaValue itemToRemove in items)
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
    public Schema Remove(Schema.SchemaValue item1)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaValue>();
        foreach (Schema.SchemaValue item in this)
        {
            if (item1.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Remove(Schema.SchemaValue item1, Schema.SchemaValue item2)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaValue>();
        foreach (Schema.SchemaValue item in this)
        {
            if (item1.Equals(item) || item2.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Remove(Schema.SchemaValue item1, Schema.SchemaValue item2, Schema.SchemaValue item3)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaValue>();
        foreach (Schema.SchemaValue item in this)
        {
            if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Remove(Schema.SchemaValue item1, Schema.SchemaValue item2, Schema.SchemaValue item3, Schema.SchemaValue item4)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaValue>();
        foreach (Schema.SchemaValue item in this)
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
        System.Collections.Immutable.ImmutableArray<Schema.SchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaValue>();
        int index = 0;
        foreach (Schema.SchemaValue item in this)
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
        System.Collections.Immutable.ImmutableArray<Schema.SchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaValue>();
        int index = 0;
        foreach (Schema.SchemaValue item in this)
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
    public Schema Remove(System.Predicate<Schema.SchemaValue> removeIfTrue)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaValue>();
        foreach (Schema.SchemaValue item in this)
        {
            if (removeIfTrue(item))
            {
                continue;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public readonly struct SchemaValue : Menes.IJsonValue, System.IEquatable<SchemaValue>
    {
        public static readonly System.Func<System.Text.Json.JsonElement, SchemaValue> FromJsonElement = e => new SchemaValue(e);
        public static readonly SchemaValue Null = new SchemaValue(default(System.Text.Json.JsonElement));
        private static readonly Menes.JsonNumber? MultipleOf = 3;
        private static readonly Menes.JsonNumber? Maximum = null;
        private static readonly Menes.JsonNumber? ExclusiveMaximum = null;
        private static readonly Menes.JsonNumber? Minimum = null;
        private static readonly Menes.JsonNumber? ExclusiveMinimum = null;
        private readonly Menes.JsonAny? value;
        public SchemaValue(Menes.JsonAny value)
        {
            if (value.HasJsonElement)
            {
                this.JsonElement = value.JsonElement;
                this.value = null;
            }
            else
            {
                this.value = value;
                this.JsonElement = default;
            }
        }
        public SchemaValue(System.Text.Json.JsonElement jsonElement)
        {
            this.value = null;
            this.JsonElement = jsonElement;
        }
        public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public SchemaValue? AsOptional => this.IsNull ? default(SchemaValue?) : this;
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static implicit operator SchemaValue(Menes.JsonAny value)
        {
            return new SchemaValue(value);
        }
        public static implicit operator Menes.JsonAny(SchemaValue value)
        {
            if (value.value is Menes.JsonAny clrValue)
            {
                return clrValue;
            }
            return new Menes.JsonAny(value.JsonElement);
        }
        public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
        {
            return Menes.JsonAny.IsConvertibleFrom(jsonElement);
        }
        public static SchemaValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new SchemaValue(property)
                    : Null)
                : Null;
        public static SchemaValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new SchemaValue(property)
                    : Null)
                : Null;
        public static SchemaValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new SchemaValue(property)
                    : Null)
                : Null;
        public bool Equals(SchemaValue other)
        {
            return this.Equals((Menes.JsonAny)other);
        }
        public bool Equals(Menes.JsonAny other)
        {
            return ((Menes.JsonAny)this).Equals(other);
        }
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
        {
            Menes.JsonAny value = this;
            Menes.ValidationContext context = validationContext;
            context = value.Validate(context);
            context = value.As<Menes.JsonNumber>().ValidateAsNumber(context, MultipleOf, Maximum, ExclusiveMaximum, Minimum, ExclusiveMinimum, null, null);
            return context;
        }
        public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
        {
            if (this.HasJsonElement)
            {
                this.JsonElement.WriteTo(writer);
            }
            else if (this.value is Menes.JsonAny clrValue)
            {
                clrValue.WriteTo(writer);
            }
        }
        public override string ToString()
        {
            if (this.value is Menes.JsonAny clrValue)
            {
                return clrValue.ToString();
            }
            else
            {
                return this.JsonElement.GetRawText();
            }
        }
    }
}
///  <summary>
/// items + contains
/// </summary>
public static class Tests
{
/// <summary>
/// matches items, does not match contains
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[ 2, 4, 8 ]");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Contains004.Tests.Test0: matches items, does not match contains");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// does not match items, matches contains
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[ 3, 6, 9 ]");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Contains004.Tests.Test1: does not match items, matches contains");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// matches both items and contains
/// </summary>
    public static bool Test2()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[ 6, 12 ]");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Contains004.Tests.Test2: matches both items and contains");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// matches neither items nor contains
/// </summary>
    public static bool Test3()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[ 1, 5 ]");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Contains004.Tests.Test3: matches neither items nor contains");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
}
}