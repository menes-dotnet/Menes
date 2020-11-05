// <copyright file="contains004.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.Contains004
{
public readonly struct TestSchema : Menes.IJsonValue, System.Collections.Generic.IEnumerable<TestSchema.TestSchemaValue>, System.Collections.IEnumerable, System.IEquatable<TestSchema>, System.IEquatable<Menes.JsonArray<TestSchema.TestSchemaValue>>
{
    public static readonly System.Func<System.Text.Json.JsonElement, TestSchema> FromJsonElement = e => new TestSchema(e);
    public static readonly TestSchema Null = new TestSchema(default(System.Text.Json.JsonElement));
    private readonly Menes.JsonArray<TestSchema.TestSchemaValue>? value;
    public TestSchema(Menes.JsonArray<Menes.JsonAny> jsonArray)
    {
        if (jsonArray.HasJsonElement)
        {
            this.JsonElement = jsonArray.JsonElement;
            this.value = null;
        }
        else
        {
            System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaValue>();
            foreach (Menes.JsonAny item in jsonArray)
            {
                arrayBuilder.Add(item);
            }
            this.value = Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            this.JsonElement = default;
        }
    }
    public TestSchema(Menes.JsonArray<TestSchema.TestSchemaValue> jsonArray)
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
    public TestSchema(System.Text.Json.JsonElement jsonElement)
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
            if (this.value is Menes.JsonArray<TestSchema.TestSchemaValue> value)
            {
                return value.Length;
            }
            return 0;
        }
    }
    public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
    public TestSchema? AsOptional => this.IsNull ? default(TestSchema?) : this;
    public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
    public System.Text.Json.JsonElement JsonElement { get; }
    public static implicit operator TestSchema(Menes.JsonArray<Menes.JsonAny> value)
    {
        return new TestSchema(value);
    }
    public static implicit operator TestSchema(Menes.JsonArray<TestSchema.TestSchemaValue> value)
    {
        return new TestSchema(value);
    }
    public static implicit operator Menes.JsonArray<TestSchema.TestSchemaValue>(TestSchema value)
    {
        if (value.value is Menes.JsonArray<TestSchema.TestSchemaValue> clrValue)
        {
            return clrValue;
        }
        return new Menes.JsonArray<TestSchema.TestSchemaValue>(value.JsonElement);
    }
    public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
    {
        return Menes.JsonArray<TestSchema.TestSchemaValue>.IsConvertibleFrom(jsonElement);
    }
    public static TestSchema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new TestSchema(property)
                : Null)
            : Null;
    public static TestSchema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new TestSchema(property)
                : Null)
            : Null;
    public static TestSchema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                ? new TestSchema(property)
                : Null)
            : Null;
    public bool Equals(TestSchema other)
    {
        return this.Equals((Menes.JsonArray<TestSchema.TestSchemaValue>)other);
    }
    public bool Equals(Menes.JsonArray<TestSchema.TestSchemaValue> other)
    {
        return ((Menes.JsonArray<TestSchema.TestSchemaValue>)this).Equals(other);
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        Menes.JsonArray<TestSchema.TestSchemaValue> array = this;
        Menes.ValidationContext context = validationContext;
        if (!this.HasJsonElement || IsConvertibleFrom(this.JsonElement))
        {
            context = array.ValidateRangeContains<TestSchema.ContainsValidationValue>(context, 1, 2147483647, false, true);
        }
        return context;
    }
    public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
    {
        if (this.HasJsonElement)
        {
            this.JsonElement.WriteTo(writer);
        }
        if (this.value is Menes.JsonArray<TestSchema.TestSchemaValue> clrValue)
        {
            clrValue.WriteTo(writer);
        }
    }
    public Menes.JsonArray<TestSchema.TestSchemaValue>.JsonArrayEnumerator GetEnumerator()
    {
        return ((Menes.JsonArray<TestSchema.TestSchemaValue>)this).GetEnumerator();
    }
    System.Collections.Generic.IEnumerator<TestSchema.TestSchemaValue> System.Collections.Generic.IEnumerable<TestSchema.TestSchemaValue>.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    public TestSchema Add(params TestSchema.TestSchemaValue[] items)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaValue>();
        foreach (TestSchema.TestSchemaValue item in this)
        {
            arrayBuilder.Add(item);
        }
        foreach (TestSchema.TestSchemaValue item in items)
        {
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Add(in TestSchema.TestSchemaValue item1)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaValue>();
        foreach (TestSchema.TestSchemaValue item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Add(in TestSchema.TestSchemaValue item1, in TestSchema.TestSchemaValue item2)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaValue>();
        foreach (TestSchema.TestSchemaValue item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Add(in TestSchema.TestSchemaValue item1, in TestSchema.TestSchemaValue item2, in TestSchema.TestSchemaValue item3)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaValue>();
        foreach (TestSchema.TestSchemaValue item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        arrayBuilder.Add(item3);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Add(in TestSchema.TestSchemaValue item1, in TestSchema.TestSchemaValue item2, in TestSchema.TestSchemaValue item3, in TestSchema.TestSchemaValue item4)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaValue>();
        foreach (TestSchema.TestSchemaValue item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        arrayBuilder.Add(item3);
        arrayBuilder.Add(item4);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Insert(int indexToInsert, params TestSchema.TestSchemaValue[] items)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaValue>();
        int index = 0;
        foreach (TestSchema.TestSchemaValue item in this)
        {
            if (index == indexToInsert)
            {
                foreach (TestSchema.TestSchemaValue itemToInsert in items)
                {
                    arrayBuilder.Add(itemToInsert);
                }
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Insert(int indexToInsert, in TestSchema.TestSchemaValue item1)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaValue>();
        int index = 0;
        foreach (TestSchema.TestSchemaValue item in this)
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
    public TestSchema Insert(int indexToInsert, in TestSchema.TestSchemaValue item1, in TestSchema.TestSchemaValue item2)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaValue>();
        int index = 0;
        foreach (TestSchema.TestSchemaValue item in this)
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
    public TestSchema Insert(int indexToInsert, in TestSchema.TestSchemaValue item1, in TestSchema.TestSchemaValue item2, in TestSchema.TestSchemaValue item3)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaValue>();
        int index = 0;
        foreach (TestSchema.TestSchemaValue item in this)
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
    public TestSchema Insert(int indexToInsert, in TestSchema.TestSchemaValue item1, in TestSchema.TestSchemaValue item2, in TestSchema.TestSchemaValue item3, in TestSchema.TestSchemaValue item4)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaValue>();
        int index = 0;
        foreach (TestSchema.TestSchemaValue item in this)
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
    public TestSchema Remove(params TestSchema.TestSchemaValue[] items)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaValue>();
        foreach (TestSchema.TestSchemaValue item in this)
        {
            bool found = false;
            foreach (TestSchema.TestSchemaValue itemToRemove in items)
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
    public TestSchema Remove(TestSchema.TestSchemaValue item1)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaValue>();
        foreach (TestSchema.TestSchemaValue item in this)
        {
            if (item1.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Remove(TestSchema.TestSchemaValue item1, TestSchema.TestSchemaValue item2)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaValue>();
        foreach (TestSchema.TestSchemaValue item in this)
        {
            if (item1.Equals(item) || item2.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Remove(TestSchema.TestSchemaValue item1, TestSchema.TestSchemaValue item2, TestSchema.TestSchemaValue item3)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaValue>();
        foreach (TestSchema.TestSchemaValue item in this)
        {
            if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Remove(TestSchema.TestSchemaValue item1, TestSchema.TestSchemaValue item2, TestSchema.TestSchemaValue item3, TestSchema.TestSchemaValue item4)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaValue>();
        foreach (TestSchema.TestSchemaValue item in this)
        {
            if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item) || item4.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema RemoveAt(int indexToRemove)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaValue>();
        int index = 0;
        foreach (TestSchema.TestSchemaValue item in this)
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
    public TestSchema RemoveRange(int startIndex, int length)
    {
        if (startIndex < 0 || startIndex > this.Length - 1)
        {
            throw new System.ArgumentOutOfRangeException(nameof(startIndex));
        }
        if (length < 1 || startIndex + length > this.Length - 1)
        {
            throw new System.ArgumentOutOfRangeException(nameof(length));
        }
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaValue>();
        int index = 0;
        foreach (TestSchema.TestSchemaValue item in this)
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
    public TestSchema Remove(System.Predicate<TestSchema.TestSchemaValue> removeIfTrue)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaValue>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaValue>();
        foreach (TestSchema.TestSchemaValue item in this)
        {
            if (removeIfTrue(item))
            {
                continue;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public readonly struct TestSchemaValue : Menes.IJsonValue, System.IEquatable<TestSchemaValue>
    {
        public static readonly System.Func<System.Text.Json.JsonElement, TestSchemaValue> FromJsonElement = e => new TestSchemaValue(e);
        public static readonly TestSchemaValue Null = new TestSchemaValue(default(System.Text.Json.JsonElement));
        private static readonly Menes.JsonNumber? MultipleOf = 2;
        private static readonly Menes.JsonNumber? Maximum = null;
        private static readonly Menes.JsonNumber? ExclusiveMaximum = null;
        private static readonly Menes.JsonNumber? Minimum = null;
        private static readonly Menes.JsonNumber? ExclusiveMinimum = null;
        private readonly Menes.JsonAny? value;
        public TestSchemaValue(Menes.JsonAny value)
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
        public TestSchemaValue(System.Text.Json.JsonElement jsonElement)
        {
            this.value = null;
            this.JsonElement = jsonElement;
        }
        public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public TestSchemaValue? AsOptional => this.IsNull ? default(TestSchemaValue?) : this;
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static implicit operator TestSchemaValue(Menes.JsonAny value)
        {
            return new TestSchemaValue(value);
        }
        public static implicit operator Menes.JsonAny(TestSchemaValue value)
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
        public static TestSchemaValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new TestSchemaValue(property)
                    : Null)
                : Null;
        public static TestSchemaValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new TestSchemaValue(property)
                    : Null)
                : Null;
        public static TestSchemaValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new TestSchemaValue(property)
                    : Null)
                : Null;
        public bool Equals(TestSchemaValue other)
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
    public readonly struct ContainsValidationValue : Menes.IJsonValue, System.IEquatable<ContainsValidationValue>
    {
        public static readonly System.Func<System.Text.Json.JsonElement, ContainsValidationValue> FromJsonElement = e => new ContainsValidationValue(e);
        public static readonly ContainsValidationValue Null = new ContainsValidationValue(default(System.Text.Json.JsonElement));
        private static readonly Menes.JsonNumber? MultipleOf = 3;
        private static readonly Menes.JsonNumber? Maximum = null;
        private static readonly Menes.JsonNumber? ExclusiveMaximum = null;
        private static readonly Menes.JsonNumber? Minimum = null;
        private static readonly Menes.JsonNumber? ExclusiveMinimum = null;
        private readonly Menes.JsonAny? value;
        public ContainsValidationValue(Menes.JsonAny value)
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
        public ContainsValidationValue(System.Text.Json.JsonElement jsonElement)
        {
            this.value = null;
            this.JsonElement = jsonElement;
        }
        public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public ContainsValidationValue? AsOptional => this.IsNull ? default(ContainsValidationValue?) : this;
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static implicit operator ContainsValidationValue(Menes.JsonAny value)
        {
            return new ContainsValidationValue(value);
        }
        public static implicit operator Menes.JsonAny(ContainsValidationValue value)
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
        public static ContainsValidationValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new ContainsValidationValue(property)
                    : Null)
                : Null;
        public static ContainsValidationValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new ContainsValidationValue(property)
                    : Null)
                : Null;
        public static ContainsValidationValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new ContainsValidationValue(property)
                    : Null)
                : Null;
        public bool Equals(ContainsValidationValue other)
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
        var schema = new TestSchema(doc.RootElement);
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
        var schema = new TestSchema(doc.RootElement);
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
        var schema = new TestSchema(doc.RootElement);
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
        var schema = new TestSchema(doc.RootElement);
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