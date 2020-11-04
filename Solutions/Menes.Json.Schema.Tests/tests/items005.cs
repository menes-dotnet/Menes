// <copyright file="items005.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.Items005
{
public readonly struct TestSchema : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.IEquatable<TestSchema>, System.IEquatable<Menes.JsonArray<Menes.JsonAny>>
{
    public static readonly System.Func<System.Text.Json.JsonElement, TestSchema> FromJsonElement = e => new TestSchema(e);
    public static readonly TestSchema Null = new TestSchema(default(System.Text.Json.JsonElement));
    private readonly Menes.JsonArray<Menes.JsonAny>? value;
    public TestSchema(Menes.JsonArray<Menes.JsonAny> jsonArray)
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
            if (this.value is Menes.JsonArray<Menes.JsonAny> value)
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
    public static implicit operator Menes.JsonArray<Menes.JsonAny>(TestSchema value)
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
        context = array.Validate(context);
        var itemsValidationEnumerator = array.GetEnumerator();
        if (itemsValidationEnumerator.MoveNext())
        {
            context = Menes.Validation.ValidateProperty(context, Menes.JsonAny.From(itemsValidationEnumerator.Current).As<TestSchema.ItemsValidationItem1Array>(), $"[0]");
        }
        if (itemsValidationEnumerator.MoveNext())
        {
            context = Menes.Validation.ValidateProperty(context, Menes.JsonAny.From(itemsValidationEnumerator.Current).As<TestSchema.ItemsValidationItem2Array>(), $"[1]");
        }
        if (itemsValidationEnumerator.MoveNext())
        {
            context = Menes.Validation.ValidateProperty(context, Menes.JsonAny.From(itemsValidationEnumerator.Current).As<TestSchema.ItemsValidationItem3Array>(), $"[2]");
        }
        if (itemsValidationEnumerator.MoveNext())
        {
            context = context.WithError($"core 9.3.1.1. items: The array should have contained 3 items but actually contained {array.Length} items.");
        }
        context = array.ValidateItems(context);
        return context;
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
    public TestSchema Add(params Menes.JsonAny[] items)
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
    public TestSchema Add(in Menes.JsonAny item1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Add(in Menes.JsonAny item1, in Menes.JsonAny item2)
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
    public TestSchema Add(in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3)
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
    public TestSchema Add(in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3, in Menes.JsonAny item4)
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
    public TestSchema Insert(int indexToInsert, params Menes.JsonAny[] items)
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
    public TestSchema Insert(int indexToInsert, in Menes.JsonAny item1)
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
    public TestSchema Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2)
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
    public TestSchema Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3)
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
    public TestSchema Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3, in Menes.JsonAny item4)
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
    public TestSchema Remove(params Menes.JsonAny[] items)
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
    public TestSchema Remove(Menes.JsonAny item1)
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
    public TestSchema Remove(Menes.JsonAny item1, Menes.JsonAny item2)
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
    public TestSchema Remove(Menes.JsonAny item1, Menes.JsonAny item2, Menes.JsonAny item3)
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
    public TestSchema Remove(Menes.JsonAny item1, Menes.JsonAny item2, Menes.JsonAny item3, Menes.JsonAny item4)
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
    public TestSchema RemoveAt(int indexToRemove)
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
    public TestSchema Remove(System.Predicate<Menes.JsonAny> removeIfTrue)
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
    public readonly struct ItemsValidationItem1Array : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.IEquatable<ItemsValidationItem1Array>, System.IEquatable<Menes.JsonArray<Menes.JsonAny>>
    {
        public static readonly System.Func<System.Text.Json.JsonElement, ItemsValidationItem1Array> FromJsonElement = e => new ItemsValidationItem1Array(e);
        public static readonly ItemsValidationItem1Array Null = new ItemsValidationItem1Array(default(System.Text.Json.JsonElement));
        private readonly Menes.JsonArray<Menes.JsonAny>? value;
        public ItemsValidationItem1Array(Menes.JsonArray<Menes.JsonAny> jsonArray)
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
        public ItemsValidationItem1Array(System.Text.Json.JsonElement jsonElement)
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
        public ItemsValidationItem1Array? AsOptional => this.IsNull ? default(ItemsValidationItem1Array?) : this;
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static implicit operator ItemsValidationItem1Array(Menes.JsonArray<Menes.JsonAny> value)
        {
            return new ItemsValidationItem1Array(value);
        }
        public static implicit operator Menes.JsonArray<Menes.JsonAny>(ItemsValidationItem1Array value)
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
        public static ItemsValidationItem1Array FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new ItemsValidationItem1Array(property)
                    : Null)
                : Null;
        public static ItemsValidationItem1Array FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new ItemsValidationItem1Array(property)
                    : Null)
                : Null;
        public static ItemsValidationItem1Array FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new ItemsValidationItem1Array(property)
                    : Null)
                : Null;
        public bool Equals(ItemsValidationItem1Array other)
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
            context = array.Validate(context);
            var itemsValidationEnumerator = array.GetEnumerator();
            if (itemsValidationEnumerator.MoveNext())
            {
                context = Menes.Validation.ValidateProperty(context, Menes.JsonAny.From(itemsValidationEnumerator.Current).As<TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity>(), $"[0]");
            }
            if (itemsValidationEnumerator.MoveNext())
            {
                context = Menes.Validation.ValidateProperty(context, Menes.JsonAny.From(itemsValidationEnumerator.Current).As<TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity>(), $"[1]");
            }
            if (itemsValidationEnumerator.MoveNext())
            {
                context = context.WithError($"core 9.3.1.1. items: The array should have contained 2 items but actually contained {array.Length} items.");
            }
            context = array.ValidateItems(context);
            return context;
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
        public ItemsValidationItem1Array Add(params Menes.JsonAny[] items)
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
        public ItemsValidationItem1Array Add(in Menes.JsonAny item1)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            foreach (Menes.JsonAny item in this)
            {
                arrayBuilder.Add(item);
            }
            arrayBuilder.Add(item1);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public ItemsValidationItem1Array Add(in Menes.JsonAny item1, in Menes.JsonAny item2)
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
        public ItemsValidationItem1Array Add(in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3)
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
        public ItemsValidationItem1Array Add(in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3, in Menes.JsonAny item4)
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
        public ItemsValidationItem1Array Insert(int indexToInsert, params Menes.JsonAny[] items)
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
        public ItemsValidationItem1Array Insert(int indexToInsert, in Menes.JsonAny item1)
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
        public ItemsValidationItem1Array Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2)
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
        public ItemsValidationItem1Array Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3)
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
        public ItemsValidationItem1Array Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3, in Menes.JsonAny item4)
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
        public ItemsValidationItem1Array Remove(params Menes.JsonAny[] items)
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
        public ItemsValidationItem1Array Remove(Menes.JsonAny item1)
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
        public ItemsValidationItem1Array Remove(Menes.JsonAny item1, Menes.JsonAny item2)
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
        public ItemsValidationItem1Array Remove(Menes.JsonAny item1, Menes.JsonAny item2, Menes.JsonAny item3)
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
        public ItemsValidationItem1Array Remove(Menes.JsonAny item1, Menes.JsonAny item2, Menes.JsonAny item3, Menes.JsonAny item4)
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
        public ItemsValidationItem1Array RemoveAt(int indexToRemove)
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
        public ItemsValidationItem1Array RemoveRange(int startIndex, int length)
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
        public ItemsValidationItem1Array Remove(System.Predicate<Menes.JsonAny> removeIfTrue)
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

        public readonly struct ItemsValidationItem1Entity : Menes.IJsonObject, System.IEquatable<TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
        {
            public static readonly TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity Null = new TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity> FromJsonElement = e => new TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity(e);
            private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>>.Empty;
            private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
            public ItemsValidationItem1Entity(System.Text.Json.JsonElement jsonElement)
            {
                this.JsonElement = jsonElement;
                this.additionalPropertiesBacking = null;
            }
            public ItemsValidationItem1Entity(params (string, Menes.JsonAny)[] additionalPropertiesBacking)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
            }
            public ItemsValidationItem1Entity((string, Menes.JsonAny) additionalProperty1)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
            }
            public ItemsValidationItem1Entity((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
            }
            public ItemsValidationItem1Entity((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
            }
            public ItemsValidationItem1Entity((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
            }
            private ItemsValidationItem1Entity(Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = additionalPropertiesBacking;
            }
            public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity? AsOptional => this.IsNull ? default(TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity?) : this;
            public int PropertiesCount => KnownProperties.Length + this.JsonAdditionalPropertiesCount;
            public int JsonAdditionalPropertiesCount
            {
                get
                {
                    Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                    int count = 0;

                    while (enumerator.MoveNext())
                    {
                        count++;
                    }

                    return count;
                }
            }
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator JsonAdditionalProperties
            {
                get
                {
                    if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonAny> ap)
                    {
                        return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(ap, KnownProperties);
                    }

                    if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
                    {
                        return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(this.JsonElement, KnownProperties);
                    }

                    return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(Menes.JsonProperties<Menes.JsonAny>.Empty, KnownProperties);
                }
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
            }
            public static TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity(property)
                        : Null)
                    : Null;
            public static TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity(property)
                        : Null)
                    : Null;
            public static TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity(property)
                        : Null)
                : Null;
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity ReplaceAll(Menes.JsonProperties<Menes.JsonAny> newAdditional)
            {
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity(newAdditional);
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity ReplaceAll(params (string, Menes.JsonAny)[] newAdditional)
            {
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity ReplaceAll((string, Menes.JsonAny) newAdditional1)
            {
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
            {
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
            {
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
            {
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity Add(params (string, Menes.JsonAny)[] newAdditional)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                foreach ((string name, Menes.JsonAny value) in newAdditional)
                {
                    arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(name, value));
                }
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity Add((string name, Menes.JsonAny value) newAdditional1)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3, (string name, Menes.JsonAny value) newAdditional4)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional4.name, newAdditional4.value)); return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity Remove(params string[] namesToRemove)
            {
                System.Collections.Immutable.ImmutableHashSet<string> ihs = System.Collections.Immutable.ImmutableHashSet.Create<string>(namesToRemove);
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity Remove(string itemToRemove1)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity Remove(string itemToRemove1, string itemToRemove2)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3, string itemToRemove4)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); ihsBuilder.Add(itemToRemove4); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity Remove(System.Predicate<Menes.JsonPropertyReference<Menes.JsonAny>> removeIfTrue)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!removeIfTrue(property))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                }
                else
                {
                    writer.WriteStartObject();
                    Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                    while (enumerator.MoveNext())
                    {
                        enumerator.Current.Write(writer);
                    }
                    writer.WriteEndObject();
                }
            }
            public bool Equals(TestSchema.ItemsValidationItem1Array.ItemsValidationItem1Entity other)
            {
                if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
                {
                    return false;
                }
                if (this.HasJsonElement && other.HasJsonElement)
                {
                    return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
                }
                return System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                if (this.IsNull)
                {
                    return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}");
                }
                if (this.HasJsonElement && !IsConvertibleFrom(this.JsonElement))
                {
                    return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}");
                }
                Menes.ValidationContext context = validationContext;
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    string propertyName = property.Name;
                    context = Menes.Validation.ValidateProperty(context, property.AsValue(), "." + property.Name);
                }
                if (this.HasJsonElement && IsConvertibleFrom(this.JsonElement))
                {
                    if (!this.TryGet("foo", out var _))
                    {
                        context = context.WithError("6.5.3.required: The property was not present.");
                    }
                }
                return context;
            }
            public bool TryGet(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
            {
                return this.TryGet(System.MemoryExtensions.AsSpan(propertyName), out value);
            }
            public bool TryGet(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
            {
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (property.NameEquals(utf8PropertyName))
                    {
                        value = property.AsValue();
                        return true;
                    }
                }
                value = default;
                return false;
            }
            public bool TryGet(System.ReadOnlySpan<char> propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
            {
                System.Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
                int written = System.Text.Encoding.UTF8.GetBytes(propertyName, bytes);
                return this.TryGet(bytes.Slice(0, written), out value);
            }
            public override string ToString()
            {
                return Menes.JsonAny.From(this).ToString();
            }
            private Menes.JsonProperties<Menes.JsonAny> GetJsonProperties()
            {
                if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonAny> props)
                {
                    return props;
                }
                return new Menes.JsonProperties<Menes.JsonAny>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.JsonAdditionalProperties));
            }
        }

        public readonly struct ItemsValidationItem2Entity : Menes.IJsonObject, System.IEquatable<TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
        {
            public static readonly TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity Null = new TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity> FromJsonElement = e => new TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity(e);
            private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>>.Empty;
            private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
            public ItemsValidationItem2Entity(System.Text.Json.JsonElement jsonElement)
            {
                this.JsonElement = jsonElement;
                this.additionalPropertiesBacking = null;
            }
            public ItemsValidationItem2Entity(params (string, Menes.JsonAny)[] additionalPropertiesBacking)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
            }
            public ItemsValidationItem2Entity((string, Menes.JsonAny) additionalProperty1)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
            }
            public ItemsValidationItem2Entity((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
            }
            public ItemsValidationItem2Entity((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
            }
            public ItemsValidationItem2Entity((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
            }
            private ItemsValidationItem2Entity(Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = additionalPropertiesBacking;
            }
            public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity? AsOptional => this.IsNull ? default(TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity?) : this;
            public int PropertiesCount => KnownProperties.Length + this.JsonAdditionalPropertiesCount;
            public int JsonAdditionalPropertiesCount
            {
                get
                {
                    Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                    int count = 0;

                    while (enumerator.MoveNext())
                    {
                        count++;
                    }

                    return count;
                }
            }
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator JsonAdditionalProperties
            {
                get
                {
                    if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonAny> ap)
                    {
                        return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(ap, KnownProperties);
                    }

                    if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
                    {
                        return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(this.JsonElement, KnownProperties);
                    }

                    return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(Menes.JsonProperties<Menes.JsonAny>.Empty, KnownProperties);
                }
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
            }
            public static TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity(property)
                        : Null)
                    : Null;
            public static TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity(property)
                        : Null)
                    : Null;
            public static TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity(property)
                        : Null)
                : Null;
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity ReplaceAll(Menes.JsonProperties<Menes.JsonAny> newAdditional)
            {
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity(newAdditional);
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity ReplaceAll(params (string, Menes.JsonAny)[] newAdditional)
            {
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity ReplaceAll((string, Menes.JsonAny) newAdditional1)
            {
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
            {
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
            {
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
            {
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity Add(params (string, Menes.JsonAny)[] newAdditional)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                foreach ((string name, Menes.JsonAny value) in newAdditional)
                {
                    arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(name, value));
                }
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity Add((string name, Menes.JsonAny value) newAdditional1)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3, (string name, Menes.JsonAny value) newAdditional4)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional4.name, newAdditional4.value)); return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity Remove(params string[] namesToRemove)
            {
                System.Collections.Immutable.ImmutableHashSet<string> ihs = System.Collections.Immutable.ImmutableHashSet.Create<string>(namesToRemove);
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity Remove(string itemToRemove1)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity Remove(string itemToRemove1, string itemToRemove2)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3, string itemToRemove4)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); ihsBuilder.Add(itemToRemove4); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity Remove(System.Predicate<Menes.JsonPropertyReference<Menes.JsonAny>> removeIfTrue)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!removeIfTrue(property))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                }
                else
                {
                    writer.WriteStartObject();
                    Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                    while (enumerator.MoveNext())
                    {
                        enumerator.Current.Write(writer);
                    }
                    writer.WriteEndObject();
                }
            }
            public bool Equals(TestSchema.ItemsValidationItem1Array.ItemsValidationItem2Entity other)
            {
                if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
                {
                    return false;
                }
                if (this.HasJsonElement && other.HasJsonElement)
                {
                    return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
                }
                return System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                if (this.IsNull)
                {
                    return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}");
                }
                if (this.HasJsonElement && !IsConvertibleFrom(this.JsonElement))
                {
                    return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}");
                }
                Menes.ValidationContext context = validationContext;
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    string propertyName = property.Name;
                    context = Menes.Validation.ValidateProperty(context, property.AsValue(), "." + property.Name);
                }
                if (this.HasJsonElement && IsConvertibleFrom(this.JsonElement))
                {
                    if (!this.TryGet("foo", out var _))
                    {
                        context = context.WithError("6.5.3.required: The property was not present.");
                    }
                }
                return context;
            }
            public bool TryGet(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
            {
                return this.TryGet(System.MemoryExtensions.AsSpan(propertyName), out value);
            }
            public bool TryGet(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
            {
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (property.NameEquals(utf8PropertyName))
                    {
                        value = property.AsValue();
                        return true;
                    }
                }
                value = default;
                return false;
            }
            public bool TryGet(System.ReadOnlySpan<char> propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
            {
                System.Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
                int written = System.Text.Encoding.UTF8.GetBytes(propertyName, bytes);
                return this.TryGet(bytes.Slice(0, written), out value);
            }
            public override string ToString()
            {
                return Menes.JsonAny.From(this).ToString();
            }
            private Menes.JsonProperties<Menes.JsonAny> GetJsonProperties()
            {
                if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonAny> props)
                {
                    return props;
                }
                return new Menes.JsonProperties<Menes.JsonAny>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.JsonAdditionalProperties));
            }
        }
    }
    public readonly struct ItemsValidationItem2Array : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.IEquatable<ItemsValidationItem2Array>, System.IEquatable<Menes.JsonArray<Menes.JsonAny>>
    {
        public static readonly System.Func<System.Text.Json.JsonElement, ItemsValidationItem2Array> FromJsonElement = e => new ItemsValidationItem2Array(e);
        public static readonly ItemsValidationItem2Array Null = new ItemsValidationItem2Array(default(System.Text.Json.JsonElement));
        private readonly Menes.JsonArray<Menes.JsonAny>? value;
        public ItemsValidationItem2Array(Menes.JsonArray<Menes.JsonAny> jsonArray)
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
        public ItemsValidationItem2Array(System.Text.Json.JsonElement jsonElement)
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
        public ItemsValidationItem2Array? AsOptional => this.IsNull ? default(ItemsValidationItem2Array?) : this;
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static implicit operator ItemsValidationItem2Array(Menes.JsonArray<Menes.JsonAny> value)
        {
            return new ItemsValidationItem2Array(value);
        }
        public static implicit operator Menes.JsonArray<Menes.JsonAny>(ItemsValidationItem2Array value)
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
        public static ItemsValidationItem2Array FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new ItemsValidationItem2Array(property)
                    : Null)
                : Null;
        public static ItemsValidationItem2Array FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new ItemsValidationItem2Array(property)
                    : Null)
                : Null;
        public static ItemsValidationItem2Array FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new ItemsValidationItem2Array(property)
                    : Null)
                : Null;
        public bool Equals(ItemsValidationItem2Array other)
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
            context = array.Validate(context);
            var itemsValidationEnumerator = array.GetEnumerator();
            if (itemsValidationEnumerator.MoveNext())
            {
                context = Menes.Validation.ValidateProperty(context, Menes.JsonAny.From(itemsValidationEnumerator.Current).As<TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity>(), $"[0]");
            }
            if (itemsValidationEnumerator.MoveNext())
            {
                context = Menes.Validation.ValidateProperty(context, Menes.JsonAny.From(itemsValidationEnumerator.Current).As<TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity>(), $"[1]");
            }
            if (itemsValidationEnumerator.MoveNext())
            {
                context = context.WithError($"core 9.3.1.1. items: The array should have contained 2 items but actually contained {array.Length} items.");
            }
            context = array.ValidateItems(context);
            return context;
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
        public ItemsValidationItem2Array Add(params Menes.JsonAny[] items)
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
        public ItemsValidationItem2Array Add(in Menes.JsonAny item1)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            foreach (Menes.JsonAny item in this)
            {
                arrayBuilder.Add(item);
            }
            arrayBuilder.Add(item1);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public ItemsValidationItem2Array Add(in Menes.JsonAny item1, in Menes.JsonAny item2)
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
        public ItemsValidationItem2Array Add(in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3)
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
        public ItemsValidationItem2Array Add(in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3, in Menes.JsonAny item4)
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
        public ItemsValidationItem2Array Insert(int indexToInsert, params Menes.JsonAny[] items)
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
        public ItemsValidationItem2Array Insert(int indexToInsert, in Menes.JsonAny item1)
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
        public ItemsValidationItem2Array Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2)
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
        public ItemsValidationItem2Array Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3)
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
        public ItemsValidationItem2Array Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3, in Menes.JsonAny item4)
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
        public ItemsValidationItem2Array Remove(params Menes.JsonAny[] items)
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
        public ItemsValidationItem2Array Remove(Menes.JsonAny item1)
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
        public ItemsValidationItem2Array Remove(Menes.JsonAny item1, Menes.JsonAny item2)
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
        public ItemsValidationItem2Array Remove(Menes.JsonAny item1, Menes.JsonAny item2, Menes.JsonAny item3)
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
        public ItemsValidationItem2Array Remove(Menes.JsonAny item1, Menes.JsonAny item2, Menes.JsonAny item3, Menes.JsonAny item4)
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
        public ItemsValidationItem2Array RemoveAt(int indexToRemove)
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
        public ItemsValidationItem2Array RemoveRange(int startIndex, int length)
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
        public ItemsValidationItem2Array Remove(System.Predicate<Menes.JsonAny> removeIfTrue)
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

        public readonly struct ItemsValidationItem1Entity : Menes.IJsonObject, System.IEquatable<TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
        {
            public static readonly TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity Null = new TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity> FromJsonElement = e => new TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity(e);
            private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>>.Empty;
            private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
            public ItemsValidationItem1Entity(System.Text.Json.JsonElement jsonElement)
            {
                this.JsonElement = jsonElement;
                this.additionalPropertiesBacking = null;
            }
            public ItemsValidationItem1Entity(params (string, Menes.JsonAny)[] additionalPropertiesBacking)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
            }
            public ItemsValidationItem1Entity((string, Menes.JsonAny) additionalProperty1)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
            }
            public ItemsValidationItem1Entity((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
            }
            public ItemsValidationItem1Entity((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
            }
            public ItemsValidationItem1Entity((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
            }
            private ItemsValidationItem1Entity(Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = additionalPropertiesBacking;
            }
            public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity? AsOptional => this.IsNull ? default(TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity?) : this;
            public int PropertiesCount => KnownProperties.Length + this.JsonAdditionalPropertiesCount;
            public int JsonAdditionalPropertiesCount
            {
                get
                {
                    Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                    int count = 0;

                    while (enumerator.MoveNext())
                    {
                        count++;
                    }

                    return count;
                }
            }
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator JsonAdditionalProperties
            {
                get
                {
                    if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonAny> ap)
                    {
                        return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(ap, KnownProperties);
                    }

                    if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
                    {
                        return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(this.JsonElement, KnownProperties);
                    }

                    return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(Menes.JsonProperties<Menes.JsonAny>.Empty, KnownProperties);
                }
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
            }
            public static TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity(property)
                        : Null)
                    : Null;
            public static TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity(property)
                        : Null)
                    : Null;
            public static TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity(property)
                        : Null)
                : Null;
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity ReplaceAll(Menes.JsonProperties<Menes.JsonAny> newAdditional)
            {
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity(newAdditional);
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity ReplaceAll(params (string, Menes.JsonAny)[] newAdditional)
            {
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity ReplaceAll((string, Menes.JsonAny) newAdditional1)
            {
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
            {
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
            {
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
            {
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity Add(params (string, Menes.JsonAny)[] newAdditional)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                foreach ((string name, Menes.JsonAny value) in newAdditional)
                {
                    arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(name, value));
                }
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity Add((string name, Menes.JsonAny value) newAdditional1)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3, (string name, Menes.JsonAny value) newAdditional4)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional4.name, newAdditional4.value)); return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity Remove(params string[] namesToRemove)
            {
                System.Collections.Immutable.ImmutableHashSet<string> ihs = System.Collections.Immutable.ImmutableHashSet.Create<string>(namesToRemove);
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity Remove(string itemToRemove1)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity Remove(string itemToRemove1, string itemToRemove2)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3, string itemToRemove4)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); ihsBuilder.Add(itemToRemove4); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity Remove(System.Predicate<Menes.JsonPropertyReference<Menes.JsonAny>> removeIfTrue)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!removeIfTrue(property))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                }
                else
                {
                    writer.WriteStartObject();
                    Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                    while (enumerator.MoveNext())
                    {
                        enumerator.Current.Write(writer);
                    }
                    writer.WriteEndObject();
                }
            }
            public bool Equals(TestSchema.ItemsValidationItem2Array.ItemsValidationItem1Entity other)
            {
                if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
                {
                    return false;
                }
                if (this.HasJsonElement && other.HasJsonElement)
                {
                    return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
                }
                return System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                if (this.IsNull)
                {
                    return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}");
                }
                if (this.HasJsonElement && !IsConvertibleFrom(this.JsonElement))
                {
                    return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}");
                }
                Menes.ValidationContext context = validationContext;
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    string propertyName = property.Name;
                    context = Menes.Validation.ValidateProperty(context, property.AsValue(), "." + property.Name);
                }
                if (this.HasJsonElement && IsConvertibleFrom(this.JsonElement))
                {
                    if (!this.TryGet("foo", out var _))
                    {
                        context = context.WithError("6.5.3.required: The property was not present.");
                    }
                }
                return context;
            }
            public bool TryGet(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
            {
                return this.TryGet(System.MemoryExtensions.AsSpan(propertyName), out value);
            }
            public bool TryGet(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
            {
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (property.NameEquals(utf8PropertyName))
                    {
                        value = property.AsValue();
                        return true;
                    }
                }
                value = default;
                return false;
            }
            public bool TryGet(System.ReadOnlySpan<char> propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
            {
                System.Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
                int written = System.Text.Encoding.UTF8.GetBytes(propertyName, bytes);
                return this.TryGet(bytes.Slice(0, written), out value);
            }
            public override string ToString()
            {
                return Menes.JsonAny.From(this).ToString();
            }
            private Menes.JsonProperties<Menes.JsonAny> GetJsonProperties()
            {
                if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonAny> props)
                {
                    return props;
                }
                return new Menes.JsonProperties<Menes.JsonAny>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.JsonAdditionalProperties));
            }
        }

        public readonly struct ItemsValidationItem2Entity : Menes.IJsonObject, System.IEquatable<TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
        {
            public static readonly TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity Null = new TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity> FromJsonElement = e => new TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity(e);
            private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>>.Empty;
            private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
            public ItemsValidationItem2Entity(System.Text.Json.JsonElement jsonElement)
            {
                this.JsonElement = jsonElement;
                this.additionalPropertiesBacking = null;
            }
            public ItemsValidationItem2Entity(params (string, Menes.JsonAny)[] additionalPropertiesBacking)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
            }
            public ItemsValidationItem2Entity((string, Menes.JsonAny) additionalProperty1)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
            }
            public ItemsValidationItem2Entity((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
            }
            public ItemsValidationItem2Entity((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
            }
            public ItemsValidationItem2Entity((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
            }
            private ItemsValidationItem2Entity(Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = additionalPropertiesBacking;
            }
            public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity? AsOptional => this.IsNull ? default(TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity?) : this;
            public int PropertiesCount => KnownProperties.Length + this.JsonAdditionalPropertiesCount;
            public int JsonAdditionalPropertiesCount
            {
                get
                {
                    Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                    int count = 0;

                    while (enumerator.MoveNext())
                    {
                        count++;
                    }

                    return count;
                }
            }
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator JsonAdditionalProperties
            {
                get
                {
                    if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonAny> ap)
                    {
                        return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(ap, KnownProperties);
                    }

                    if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
                    {
                        return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(this.JsonElement, KnownProperties);
                    }

                    return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(Menes.JsonProperties<Menes.JsonAny>.Empty, KnownProperties);
                }
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
            }
            public static TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity(property)
                        : Null)
                    : Null;
            public static TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity(property)
                        : Null)
                    : Null;
            public static TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity(property)
                        : Null)
                : Null;
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity ReplaceAll(Menes.JsonProperties<Menes.JsonAny> newAdditional)
            {
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity(newAdditional);
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity ReplaceAll(params (string, Menes.JsonAny)[] newAdditional)
            {
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity ReplaceAll((string, Menes.JsonAny) newAdditional1)
            {
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
            {
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
            {
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
            {
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity Add(params (string, Menes.JsonAny)[] newAdditional)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                foreach ((string name, Menes.JsonAny value) in newAdditional)
                {
                    arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(name, value));
                }
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity Add((string name, Menes.JsonAny value) newAdditional1)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3, (string name, Menes.JsonAny value) newAdditional4)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional4.name, newAdditional4.value)); return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity Remove(params string[] namesToRemove)
            {
                System.Collections.Immutable.ImmutableHashSet<string> ihs = System.Collections.Immutable.ImmutableHashSet.Create<string>(namesToRemove);
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity Remove(string itemToRemove1)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity Remove(string itemToRemove1, string itemToRemove2)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3, string itemToRemove4)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); ihsBuilder.Add(itemToRemove4); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity Remove(System.Predicate<Menes.JsonPropertyReference<Menes.JsonAny>> removeIfTrue)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!removeIfTrue(property))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                }
                else
                {
                    writer.WriteStartObject();
                    Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                    while (enumerator.MoveNext())
                    {
                        enumerator.Current.Write(writer);
                    }
                    writer.WriteEndObject();
                }
            }
            public bool Equals(TestSchema.ItemsValidationItem2Array.ItemsValidationItem2Entity other)
            {
                if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
                {
                    return false;
                }
                if (this.HasJsonElement && other.HasJsonElement)
                {
                    return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
                }
                return System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                if (this.IsNull)
                {
                    return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}");
                }
                if (this.HasJsonElement && !IsConvertibleFrom(this.JsonElement))
                {
                    return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}");
                }
                Menes.ValidationContext context = validationContext;
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    string propertyName = property.Name;
                    context = Menes.Validation.ValidateProperty(context, property.AsValue(), "." + property.Name);
                }
                if (this.HasJsonElement && IsConvertibleFrom(this.JsonElement))
                {
                    if (!this.TryGet("foo", out var _))
                    {
                        context = context.WithError("6.5.3.required: The property was not present.");
                    }
                }
                return context;
            }
            public bool TryGet(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
            {
                return this.TryGet(System.MemoryExtensions.AsSpan(propertyName), out value);
            }
            public bool TryGet(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
            {
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (property.NameEquals(utf8PropertyName))
                    {
                        value = property.AsValue();
                        return true;
                    }
                }
                value = default;
                return false;
            }
            public bool TryGet(System.ReadOnlySpan<char> propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
            {
                System.Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
                int written = System.Text.Encoding.UTF8.GetBytes(propertyName, bytes);
                return this.TryGet(bytes.Slice(0, written), out value);
            }
            public override string ToString()
            {
                return Menes.JsonAny.From(this).ToString();
            }
            private Menes.JsonProperties<Menes.JsonAny> GetJsonProperties()
            {
                if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonAny> props)
                {
                    return props;
                }
                return new Menes.JsonProperties<Menes.JsonAny>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.JsonAdditionalProperties));
            }
        }
    }
    public readonly struct ItemsValidationItem3Array : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.IEquatable<ItemsValidationItem3Array>, System.IEquatable<Menes.JsonArray<Menes.JsonAny>>
    {
        public static readonly System.Func<System.Text.Json.JsonElement, ItemsValidationItem3Array> FromJsonElement = e => new ItemsValidationItem3Array(e);
        public static readonly ItemsValidationItem3Array Null = new ItemsValidationItem3Array(default(System.Text.Json.JsonElement));
        private readonly Menes.JsonArray<Menes.JsonAny>? value;
        public ItemsValidationItem3Array(Menes.JsonArray<Menes.JsonAny> jsonArray)
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
        public ItemsValidationItem3Array(System.Text.Json.JsonElement jsonElement)
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
        public ItemsValidationItem3Array? AsOptional => this.IsNull ? default(ItemsValidationItem3Array?) : this;
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static implicit operator ItemsValidationItem3Array(Menes.JsonArray<Menes.JsonAny> value)
        {
            return new ItemsValidationItem3Array(value);
        }
        public static implicit operator Menes.JsonArray<Menes.JsonAny>(ItemsValidationItem3Array value)
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
        public static ItemsValidationItem3Array FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new ItemsValidationItem3Array(property)
                    : Null)
                : Null;
        public static ItemsValidationItem3Array FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new ItemsValidationItem3Array(property)
                    : Null)
                : Null;
        public static ItemsValidationItem3Array FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new ItemsValidationItem3Array(property)
                    : Null)
                : Null;
        public bool Equals(ItemsValidationItem3Array other)
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
            context = array.Validate(context);
            var itemsValidationEnumerator = array.GetEnumerator();
            if (itemsValidationEnumerator.MoveNext())
            {
                context = Menes.Validation.ValidateProperty(context, Menes.JsonAny.From(itemsValidationEnumerator.Current).As<TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity>(), $"[0]");
            }
            if (itemsValidationEnumerator.MoveNext())
            {
                context = Menes.Validation.ValidateProperty(context, Menes.JsonAny.From(itemsValidationEnumerator.Current).As<TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity>(), $"[1]");
            }
            if (itemsValidationEnumerator.MoveNext())
            {
                context = context.WithError($"core 9.3.1.1. items: The array should have contained 2 items but actually contained {array.Length} items.");
            }
            context = array.ValidateItems(context);
            return context;
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
        public ItemsValidationItem3Array Add(params Menes.JsonAny[] items)
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
        public ItemsValidationItem3Array Add(in Menes.JsonAny item1)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            foreach (Menes.JsonAny item in this)
            {
                arrayBuilder.Add(item);
            }
            arrayBuilder.Add(item1);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public ItemsValidationItem3Array Add(in Menes.JsonAny item1, in Menes.JsonAny item2)
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
        public ItemsValidationItem3Array Add(in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3)
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
        public ItemsValidationItem3Array Add(in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3, in Menes.JsonAny item4)
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
        public ItemsValidationItem3Array Insert(int indexToInsert, params Menes.JsonAny[] items)
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
        public ItemsValidationItem3Array Insert(int indexToInsert, in Menes.JsonAny item1)
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
        public ItemsValidationItem3Array Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2)
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
        public ItemsValidationItem3Array Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3)
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
        public ItemsValidationItem3Array Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3, in Menes.JsonAny item4)
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
        public ItemsValidationItem3Array Remove(params Menes.JsonAny[] items)
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
        public ItemsValidationItem3Array Remove(Menes.JsonAny item1)
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
        public ItemsValidationItem3Array Remove(Menes.JsonAny item1, Menes.JsonAny item2)
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
        public ItemsValidationItem3Array Remove(Menes.JsonAny item1, Menes.JsonAny item2, Menes.JsonAny item3)
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
        public ItemsValidationItem3Array Remove(Menes.JsonAny item1, Menes.JsonAny item2, Menes.JsonAny item3, Menes.JsonAny item4)
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
        public ItemsValidationItem3Array RemoveAt(int indexToRemove)
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
        public ItemsValidationItem3Array RemoveRange(int startIndex, int length)
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
        public ItemsValidationItem3Array Remove(System.Predicate<Menes.JsonAny> removeIfTrue)
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

        public readonly struct ItemsValidationItem1Entity : Menes.IJsonObject, System.IEquatable<TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
        {
            public static readonly TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity Null = new TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity> FromJsonElement = e => new TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity(e);
            private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>>.Empty;
            private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
            public ItemsValidationItem1Entity(System.Text.Json.JsonElement jsonElement)
            {
                this.JsonElement = jsonElement;
                this.additionalPropertiesBacking = null;
            }
            public ItemsValidationItem1Entity(params (string, Menes.JsonAny)[] additionalPropertiesBacking)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
            }
            public ItemsValidationItem1Entity((string, Menes.JsonAny) additionalProperty1)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
            }
            public ItemsValidationItem1Entity((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
            }
            public ItemsValidationItem1Entity((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
            }
            public ItemsValidationItem1Entity((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
            }
            private ItemsValidationItem1Entity(Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = additionalPropertiesBacking;
            }
            public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity? AsOptional => this.IsNull ? default(TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity?) : this;
            public int PropertiesCount => KnownProperties.Length + this.JsonAdditionalPropertiesCount;
            public int JsonAdditionalPropertiesCount
            {
                get
                {
                    Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                    int count = 0;

                    while (enumerator.MoveNext())
                    {
                        count++;
                    }

                    return count;
                }
            }
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator JsonAdditionalProperties
            {
                get
                {
                    if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonAny> ap)
                    {
                        return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(ap, KnownProperties);
                    }

                    if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
                    {
                        return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(this.JsonElement, KnownProperties);
                    }

                    return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(Menes.JsonProperties<Menes.JsonAny>.Empty, KnownProperties);
                }
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
            }
            public static TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity(property)
                        : Null)
                    : Null;
            public static TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity(property)
                        : Null)
                    : Null;
            public static TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity(property)
                        : Null)
                : Null;
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity ReplaceAll(Menes.JsonProperties<Menes.JsonAny> newAdditional)
            {
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity(newAdditional);
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity ReplaceAll(params (string, Menes.JsonAny)[] newAdditional)
            {
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity ReplaceAll((string, Menes.JsonAny) newAdditional1)
            {
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
            {
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
            {
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
            {
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity Add(params (string, Menes.JsonAny)[] newAdditional)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                foreach ((string name, Menes.JsonAny value) in newAdditional)
                {
                    arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(name, value));
                }
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity Add((string name, Menes.JsonAny value) newAdditional1)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3, (string name, Menes.JsonAny value) newAdditional4)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional4.name, newAdditional4.value)); return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity Remove(params string[] namesToRemove)
            {
                System.Collections.Immutable.ImmutableHashSet<string> ihs = System.Collections.Immutable.ImmutableHashSet.Create<string>(namesToRemove);
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity Remove(string itemToRemove1)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity Remove(string itemToRemove1, string itemToRemove2)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3, string itemToRemove4)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); ihsBuilder.Add(itemToRemove4); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity Remove(System.Predicate<Menes.JsonPropertyReference<Menes.JsonAny>> removeIfTrue)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!removeIfTrue(property))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                }
                else
                {
                    writer.WriteStartObject();
                    Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                    while (enumerator.MoveNext())
                    {
                        enumerator.Current.Write(writer);
                    }
                    writer.WriteEndObject();
                }
            }
            public bool Equals(TestSchema.ItemsValidationItem3Array.ItemsValidationItem1Entity other)
            {
                if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
                {
                    return false;
                }
                if (this.HasJsonElement && other.HasJsonElement)
                {
                    return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
                }
                return System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                if (this.IsNull)
                {
                    return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}");
                }
                if (this.HasJsonElement && !IsConvertibleFrom(this.JsonElement))
                {
                    return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}");
                }
                Menes.ValidationContext context = validationContext;
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    string propertyName = property.Name;
                    context = Menes.Validation.ValidateProperty(context, property.AsValue(), "." + property.Name);
                }
                if (this.HasJsonElement && IsConvertibleFrom(this.JsonElement))
                {
                    if (!this.TryGet("foo", out var _))
                    {
                        context = context.WithError("6.5.3.required: The property was not present.");
                    }
                }
                return context;
            }
            public bool TryGet(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
            {
                return this.TryGet(System.MemoryExtensions.AsSpan(propertyName), out value);
            }
            public bool TryGet(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
            {
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (property.NameEquals(utf8PropertyName))
                    {
                        value = property.AsValue();
                        return true;
                    }
                }
                value = default;
                return false;
            }
            public bool TryGet(System.ReadOnlySpan<char> propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
            {
                System.Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
                int written = System.Text.Encoding.UTF8.GetBytes(propertyName, bytes);
                return this.TryGet(bytes.Slice(0, written), out value);
            }
            public override string ToString()
            {
                return Menes.JsonAny.From(this).ToString();
            }
            private Menes.JsonProperties<Menes.JsonAny> GetJsonProperties()
            {
                if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonAny> props)
                {
                    return props;
                }
                return new Menes.JsonProperties<Menes.JsonAny>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.JsonAdditionalProperties));
            }
        }

        public readonly struct ItemsValidationItem2Entity : Menes.IJsonObject, System.IEquatable<TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
        {
            public static readonly TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity Null = new TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity> FromJsonElement = e => new TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity(e);
            private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>>.Empty;
            private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
            public ItemsValidationItem2Entity(System.Text.Json.JsonElement jsonElement)
            {
                this.JsonElement = jsonElement;
                this.additionalPropertiesBacking = null;
            }
            public ItemsValidationItem2Entity(params (string, Menes.JsonAny)[] additionalPropertiesBacking)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
            }
            public ItemsValidationItem2Entity((string, Menes.JsonAny) additionalProperty1)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
            }
            public ItemsValidationItem2Entity((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
            }
            public ItemsValidationItem2Entity((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
            }
            public ItemsValidationItem2Entity((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
            }
            private ItemsValidationItem2Entity(Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = additionalPropertiesBacking;
            }
            public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity? AsOptional => this.IsNull ? default(TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity?) : this;
            public int PropertiesCount => KnownProperties.Length + this.JsonAdditionalPropertiesCount;
            public int JsonAdditionalPropertiesCount
            {
                get
                {
                    Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                    int count = 0;

                    while (enumerator.MoveNext())
                    {
                        count++;
                    }

                    return count;
                }
            }
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator JsonAdditionalProperties
            {
                get
                {
                    if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonAny> ap)
                    {
                        return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(ap, KnownProperties);
                    }

                    if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
                    {
                        return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(this.JsonElement, KnownProperties);
                    }

                    return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(Menes.JsonProperties<Menes.JsonAny>.Empty, KnownProperties);
                }
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
            }
            public static TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity(property)
                        : Null)
                    : Null;
            public static TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity(property)
                        : Null)
                    : Null;
            public static TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity(property)
                        : Null)
                : Null;
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity ReplaceAll(Menes.JsonProperties<Menes.JsonAny> newAdditional)
            {
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity(newAdditional);
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity ReplaceAll(params (string, Menes.JsonAny)[] newAdditional)
            {
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity ReplaceAll((string, Menes.JsonAny) newAdditional1)
            {
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
            {
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
            {
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
            {
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity Add(params (string, Menes.JsonAny)[] newAdditional)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                foreach ((string name, Menes.JsonAny value) in newAdditional)
                {
                    arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(name, value));
                }
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity Add((string name, Menes.JsonAny value) newAdditional1)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3, (string name, Menes.JsonAny value) newAdditional4)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional4.name, newAdditional4.value)); return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity Remove(params string[] namesToRemove)
            {
                System.Collections.Immutable.ImmutableHashSet<string> ihs = System.Collections.Immutable.ImmutableHashSet.Create<string>(namesToRemove);
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity Remove(string itemToRemove1)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity Remove(string itemToRemove1, string itemToRemove2)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3, string itemToRemove4)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); ihsBuilder.Add(itemToRemove4); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity Remove(System.Predicate<Menes.JsonPropertyReference<Menes.JsonAny>> removeIfTrue)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (!removeIfTrue(property))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
            }
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                }
                else
                {
                    writer.WriteStartObject();
                    Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                    while (enumerator.MoveNext())
                    {
                        enumerator.Current.Write(writer);
                    }
                    writer.WriteEndObject();
                }
            }
            public bool Equals(TestSchema.ItemsValidationItem3Array.ItemsValidationItem2Entity other)
            {
                if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
                {
                    return false;
                }
                if (this.HasJsonElement && other.HasJsonElement)
                {
                    return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
                }
                return System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                if (this.IsNull)
                {
                    return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}");
                }
                if (this.HasJsonElement && !IsConvertibleFrom(this.JsonElement))
                {
                    return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}");
                }
                Menes.ValidationContext context = validationContext;
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    string propertyName = property.Name;
                    context = Menes.Validation.ValidateProperty(context, property.AsValue(), "." + property.Name);
                }
                if (this.HasJsonElement && IsConvertibleFrom(this.JsonElement))
                {
                    if (!this.TryGet("foo", out var _))
                    {
                        context = context.WithError("6.5.3.required: The property was not present.");
                    }
                }
                return context;
            }
            public bool TryGet(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
            {
                return this.TryGet(System.MemoryExtensions.AsSpan(propertyName), out value);
            }
            public bool TryGet(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
            {
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    if (property.NameEquals(utf8PropertyName))
                    {
                        value = property.AsValue();
                        return true;
                    }
                }
                value = default;
                return false;
            }
            public bool TryGet(System.ReadOnlySpan<char> propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
            {
                System.Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
                int written = System.Text.Encoding.UTF8.GetBytes(propertyName, bytes);
                return this.TryGet(bytes.Slice(0, written), out value);
            }
            public override string ToString()
            {
                return Menes.JsonAny.From(this).ToString();
            }
            private Menes.JsonProperties<Menes.JsonAny> GetJsonProperties()
            {
                if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonAny> props)
                {
                    return props;
                }
                return new Menes.JsonProperties<Menes.JsonAny>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.JsonAdditionalProperties));
            }
        }
    }
}
///  <summary>
/// items and subitems
/// </summary>
public static class Tests
{
/// <summary>
/// valid items
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[\r\n                    [ {\"foo\": null}, {\"foo\": null} ],\r\n                    [ {\"foo\": null}, {\"foo\": null} ],\r\n                    [ {\"foo\": null}, {\"foo\": null} ]\r\n                ]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Items005.Tests.Test0: valid items");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// too many items
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[\r\n                    [ {\"foo\": null}, {\"foo\": null} ],\r\n                    [ {\"foo\": null}, {\"foo\": null} ],\r\n                    [ {\"foo\": null}, {\"foo\": null} ],\r\n                    [ {\"foo\": null}, {\"foo\": null} ]\r\n                ]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Items005.Tests.Test1: too many items");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// too many sub-items
/// </summary>
    public static bool Test2()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[\r\n                    [ {\"foo\": null}, {\"foo\": null}, {\"foo\": null} ],\r\n                    [ {\"foo\": null}, {\"foo\": null} ],\r\n                    [ {\"foo\": null}, {\"foo\": null} ]\r\n                ]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Items005.Tests.Test2: too many sub-items");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// wrong item
/// </summary>
    public static bool Test3()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[\r\n                    {\"foo\": null},\r\n                    [ {\"foo\": null}, {\"foo\": null} ],\r\n                    [ {\"foo\": null}, {\"foo\": null} ]\r\n                ]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Items005.Tests.Test3: wrong item");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// wrong sub-item
/// </summary>
    public static bool Test4()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[\r\n                    [ {}, {\"foo\": null} ],\r\n                    [ {\"foo\": null}, {\"foo\": null} ],\r\n                    [ {\"foo\": null}, {\"foo\": null} ]\r\n                ]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Items005.Tests.Test4: wrong sub-item");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// fewer items is valid
/// </summary>
    public static bool Test5()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[\r\n                    [ {\"foo\": null} ],\r\n                    [ {\"foo\": null} ]\r\n                ]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Items005.Tests.Test5: fewer items is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
}
}