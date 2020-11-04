// <copyright file="items006.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.Items006
{
public readonly struct TestSchema : Menes.IJsonValue, System.Collections.Generic.IEnumerable<TestSchema.TestSchemaArray>, System.Collections.IEnumerable, System.IEquatable<TestSchema>, System.IEquatable<Menes.JsonArray<TestSchema.TestSchemaArray>>
{
    public static readonly System.Func<System.Text.Json.JsonElement, TestSchema> FromJsonElement = e => new TestSchema(e);
    public static readonly TestSchema Null = new TestSchema(default(System.Text.Json.JsonElement));
    private readonly Menes.JsonArray<TestSchema.TestSchemaArray>? value;
    public TestSchema(Menes.JsonArray<TestSchema.TestSchemaArray> jsonArray)
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
            if (this.value is Menes.JsonArray<TestSchema.TestSchemaArray> value)
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
    public static implicit operator TestSchema(Menes.JsonArray<TestSchema.TestSchemaArray> value)
    {
        return new TestSchema(value);
    }
    public static implicit operator Menes.JsonArray<TestSchema.TestSchemaArray>(TestSchema value)
    {
        if (value.value is Menes.JsonArray<TestSchema.TestSchemaArray> clrValue)
        {
            return clrValue;
        }
        return new Menes.JsonArray<TestSchema.TestSchemaArray>(value.JsonElement);
    }
    public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
    {
        return Menes.JsonArray<TestSchema.TestSchemaArray>.IsConvertibleFrom(jsonElement);
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
        return this.Equals((Menes.JsonArray<TestSchema.TestSchemaArray>)other);
    }
    public bool Equals(Menes.JsonArray<TestSchema.TestSchemaArray> other)
    {
        return ((Menes.JsonArray<TestSchema.TestSchemaArray>)this).Equals(other);
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        Menes.JsonArray<TestSchema.TestSchemaArray> array = this;
        Menes.ValidationContext context = validationContext;
        context = array.Validate(context);
        context = array.ValidateItems(context);
        return context;
    }
    public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
    {
        if (this.HasJsonElement)
        {
            this.JsonElement.WriteTo(writer);
        }
        if (this.value is Menes.JsonArray<TestSchema.TestSchemaArray> clrValue)
        {
            clrValue.WriteTo(writer);
        }
    }
    public Menes.JsonArray<TestSchema.TestSchemaArray>.JsonArrayEnumerator GetEnumerator()
    {
        return ((Menes.JsonArray<TestSchema.TestSchemaArray>)this).GetEnumerator();
    }
    System.Collections.Generic.IEnumerator<TestSchema.TestSchemaArray> System.Collections.Generic.IEnumerable<TestSchema.TestSchemaArray>.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    public TestSchema Add(params TestSchema.TestSchemaArray[] items)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray>();
        foreach (TestSchema.TestSchemaArray item in this)
        {
            arrayBuilder.Add(item);
        }
        foreach (TestSchema.TestSchemaArray item in items)
        {
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Add(in TestSchema.TestSchemaArray item1)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray>();
        foreach (TestSchema.TestSchemaArray item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Add(in TestSchema.TestSchemaArray item1, in TestSchema.TestSchemaArray item2)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray>();
        foreach (TestSchema.TestSchemaArray item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Add(in TestSchema.TestSchemaArray item1, in TestSchema.TestSchemaArray item2, in TestSchema.TestSchemaArray item3)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray>();
        foreach (TestSchema.TestSchemaArray item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        arrayBuilder.Add(item3);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Add(in TestSchema.TestSchemaArray item1, in TestSchema.TestSchemaArray item2, in TestSchema.TestSchemaArray item3, in TestSchema.TestSchemaArray item4)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray>();
        foreach (TestSchema.TestSchemaArray item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        arrayBuilder.Add(item3);
        arrayBuilder.Add(item4);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Insert(int indexToInsert, params TestSchema.TestSchemaArray[] items)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray>();
        int index = 0;
        foreach (TestSchema.TestSchemaArray item in this)
        {
            if (index == indexToInsert)
            {
                foreach (TestSchema.TestSchemaArray itemToInsert in items)
                {
                    arrayBuilder.Add(itemToInsert);
                }
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Insert(int indexToInsert, in TestSchema.TestSchemaArray item1)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray>();
        int index = 0;
        foreach (TestSchema.TestSchemaArray item in this)
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
    public TestSchema Insert(int indexToInsert, in TestSchema.TestSchemaArray item1, in TestSchema.TestSchemaArray item2)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray>();
        int index = 0;
        foreach (TestSchema.TestSchemaArray item in this)
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
    public TestSchema Insert(int indexToInsert, in TestSchema.TestSchemaArray item1, in TestSchema.TestSchemaArray item2, in TestSchema.TestSchemaArray item3)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray>();
        int index = 0;
        foreach (TestSchema.TestSchemaArray item in this)
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
    public TestSchema Insert(int indexToInsert, in TestSchema.TestSchemaArray item1, in TestSchema.TestSchemaArray item2, in TestSchema.TestSchemaArray item3, in TestSchema.TestSchemaArray item4)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray>();
        int index = 0;
        foreach (TestSchema.TestSchemaArray item in this)
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
    public TestSchema Remove(params TestSchema.TestSchemaArray[] items)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray>();
        foreach (TestSchema.TestSchemaArray item in this)
        {
            bool found = false;
            foreach (TestSchema.TestSchemaArray itemToRemove in items)
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
    public TestSchema Remove(TestSchema.TestSchemaArray item1)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray>();
        foreach (TestSchema.TestSchemaArray item in this)
        {
            if (item1.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Remove(TestSchema.TestSchemaArray item1, TestSchema.TestSchemaArray item2)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray>();
        foreach (TestSchema.TestSchemaArray item in this)
        {
            if (item1.Equals(item) || item2.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Remove(TestSchema.TestSchemaArray item1, TestSchema.TestSchemaArray item2, TestSchema.TestSchemaArray item3)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray>();
        foreach (TestSchema.TestSchemaArray item in this)
        {
            if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Remove(TestSchema.TestSchemaArray item1, TestSchema.TestSchemaArray item2, TestSchema.TestSchemaArray item3, TestSchema.TestSchemaArray item4)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray>();
        foreach (TestSchema.TestSchemaArray item in this)
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
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray>();
        int index = 0;
        foreach (TestSchema.TestSchemaArray item in this)
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
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray>();
        int index = 0;
        foreach (TestSchema.TestSchemaArray item in this)
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
    public TestSchema Remove(System.Predicate<TestSchema.TestSchemaArray> removeIfTrue)
    {
        System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray>();
        foreach (TestSchema.TestSchemaArray item in this)
        {
            if (removeIfTrue(item))
            {
                continue;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public readonly struct TestSchemaArray : Menes.IJsonValue, System.Collections.Generic.IEnumerable<TestSchema.TestSchemaArray.TestSchemaArrayArray>, System.Collections.IEnumerable, System.IEquatable<TestSchemaArray>, System.IEquatable<Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>>
    {
        public static readonly System.Func<System.Text.Json.JsonElement, TestSchemaArray> FromJsonElement = e => new TestSchemaArray(e);
        public static readonly TestSchemaArray Null = new TestSchemaArray(default(System.Text.Json.JsonElement));
        private readonly Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>? value;
        public TestSchemaArray(Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray> jsonArray)
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
        public TestSchemaArray(System.Text.Json.JsonElement jsonElement)
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
                if (this.value is Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray> value)
                {
                    return value.Length;
                }
                return 0;
            }
        }
        public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public TestSchemaArray? AsOptional => this.IsNull ? default(TestSchemaArray?) : this;
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static implicit operator TestSchemaArray(Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray> value)
        {
            return new TestSchemaArray(value);
        }
        public static implicit operator Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>(TestSchemaArray value)
        {
            if (value.value is Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray> clrValue)
            {
                return clrValue;
            }
            return new Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>(value.JsonElement);
        }
        public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
        {
            return Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>.IsConvertibleFrom(jsonElement);
        }
        public static TestSchemaArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new TestSchemaArray(property)
                    : Null)
                : Null;
        public static TestSchemaArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new TestSchemaArray(property)
                    : Null)
                : Null;
        public static TestSchemaArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new TestSchemaArray(property)
                    : Null)
                : Null;
        public bool Equals(TestSchemaArray other)
        {
            return this.Equals((Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>)other);
        }
        public bool Equals(Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray> other)
        {
            return ((Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>)this).Equals(other);
        }
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
        {
            Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray> array = this;
            Menes.ValidationContext context = validationContext;
            context = array.Validate(context);
            context = array.ValidateItems(context);
            return context;
        }
        public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
        {
            if (this.HasJsonElement)
            {
                this.JsonElement.WriteTo(writer);
            }
            if (this.value is Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray> clrValue)
            {
                clrValue.WriteTo(writer);
            }
        }
        public Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>.JsonArrayEnumerator GetEnumerator()
        {
            return ((Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>)this).GetEnumerator();
        }
        System.Collections.Generic.IEnumerator<TestSchema.TestSchemaArray.TestSchemaArrayArray> System.Collections.Generic.IEnumerable<TestSchema.TestSchemaArray.TestSchemaArrayArray>.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public TestSchemaArray Add(params TestSchema.TestSchemaArray.TestSchemaArrayArray[] items)
        {
            System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray>();
            foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray item in this)
            {
                arrayBuilder.Add(item);
            }
            foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray item in items)
            {
                arrayBuilder.Add(item);
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public TestSchemaArray Add(in TestSchema.TestSchemaArray.TestSchemaArrayArray item1)
        {
            System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray>();
            foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray item in this)
            {
                arrayBuilder.Add(item);
            }
            arrayBuilder.Add(item1);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public TestSchemaArray Add(in TestSchema.TestSchemaArray.TestSchemaArrayArray item1, in TestSchema.TestSchemaArray.TestSchemaArrayArray item2)
        {
            System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray>();
            foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray item in this)
            {
                arrayBuilder.Add(item);
            }
            arrayBuilder.Add(item1);
            arrayBuilder.Add(item2);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public TestSchemaArray Add(in TestSchema.TestSchemaArray.TestSchemaArrayArray item1, in TestSchema.TestSchemaArray.TestSchemaArrayArray item2, in TestSchema.TestSchemaArray.TestSchemaArrayArray item3)
        {
            System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray>();
            foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray item in this)
            {
                arrayBuilder.Add(item);
            }
            arrayBuilder.Add(item1);
            arrayBuilder.Add(item2);
            arrayBuilder.Add(item3);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public TestSchemaArray Add(in TestSchema.TestSchemaArray.TestSchemaArrayArray item1, in TestSchema.TestSchemaArray.TestSchemaArrayArray item2, in TestSchema.TestSchemaArray.TestSchemaArrayArray item3, in TestSchema.TestSchemaArray.TestSchemaArrayArray item4)
        {
            System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray>();
            foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray item in this)
            {
                arrayBuilder.Add(item);
            }
            arrayBuilder.Add(item1);
            arrayBuilder.Add(item2);
            arrayBuilder.Add(item3);
            arrayBuilder.Add(item4);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public TestSchemaArray Insert(int indexToInsert, params TestSchema.TestSchemaArray.TestSchemaArrayArray[] items)
        {
            System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray>();
            int index = 0;
            foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray item in this)
            {
                if (index == indexToInsert)
                {
                    foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray itemToInsert in items)
                    {
                        arrayBuilder.Add(itemToInsert);
                    }
                }
                arrayBuilder.Add(item);
                ++index;
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public TestSchemaArray Insert(int indexToInsert, in TestSchema.TestSchemaArray.TestSchemaArrayArray item1)
        {
            System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray>();
            int index = 0;
            foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray item in this)
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
        public TestSchemaArray Insert(int indexToInsert, in TestSchema.TestSchemaArray.TestSchemaArrayArray item1, in TestSchema.TestSchemaArray.TestSchemaArrayArray item2)
        {
            System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray>();
            int index = 0;
            foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray item in this)
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
        public TestSchemaArray Insert(int indexToInsert, in TestSchema.TestSchemaArray.TestSchemaArrayArray item1, in TestSchema.TestSchemaArray.TestSchemaArrayArray item2, in TestSchema.TestSchemaArray.TestSchemaArrayArray item3)
        {
            System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray>();
            int index = 0;
            foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray item in this)
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
        public TestSchemaArray Insert(int indexToInsert, in TestSchema.TestSchemaArray.TestSchemaArrayArray item1, in TestSchema.TestSchemaArray.TestSchemaArrayArray item2, in TestSchema.TestSchemaArray.TestSchemaArrayArray item3, in TestSchema.TestSchemaArray.TestSchemaArrayArray item4)
        {
            System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray>();
            int index = 0;
            foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray item in this)
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
        public TestSchemaArray Remove(params TestSchema.TestSchemaArray.TestSchemaArrayArray[] items)
        {
            System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray>();
            foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray item in this)
            {
                bool found = false;
                foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray itemToRemove in items)
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
        public TestSchemaArray Remove(TestSchema.TestSchemaArray.TestSchemaArrayArray item1)
        {
            System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray>();
            foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray item in this)
            {
                if (item1.Equals(item))
                {
                    break;
                }
                arrayBuilder.Add(item);
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public TestSchemaArray Remove(TestSchema.TestSchemaArray.TestSchemaArrayArray item1, TestSchema.TestSchemaArray.TestSchemaArrayArray item2)
        {
            System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray>();
            foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray item in this)
            {
                if (item1.Equals(item) || item2.Equals(item))
                {
                    break;
                }
                arrayBuilder.Add(item);
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public TestSchemaArray Remove(TestSchema.TestSchemaArray.TestSchemaArrayArray item1, TestSchema.TestSchemaArray.TestSchemaArrayArray item2, TestSchema.TestSchemaArray.TestSchemaArrayArray item3)
        {
            System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray>();
            foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray item in this)
            {
                if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))
                {
                    break;
                }
                arrayBuilder.Add(item);
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public TestSchemaArray Remove(TestSchema.TestSchemaArray.TestSchemaArrayArray item1, TestSchema.TestSchemaArray.TestSchemaArrayArray item2, TestSchema.TestSchemaArray.TestSchemaArrayArray item3, TestSchema.TestSchemaArray.TestSchemaArrayArray item4)
        {
            System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray>();
            foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray item in this)
            {
                if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item) || item4.Equals(item))
                {
                    break;
                }
                arrayBuilder.Add(item);
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public TestSchemaArray RemoveAt(int indexToRemove)
        {
            System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray>();
            int index = 0;
            foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray item in this)
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
        public TestSchemaArray RemoveRange(int startIndex, int length)
        {
            if (startIndex < 0 || startIndex > this.Length - 1)
            {
                throw new System.ArgumentOutOfRangeException(nameof(startIndex));
            }
            if (length < 1 || startIndex + length > this.Length - 1)
            {
                throw new System.ArgumentOutOfRangeException(nameof(length));
            }
            System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray>();
            int index = 0;
            foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray item in this)
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
        public TestSchemaArray Remove(System.Predicate<TestSchema.TestSchemaArray.TestSchemaArrayArray> removeIfTrue)
        {
            System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray>();
            foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray item in this)
            {
                if (removeIfTrue(item))
                {
                    continue;
                }
                arrayBuilder.Add(item);
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public readonly struct TestSchemaArrayArray : Menes.IJsonValue, System.Collections.Generic.IEnumerable<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>, System.Collections.IEnumerable, System.IEquatable<TestSchemaArrayArray>, System.IEquatable<Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, TestSchemaArrayArray> FromJsonElement = e => new TestSchemaArrayArray(e);
            public static readonly TestSchemaArrayArray Null = new TestSchemaArrayArray(default(System.Text.Json.JsonElement));
            private readonly Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>? value;
            public TestSchemaArrayArray(Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray> jsonArray)
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
            public TestSchemaArrayArray(System.Text.Json.JsonElement jsonElement)
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
                    if (this.value is Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray> value)
                    {
                        return value.Length;
                    }
                    return 0;
                }
            }
            public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public TestSchemaArrayArray? AsOptional => this.IsNull ? default(TestSchemaArrayArray?) : this;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static implicit operator TestSchemaArrayArray(Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray> value)
            {
                return new TestSchemaArrayArray(value);
            }
            public static implicit operator Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>(TestSchemaArrayArray value)
            {
                if (value.value is Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray> clrValue)
                {
                    return clrValue;
                }
                return new Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>(value.JsonElement);
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>.IsConvertibleFrom(jsonElement);
            }
            public static TestSchemaArrayArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new TestSchemaArrayArray(property)
                        : Null)
                    : Null;
            public static TestSchemaArrayArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new TestSchemaArrayArray(property)
                        : Null)
                    : Null;
            public static TestSchemaArrayArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new TestSchemaArrayArray(property)
                        : Null)
                    : Null;
            public bool Equals(TestSchemaArrayArray other)
            {
                return this.Equals((Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>)other);
            }
            public bool Equals(Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray> other)
            {
                return ((Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>)this).Equals(other);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray> array = this;
                Menes.ValidationContext context = validationContext;
                context = array.Validate(context);
                context = array.ValidateItems(context);
                return context;
            }
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                }
                if (this.value is Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray> clrValue)
                {
                    clrValue.WriteTo(writer);
                }
            }
            public Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>.JsonArrayEnumerator GetEnumerator()
            {
                return ((Menes.JsonArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>)this).GetEnumerator();
            }
            System.Collections.Generic.IEnumerator<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray> System.Collections.Generic.IEnumerable<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            public TestSchemaArrayArray Add(params TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray[] items)
            {
                System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>();
                foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item in this)
                {
                    arrayBuilder.Add(item);
                }
                foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item in items)
                {
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public TestSchemaArrayArray Add(in TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item1)
            {
                System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>();
                foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public TestSchemaArrayArray Add(in TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item1, in TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item2)
            {
                System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>();
                foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public TestSchemaArrayArray Add(in TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item1, in TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item2, in TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item3)
            {
                System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>();
                foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                arrayBuilder.Add(item3);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public TestSchemaArrayArray Add(in TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item1, in TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item2, in TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item3, in TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item4)
            {
                System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>();
                foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                arrayBuilder.Add(item3);
                arrayBuilder.Add(item4);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public TestSchemaArrayArray Insert(int indexToInsert, params TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray[] items)
            {
                System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>();
                int index = 0;
                foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item in this)
                {
                    if (index == indexToInsert)
                    {
                        foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray itemToInsert in items)
                        {
                            arrayBuilder.Add(itemToInsert);
                        }
                    }
                    arrayBuilder.Add(item);
                    ++index;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public TestSchemaArrayArray Insert(int indexToInsert, in TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item1)
            {
                System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>();
                int index = 0;
                foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item in this)
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
            public TestSchemaArrayArray Insert(int indexToInsert, in TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item1, in TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item2)
            {
                System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>();
                int index = 0;
                foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item in this)
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
            public TestSchemaArrayArray Insert(int indexToInsert, in TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item1, in TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item2, in TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item3)
            {
                System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>();
                int index = 0;
                foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item in this)
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
            public TestSchemaArrayArray Insert(int indexToInsert, in TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item1, in TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item2, in TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item3, in TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item4)
            {
                System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>();
                int index = 0;
                foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item in this)
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
            public TestSchemaArrayArray Remove(params TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray[] items)
            {
                System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>();
                foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item in this)
                {
                    bool found = false;
                    foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray itemToRemove in items)
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
            public TestSchemaArrayArray Remove(TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item1)
            {
                System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>();
                foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item in this)
                {
                    if (item1.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public TestSchemaArrayArray Remove(TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item1, TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item2)
            {
                System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>();
                foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item in this)
                {
                    if (item1.Equals(item) || item2.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public TestSchemaArrayArray Remove(TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item1, TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item2, TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item3)
            {
                System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>();
                foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item in this)
                {
                    if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public TestSchemaArrayArray Remove(TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item1, TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item2, TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item3, TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item4)
            {
                System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>();
                foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item in this)
                {
                    if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item) || item4.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public TestSchemaArrayArray RemoveAt(int indexToRemove)
            {
                System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>();
                int index = 0;
                foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item in this)
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
            public TestSchemaArrayArray RemoveRange(int startIndex, int length)
            {
                if (startIndex < 0 || startIndex > this.Length - 1)
                {
                    throw new System.ArgumentOutOfRangeException(nameof(startIndex));
                }
                if (length < 1 || startIndex + length > this.Length - 1)
                {
                    throw new System.ArgumentOutOfRangeException(nameof(length));
                }
                System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>();
                int index = 0;
                foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item in this)
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
            public TestSchemaArrayArray Remove(System.Predicate<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray> removeIfTrue)
            {
                System.Collections.Immutable.ImmutableArray<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray>();
                foreach (TestSchema.TestSchemaArray.TestSchemaArrayArray.TestSchemaArrayArrayArray item in this)
                {
                    if (removeIfTrue(item))
                    {
                        continue;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public readonly struct TestSchemaArrayArrayArray : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Menes.JsonNumber>, System.Collections.IEnumerable, System.IEquatable<TestSchemaArrayArrayArray>, System.IEquatable<Menes.JsonArray<Menes.JsonNumber>>
            {
                public static readonly System.Func<System.Text.Json.JsonElement, TestSchemaArrayArrayArray> FromJsonElement = e => new TestSchemaArrayArrayArray(e);
                public static readonly TestSchemaArrayArrayArray Null = new TestSchemaArrayArrayArray(default(System.Text.Json.JsonElement));
                private readonly Menes.JsonArray<Menes.JsonNumber>? value;
                public TestSchemaArrayArrayArray(Menes.JsonArray<Menes.JsonNumber> jsonArray)
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
                public TestSchemaArrayArrayArray(System.Text.Json.JsonElement jsonElement)
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
                        if (this.value is Menes.JsonArray<Menes.JsonNumber> value)
                        {
                            return value.Length;
                        }
                        return 0;
                    }
                }
                public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
                public TestSchemaArrayArrayArray? AsOptional => this.IsNull ? default(TestSchemaArrayArrayArray?) : this;
                public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
                public System.Text.Json.JsonElement JsonElement { get; }
                public static implicit operator TestSchemaArrayArrayArray(Menes.JsonArray<Menes.JsonNumber> value)
                {
                    return new TestSchemaArrayArrayArray(value);
                }
                public static implicit operator Menes.JsonArray<Menes.JsonNumber>(TestSchemaArrayArrayArray value)
                {
                    if (value.value is Menes.JsonArray<Menes.JsonNumber> clrValue)
                    {
                        return clrValue;
                    }
                    return new Menes.JsonArray<Menes.JsonNumber>(value.JsonElement);
                }
                public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
                {
                    return Menes.JsonArray<Menes.JsonNumber>.IsConvertibleFrom(jsonElement);
                }
                public static TestSchemaArrayArrayArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
                   parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                        (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                            ? new TestSchemaArrayArrayArray(property)
                            : Null)
                        : Null;
                public static TestSchemaArrayArrayArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
                   parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                        (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                            ? new TestSchemaArrayArrayArray(property)
                            : Null)
                        : Null;
                public static TestSchemaArrayArrayArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
                   parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                        (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                            ? new TestSchemaArrayArrayArray(property)
                            : Null)
                        : Null;
                public bool Equals(TestSchemaArrayArrayArray other)
                {
                    return this.Equals((Menes.JsonArray<Menes.JsonNumber>)other);
                }
                public bool Equals(Menes.JsonArray<Menes.JsonNumber> other)
                {
                    return ((Menes.JsonArray<Menes.JsonNumber>)this).Equals(other);
                }
                public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
                {
                    Menes.JsonArray<Menes.JsonNumber> array = this;
                    Menes.ValidationContext context = validationContext;
                    context = array.Validate(context);
                    context = array.ValidateItems(context);
                    return context;
                }
                public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
                {
                    if (this.HasJsonElement)
                    {
                        this.JsonElement.WriteTo(writer);
                    }
                    if (this.value is Menes.JsonArray<Menes.JsonNumber> clrValue)
                    {
                        clrValue.WriteTo(writer);
                    }
                }
                public Menes.JsonArray<Menes.JsonNumber>.JsonArrayEnumerator GetEnumerator()
                {
                    return ((Menes.JsonArray<Menes.JsonNumber>)this).GetEnumerator();
                }
                System.Collections.Generic.IEnumerator<Menes.JsonNumber> System.Collections.Generic.IEnumerable<Menes.JsonNumber>.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
                public TestSchemaArrayArrayArray Add(params Menes.JsonNumber[] items)
                {
                    System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                    foreach (Menes.JsonNumber item in this)
                    {
                        arrayBuilder.Add(item);
                    }
                    foreach (Menes.JsonNumber item in items)
                    {
                        arrayBuilder.Add(item);
                    }
                    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
                }
                public TestSchemaArrayArrayArray Add(in Menes.JsonNumber item1)
                {
                    System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                    foreach (Menes.JsonNumber item in this)
                    {
                        arrayBuilder.Add(item);
                    }
                    arrayBuilder.Add(item1);
                    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
                }
                public TestSchemaArrayArrayArray Add(in Menes.JsonNumber item1, in Menes.JsonNumber item2)
                {
                    System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                    foreach (Menes.JsonNumber item in this)
                    {
                        arrayBuilder.Add(item);
                    }
                    arrayBuilder.Add(item1);
                    arrayBuilder.Add(item2);
                    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
                }
                public TestSchemaArrayArrayArray Add(in Menes.JsonNumber item1, in Menes.JsonNumber item2, in Menes.JsonNumber item3)
                {
                    System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                    foreach (Menes.JsonNumber item in this)
                    {
                        arrayBuilder.Add(item);
                    }
                    arrayBuilder.Add(item1);
                    arrayBuilder.Add(item2);
                    arrayBuilder.Add(item3);
                    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
                }
                public TestSchemaArrayArrayArray Add(in Menes.JsonNumber item1, in Menes.JsonNumber item2, in Menes.JsonNumber item3, in Menes.JsonNumber item4)
                {
                    System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                    foreach (Menes.JsonNumber item in this)
                    {
                        arrayBuilder.Add(item);
                    }
                    arrayBuilder.Add(item1);
                    arrayBuilder.Add(item2);
                    arrayBuilder.Add(item3);
                    arrayBuilder.Add(item4);
                    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
                }
                public TestSchemaArrayArrayArray Insert(int indexToInsert, params Menes.JsonNumber[] items)
                {
                    System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                    int index = 0;
                    foreach (Menes.JsonNumber item in this)
                    {
                        if (index == indexToInsert)
                        {
                            foreach (Menes.JsonNumber itemToInsert in items)
                            {
                                arrayBuilder.Add(itemToInsert);
                            }
                        }
                        arrayBuilder.Add(item);
                        ++index;
                    }
                    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
                }
                public TestSchemaArrayArrayArray Insert(int indexToInsert, in Menes.JsonNumber item1)
                {
                    System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                    int index = 0;
                    foreach (Menes.JsonNumber item in this)
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
                public TestSchemaArrayArrayArray Insert(int indexToInsert, in Menes.JsonNumber item1, in Menes.JsonNumber item2)
                {
                    System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                    int index = 0;
                    foreach (Menes.JsonNumber item in this)
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
                public TestSchemaArrayArrayArray Insert(int indexToInsert, in Menes.JsonNumber item1, in Menes.JsonNumber item2, in Menes.JsonNumber item3)
                {
                    System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                    int index = 0;
                    foreach (Menes.JsonNumber item in this)
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
                public TestSchemaArrayArrayArray Insert(int indexToInsert, in Menes.JsonNumber item1, in Menes.JsonNumber item2, in Menes.JsonNumber item3, in Menes.JsonNumber item4)
                {
                    System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                    int index = 0;
                    foreach (Menes.JsonNumber item in this)
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
                public TestSchemaArrayArrayArray Remove(params Menes.JsonNumber[] items)
                {
                    System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                    foreach (Menes.JsonNumber item in this)
                    {
                        bool found = false;
                        foreach (Menes.JsonNumber itemToRemove in items)
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
                public TestSchemaArrayArrayArray Remove(Menes.JsonNumber item1)
                {
                    System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                    foreach (Menes.JsonNumber item in this)
                    {
                        if (item1.Equals(item))
                        {
                            break;
                        }
                        arrayBuilder.Add(item);
                    }
                    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
                }
                public TestSchemaArrayArrayArray Remove(Menes.JsonNumber item1, Menes.JsonNumber item2)
                {
                    System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                    foreach (Menes.JsonNumber item in this)
                    {
                        if (item1.Equals(item) || item2.Equals(item))
                        {
                            break;
                        }
                        arrayBuilder.Add(item);
                    }
                    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
                }
                public TestSchemaArrayArrayArray Remove(Menes.JsonNumber item1, Menes.JsonNumber item2, Menes.JsonNumber item3)
                {
                    System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                    foreach (Menes.JsonNumber item in this)
                    {
                        if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))
                        {
                            break;
                        }
                        arrayBuilder.Add(item);
                    }
                    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
                }
                public TestSchemaArrayArrayArray Remove(Menes.JsonNumber item1, Menes.JsonNumber item2, Menes.JsonNumber item3, Menes.JsonNumber item4)
                {
                    System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                    foreach (Menes.JsonNumber item in this)
                    {
                        if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item) || item4.Equals(item))
                        {
                            break;
                        }
                        arrayBuilder.Add(item);
                    }
                    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
                }
                public TestSchemaArrayArrayArray RemoveAt(int indexToRemove)
                {
                    System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                    int index = 0;
                    foreach (Menes.JsonNumber item in this)
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
                public TestSchemaArrayArrayArray RemoveRange(int startIndex, int length)
                {
                    if (startIndex < 0 || startIndex > this.Length - 1)
                    {
                        throw new System.ArgumentOutOfRangeException(nameof(startIndex));
                    }
                    if (length < 1 || startIndex + length > this.Length - 1)
                    {
                        throw new System.ArgumentOutOfRangeException(nameof(length));
                    }
                    System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                    int index = 0;
                    foreach (Menes.JsonNumber item in this)
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
                public TestSchemaArrayArrayArray Remove(System.Predicate<Menes.JsonNumber> removeIfTrue)
                {
                    System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                    foreach (Menes.JsonNumber item in this)
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
    }
}
///  <summary>
/// nested items
/// </summary>
public static class Tests
{
/// <summary>
/// valid nested array
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[[[[1]], [[2],[3]]], [[[4], [5], [6]]]]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Items006.Tests.Test0: valid nested array");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// nested array with invalid type
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[[[[\"1\"]], [[2],[3]]], [[[4], [5], [6]]]]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Items006.Tests.Test1: nested array with invalid type");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// not deep enough
/// </summary>
    public static bool Test2()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[[[1], [2],[3]], [[4], [5], [6]]]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Items006.Tests.Test2: not deep enough");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
}
}