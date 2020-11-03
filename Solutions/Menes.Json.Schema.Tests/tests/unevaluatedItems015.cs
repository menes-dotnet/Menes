// <copyright file="unevaluatedItems015.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.UnevaluatedItems015
{
public readonly struct Schema : Menes.IJsonValue, System.IEquatable<Schema>
{
    public static readonly System.Func<System.Text.Json.JsonElement, Schema> FromJsonElement = e => new Schema(e);
    public static readonly Schema Null = new Schema(default(System.Text.Json.JsonElement));
    private readonly Menes.JsonAny? value;
    public Schema(Menes.JsonAny value)
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
    public Schema(System.Text.Json.JsonElement jsonElement)
    {
        this.value = null;
        this.JsonElement = jsonElement;
    }
    public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
    public Schema? AsOptional => this.IsNull ? default(Schema?) : this;
    public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
    public System.Text.Json.JsonElement JsonElement { get; }
    public static implicit operator Schema(Menes.JsonAny value)
    {
        return new Schema(value);
    }
    public static implicit operator Menes.JsonAny(Schema value)
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
        Menes.ValidationContext allOfValidationContext1 = Menes.ValidationContext.Root.WithPath(context.Path);
        Menes.ValidationContext allOfValidationContext2 = Menes.ValidationContext.Root.WithPath(context.Path);
        Schema.AllOfValidationItem1Value allOfValidationItem1ValueAllOfValue0 = Menes.JsonAny.From(value).As<Schema.AllOfValidationItem1Value>();
        allOfValidationContext1 = allOfValidationItem1ValueAllOfValue0.Validate(allOfValidationContext1);
        Menes.JsonAny jsonAnyAllOfValue1 = Menes.JsonAny.From(value).As<Menes.JsonAny>();
        allOfValidationContext2 = jsonAnyAllOfValue1.Validate(allOfValidationContext2);
        context = Menes.Validation.ValidateAllOf(context, allOfValidationContext1, allOfValidationContext2);
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
    public readonly struct AllOfValidationItem1Value : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.IEquatable<AllOfValidationItem1Value>, System.IEquatable<Menes.JsonArray<Menes.JsonAny>>
    {
        public static readonly System.Func<System.Text.Json.JsonElement, AllOfValidationItem1Value> FromJsonElement = e => new AllOfValidationItem1Value(e);
        public static readonly AllOfValidationItem1Value Null = new AllOfValidationItem1Value(default(System.Text.Json.JsonElement));
        private readonly Menes.JsonArray<Menes.JsonAny>? value;
        public AllOfValidationItem1Value(Menes.JsonArray<Menes.JsonAny> jsonArray)
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
        public AllOfValidationItem1Value(System.Text.Json.JsonElement jsonElement)
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
                if (this.value is Menes.JsonArray<Menes.JsonAny> value)
                {
                    return value.Length;
                }
                return 0;
            }
        }
        public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public AllOfValidationItem1Value? AsOptional => this.IsNull ? default(AllOfValidationItem1Value?) : this;
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static implicit operator AllOfValidationItem1Value(Menes.JsonArray<Menes.JsonAny> value)
        {
            return new AllOfValidationItem1Value(value);
        }
        public static implicit operator Menes.JsonArray<Menes.JsonAny>(AllOfValidationItem1Value value)
        {
            if (value.value is Menes.JsonArray<Menes.JsonAny> clrValue)
            {
                return clrValue;
            }
            return new Menes.JsonArray<Menes.JsonAny>(value.JsonElement);
        }
        public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
        {
            return Menes.JsonArray<Menes.JsonAny>.IsConvertibleFrom(jsonElement);
        }
        public static AllOfValidationItem1Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new AllOfValidationItem1Value(property)
                    : Null)
                : Null;
        public static AllOfValidationItem1Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new AllOfValidationItem1Value(property)
                    : Null)
                : Null;
        public static AllOfValidationItem1Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new AllOfValidationItem1Value(property)
                    : Null)
                : Null;
        public bool Equals(AllOfValidationItem1Value other)
        {
            return this.Equals((Menes.JsonArray<Menes.JsonAny>)other);
        }
        public bool Equals(Menes.JsonArray<Menes.JsonAny> other)
        {
            return ((Menes.JsonArray<Menes.JsonAny>)this).Equals(other);
        }
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
        {
            Menes.JsonArray<Menes.JsonAny> array = this;
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
            if (this.value is Menes.JsonArray<Menes.JsonAny> clrValue)
            {
                clrValue.WriteTo(writer);
            }
        }
        public Menes.JsonArray<Menes.JsonAny>.JsonArrayEnumerator GetEnumerator()
        {
            return ((Menes.JsonArray<Menes.JsonAny>)this).GetEnumerator();
        }
        System.Collections.Generic.IEnumerator<Menes.JsonAny> System.Collections.Generic.IEnumerable<Menes.JsonAny>.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public AllOfValidationItem1Value Add(params Menes.JsonAny[] items)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            foreach (Menes.JsonAny item in this)
            {
                arrayBuilder.Add(item);
            }
            foreach (Menes.JsonAny item in items)
            {
                arrayBuilder.Add(item);
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public AllOfValidationItem1Value Add(in Menes.JsonAny item1)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            foreach (Menes.JsonAny item in this)
            {
                arrayBuilder.Add(item);
            }
            arrayBuilder.Add(item1);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public AllOfValidationItem1Value Add(in Menes.JsonAny item1, in Menes.JsonAny item2)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            foreach (Menes.JsonAny item in this)
            {
                arrayBuilder.Add(item);
            }
            arrayBuilder.Add(item1);
            arrayBuilder.Add(item2);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public AllOfValidationItem1Value Add(in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            foreach (Menes.JsonAny item in this)
            {
                arrayBuilder.Add(item);
            }
            arrayBuilder.Add(item1);
            arrayBuilder.Add(item2);
            arrayBuilder.Add(item3);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public AllOfValidationItem1Value Add(in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3, in Menes.JsonAny item4)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            foreach (Menes.JsonAny item in this)
            {
                arrayBuilder.Add(item);
            }
            arrayBuilder.Add(item1);
            arrayBuilder.Add(item2);
            arrayBuilder.Add(item3);
            arrayBuilder.Add(item4);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public AllOfValidationItem1Value Insert(int indexToInsert, params Menes.JsonAny[] items)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            int index = 0;
            foreach (Menes.JsonAny item in this)
            {
                if (index == indexToInsert)
                {
                    foreach (Menes.JsonAny itemToInsert in items)
                    {
                        arrayBuilder.Add(itemToInsert);
                    }
                }
                arrayBuilder.Add(item);
                ++index;
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public AllOfValidationItem1Value Insert(int indexToInsert, in Menes.JsonAny item1)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            int index = 0;
            foreach (Menes.JsonAny item in this)
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
        public AllOfValidationItem1Value Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            int index = 0;
            foreach (Menes.JsonAny item in this)
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
        public AllOfValidationItem1Value Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            int index = 0;
            foreach (Menes.JsonAny item in this)
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
        public AllOfValidationItem1Value Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3, in Menes.JsonAny item4)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            int index = 0;
            foreach (Menes.JsonAny item in this)
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
        public AllOfValidationItem1Value Remove(params Menes.JsonAny[] items)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            foreach (Menes.JsonAny item in this)
            {
                bool found = false;
                foreach (Menes.JsonAny itemToRemove in items)
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
        public AllOfValidationItem1Value Remove(Menes.JsonAny item1)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            foreach (Menes.JsonAny item in this)
            {
                if (item1.Equals(item))
                {
                    break;
                }
                arrayBuilder.Add(item);
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public AllOfValidationItem1Value Remove(Menes.JsonAny item1, Menes.JsonAny item2)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            foreach (Menes.JsonAny item in this)
            {
                if (item1.Equals(item) || item2.Equals(item))
                {
                    break;
                }
                arrayBuilder.Add(item);
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public AllOfValidationItem1Value Remove(Menes.JsonAny item1, Menes.JsonAny item2, Menes.JsonAny item3)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            foreach (Menes.JsonAny item in this)
            {
                if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))
                {
                    break;
                }
                arrayBuilder.Add(item);
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public AllOfValidationItem1Value Remove(Menes.JsonAny item1, Menes.JsonAny item2, Menes.JsonAny item3, Menes.JsonAny item4)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            foreach (Menes.JsonAny item in this)
            {
                if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item) || item4.Equals(item))
                {
                    break;
                }
                arrayBuilder.Add(item);
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public AllOfValidationItem1Value RemoveAt(int indexToRemove)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            int index = 0;
            foreach (Menes.JsonAny item in this)
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
        public AllOfValidationItem1Value RemoveRange(int startIndex, int length)
        {
            if (startIndex < 0 || startIndex > this.Length - 1)
            {
                throw new System.ArgumentOutOfRangeException(nameof(startIndex));
            }
            if (length < 1 || startIndex + length > this.Length - 1)
            {
                throw new System.ArgumentOutOfRangeException(nameof(length));
            }
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            int index = 0;
            foreach (Menes.JsonAny item in this)
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
        public AllOfValidationItem1Value Remove(System.Predicate<Menes.JsonAny> removeIfTrue)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            foreach (Menes.JsonAny item in this)
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
}
///  <summary>
/// unevaluatedItems can't see inside cousins
/// </summary>
public static class Tests
{
/// <summary>
/// always fails
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[ 1 ]");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed UnevaluatedItems015.Tests.Test0: always fails");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
}
}