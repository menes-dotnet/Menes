// <copyright file="items006.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.Items006
{
public readonly struct Schema : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Schema.SchemaArray>, System.Collections.IEnumerable, System.IEquatable<Schema>, System.IEquatable<Menes.JsonArray<Schema.SchemaArray>>
{
    public static readonly System.Func<System.Text.Json.JsonElement, Schema> FromJsonElement = e => new Schema(e);
    public static readonly Schema Null = new Schema(default(System.Text.Json.JsonElement));
    private readonly Menes.JsonArray<Schema.SchemaArray>? value;
    public Schema(Menes.JsonArray<Schema.SchemaArray> jsonArray)
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
            if (this.value is Menes.JsonArray<Schema.SchemaArray> value)
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
    public static implicit operator Schema(Menes.JsonArray<Schema.SchemaArray> value)
    {
        return new Schema(value);
    }
    public static implicit operator Menes.JsonArray<Schema.SchemaArray>(Schema value)
    {
        if (value.value is Menes.JsonArray<Schema.SchemaArray> clrValue)
        {
            return clrValue;
        }
        return new Menes.JsonArray<Schema.SchemaArray>(value.JsonElement);
    }
    public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
    {
        return Menes.JsonArray<Schema.SchemaArray>.IsConvertibleFrom(jsonElement);
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
        return this.Equals((Menes.JsonArray<Schema.SchemaArray>)other);
    }
    public bool Equals(Menes.JsonArray<Schema.SchemaArray> other)
    {
        return ((Menes.JsonArray<Schema.SchemaArray>)this).Equals(other);
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        Menes.JsonArray<Schema.SchemaArray> array = this;
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
        if (this.value is Menes.JsonArray<Schema.SchemaArray> clrValue)
        {
            clrValue.WriteTo(writer);
        }
    }
    public Menes.JsonArray<Schema.SchemaArray>.JsonArrayEnumerator GetEnumerator()
    {
        return ((Menes.JsonArray<Schema.SchemaArray>)this).GetEnumerator();
    }
    System.Collections.Generic.IEnumerator<Schema.SchemaArray> System.Collections.Generic.IEnumerable<Schema.SchemaArray>.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    public Schema Add(params Schema.SchemaArray[] items)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray>();
        foreach (Schema.SchemaArray item in this)
        {
            arrayBuilder.Add(item);
        }
        foreach (Schema.SchemaArray item in items)
        {
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Add(in Schema.SchemaArray item1)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray>();
        foreach (Schema.SchemaArray item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Add(in Schema.SchemaArray item1, in Schema.SchemaArray item2)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray>();
        foreach (Schema.SchemaArray item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Add(in Schema.SchemaArray item1, in Schema.SchemaArray item2, in Schema.SchemaArray item3)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray>();
        foreach (Schema.SchemaArray item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        arrayBuilder.Add(item3);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Add(in Schema.SchemaArray item1, in Schema.SchemaArray item2, in Schema.SchemaArray item3, in Schema.SchemaArray item4)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray>();
        foreach (Schema.SchemaArray item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        arrayBuilder.Add(item3);
        arrayBuilder.Add(item4);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Insert(int indexToInsert, params Schema.SchemaArray[] items)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray>();
        int index = 0;
        foreach (Schema.SchemaArray item in this)
        {
            if (index == indexToInsert)
            {
                foreach (Schema.SchemaArray itemToInsert in items)
                {
                    arrayBuilder.Add(itemToInsert);
                }
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Insert(int indexToInsert, in Schema.SchemaArray item1)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray>();
        int index = 0;
        foreach (Schema.SchemaArray item in this)
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
    public Schema Insert(int indexToInsert, in Schema.SchemaArray item1, in Schema.SchemaArray item2)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray>();
        int index = 0;
        foreach (Schema.SchemaArray item in this)
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
    public Schema Insert(int indexToInsert, in Schema.SchemaArray item1, in Schema.SchemaArray item2, in Schema.SchemaArray item3)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray>();
        int index = 0;
        foreach (Schema.SchemaArray item in this)
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
    public Schema Insert(int indexToInsert, in Schema.SchemaArray item1, in Schema.SchemaArray item2, in Schema.SchemaArray item3, in Schema.SchemaArray item4)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray>();
        int index = 0;
        foreach (Schema.SchemaArray item in this)
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
    public Schema Remove(params Schema.SchemaArray[] items)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray>();
        foreach (Schema.SchemaArray item in this)
        {
            bool found = false;
            foreach (Schema.SchemaArray itemToRemove in items)
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
    public Schema Remove(Schema.SchemaArray item1)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray>();
        foreach (Schema.SchemaArray item in this)
        {
            if (item1.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Remove(Schema.SchemaArray item1, Schema.SchemaArray item2)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray>();
        foreach (Schema.SchemaArray item in this)
        {
            if (item1.Equals(item) || item2.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Remove(Schema.SchemaArray item1, Schema.SchemaArray item2, Schema.SchemaArray item3)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray>();
        foreach (Schema.SchemaArray item in this)
        {
            if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Remove(Schema.SchemaArray item1, Schema.SchemaArray item2, Schema.SchemaArray item3, Schema.SchemaArray item4)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray>();
        foreach (Schema.SchemaArray item in this)
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
        System.Collections.Immutable.ImmutableArray<Schema.SchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray>();
        int index = 0;
        foreach (Schema.SchemaArray item in this)
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
        System.Collections.Immutable.ImmutableArray<Schema.SchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray>();
        int index = 0;
        foreach (Schema.SchemaArray item in this)
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
    public Schema Remove(System.Predicate<Schema.SchemaArray> removeIfTrue)
    {
        System.Collections.Immutable.ImmutableArray<Schema.SchemaArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray>();
        foreach (Schema.SchemaArray item in this)
        {
            if (removeIfTrue(item))
            {
                continue;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public readonly struct SchemaArray : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Schema.SchemaArray.SchemaArrayArray>, System.Collections.IEnumerable, System.IEquatable<SchemaArray>, System.IEquatable<Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray>>
    {
        public static readonly System.Func<System.Text.Json.JsonElement, SchemaArray> FromJsonElement = e => new SchemaArray(e);
        public static readonly SchemaArray Null = new SchemaArray(default(System.Text.Json.JsonElement));
        private readonly Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray>? value;
        public SchemaArray(Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray> jsonArray)
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
        public SchemaArray(System.Text.Json.JsonElement jsonElement)
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
                if (this.value is Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray> value)
                {
                    return value.Length;
                }
                return 0;
            }
        }
        public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public SchemaArray? AsOptional => this.IsNull ? default(SchemaArray?) : this;
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static implicit operator SchemaArray(Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray> value)
        {
            return new SchemaArray(value);
        }
        public static implicit operator Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray>(SchemaArray value)
        {
            if (value.value is Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray> clrValue)
            {
                return clrValue;
            }
            return new Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray>(value.JsonElement);
        }
        public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
        {
            return Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray>.IsConvertibleFrom(jsonElement);
        }
        public static SchemaArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new SchemaArray(property)
                    : Null)
                : Null;
        public static SchemaArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new SchemaArray(property)
                    : Null)
                : Null;
        public static SchemaArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new SchemaArray(property)
                    : Null)
                : Null;
        public bool Equals(SchemaArray other)
        {
            return this.Equals((Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray>)other);
        }
        public bool Equals(Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray> other)
        {
            return ((Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray>)this).Equals(other);
        }
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
        {
            Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray> array = this;
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
            if (this.value is Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray> clrValue)
            {
                clrValue.WriteTo(writer);
            }
        }
        public Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray>.JsonArrayEnumerator GetEnumerator()
        {
            return ((Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray>)this).GetEnumerator();
        }
        System.Collections.Generic.IEnumerator<Schema.SchemaArray.SchemaArrayArray> System.Collections.Generic.IEnumerable<Schema.SchemaArray.SchemaArrayArray>.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public SchemaArray Add(params Schema.SchemaArray.SchemaArrayArray[] items)
        {
            System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray>();
            foreach (Schema.SchemaArray.SchemaArrayArray item in this)
            {
                arrayBuilder.Add(item);
            }
            foreach (Schema.SchemaArray.SchemaArrayArray item in items)
            {
                arrayBuilder.Add(item);
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public SchemaArray Add(in Schema.SchemaArray.SchemaArrayArray item1)
        {
            System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray>();
            foreach (Schema.SchemaArray.SchemaArrayArray item in this)
            {
                arrayBuilder.Add(item);
            }
            arrayBuilder.Add(item1);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public SchemaArray Add(in Schema.SchemaArray.SchemaArrayArray item1, in Schema.SchemaArray.SchemaArrayArray item2)
        {
            System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray>();
            foreach (Schema.SchemaArray.SchemaArrayArray item in this)
            {
                arrayBuilder.Add(item);
            }
            arrayBuilder.Add(item1);
            arrayBuilder.Add(item2);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public SchemaArray Add(in Schema.SchemaArray.SchemaArrayArray item1, in Schema.SchemaArray.SchemaArrayArray item2, in Schema.SchemaArray.SchemaArrayArray item3)
        {
            System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray>();
            foreach (Schema.SchemaArray.SchemaArrayArray item in this)
            {
                arrayBuilder.Add(item);
            }
            arrayBuilder.Add(item1);
            arrayBuilder.Add(item2);
            arrayBuilder.Add(item3);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public SchemaArray Add(in Schema.SchemaArray.SchemaArrayArray item1, in Schema.SchemaArray.SchemaArrayArray item2, in Schema.SchemaArray.SchemaArrayArray item3, in Schema.SchemaArray.SchemaArrayArray item4)
        {
            System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray>();
            foreach (Schema.SchemaArray.SchemaArrayArray item in this)
            {
                arrayBuilder.Add(item);
            }
            arrayBuilder.Add(item1);
            arrayBuilder.Add(item2);
            arrayBuilder.Add(item3);
            arrayBuilder.Add(item4);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public SchemaArray Insert(int indexToInsert, params Schema.SchemaArray.SchemaArrayArray[] items)
        {
            System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray>();
            int index = 0;
            foreach (Schema.SchemaArray.SchemaArrayArray item in this)
            {
                if (index == indexToInsert)
                {
                    foreach (Schema.SchemaArray.SchemaArrayArray itemToInsert in items)
                    {
                        arrayBuilder.Add(itemToInsert);
                    }
                }
                arrayBuilder.Add(item);
                ++index;
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public SchemaArray Insert(int indexToInsert, in Schema.SchemaArray.SchemaArrayArray item1)
        {
            System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray>();
            int index = 0;
            foreach (Schema.SchemaArray.SchemaArrayArray item in this)
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
        public SchemaArray Insert(int indexToInsert, in Schema.SchemaArray.SchemaArrayArray item1, in Schema.SchemaArray.SchemaArrayArray item2)
        {
            System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray>();
            int index = 0;
            foreach (Schema.SchemaArray.SchemaArrayArray item in this)
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
        public SchemaArray Insert(int indexToInsert, in Schema.SchemaArray.SchemaArrayArray item1, in Schema.SchemaArray.SchemaArrayArray item2, in Schema.SchemaArray.SchemaArrayArray item3)
        {
            System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray>();
            int index = 0;
            foreach (Schema.SchemaArray.SchemaArrayArray item in this)
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
        public SchemaArray Insert(int indexToInsert, in Schema.SchemaArray.SchemaArrayArray item1, in Schema.SchemaArray.SchemaArrayArray item2, in Schema.SchemaArray.SchemaArrayArray item3, in Schema.SchemaArray.SchemaArrayArray item4)
        {
            System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray>();
            int index = 0;
            foreach (Schema.SchemaArray.SchemaArrayArray item in this)
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
        public SchemaArray Remove(params Schema.SchemaArray.SchemaArrayArray[] items)
        {
            System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray>();
            foreach (Schema.SchemaArray.SchemaArrayArray item in this)
            {
                bool found = false;
                foreach (Schema.SchemaArray.SchemaArrayArray itemToRemove in items)
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
        public SchemaArray Remove(Schema.SchemaArray.SchemaArrayArray item1)
        {
            System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray>();
            foreach (Schema.SchemaArray.SchemaArrayArray item in this)
            {
                if (item1.Equals(item))
                {
                    break;
                }
                arrayBuilder.Add(item);
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public SchemaArray Remove(Schema.SchemaArray.SchemaArrayArray item1, Schema.SchemaArray.SchemaArrayArray item2)
        {
            System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray>();
            foreach (Schema.SchemaArray.SchemaArrayArray item in this)
            {
                if (item1.Equals(item) || item2.Equals(item))
                {
                    break;
                }
                arrayBuilder.Add(item);
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public SchemaArray Remove(Schema.SchemaArray.SchemaArrayArray item1, Schema.SchemaArray.SchemaArrayArray item2, Schema.SchemaArray.SchemaArrayArray item3)
        {
            System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray>();
            foreach (Schema.SchemaArray.SchemaArrayArray item in this)
            {
                if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))
                {
                    break;
                }
                arrayBuilder.Add(item);
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public SchemaArray Remove(Schema.SchemaArray.SchemaArrayArray item1, Schema.SchemaArray.SchemaArrayArray item2, Schema.SchemaArray.SchemaArrayArray item3, Schema.SchemaArray.SchemaArrayArray item4)
        {
            System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray>();
            foreach (Schema.SchemaArray.SchemaArrayArray item in this)
            {
                if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item) || item4.Equals(item))
                {
                    break;
                }
                arrayBuilder.Add(item);
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public SchemaArray RemoveAt(int indexToRemove)
        {
            System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray>();
            int index = 0;
            foreach (Schema.SchemaArray.SchemaArrayArray item in this)
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
        public SchemaArray RemoveRange(int startIndex, int length)
        {
            if (startIndex < 0 || startIndex > this.Length - 1)
            {
                throw new System.ArgumentOutOfRangeException(nameof(startIndex));
            }
            if (length < 1 || startIndex + length > this.Length - 1)
            {
                throw new System.ArgumentOutOfRangeException(nameof(length));
            }
            System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray>();
            int index = 0;
            foreach (Schema.SchemaArray.SchemaArrayArray item in this)
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
        public SchemaArray Remove(System.Predicate<Schema.SchemaArray.SchemaArrayArray> removeIfTrue)
        {
            System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray>();
            foreach (Schema.SchemaArray.SchemaArrayArray item in this)
            {
                if (removeIfTrue(item))
                {
                    continue;
                }
                arrayBuilder.Add(item);
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public readonly struct SchemaArrayArray : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>, System.Collections.IEnumerable, System.IEquatable<SchemaArrayArray>, System.IEquatable<Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, SchemaArrayArray> FromJsonElement = e => new SchemaArrayArray(e);
            public static readonly SchemaArrayArray Null = new SchemaArrayArray(default(System.Text.Json.JsonElement));
            private readonly Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>? value;
            public SchemaArrayArray(Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray> jsonArray)
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
            public SchemaArrayArray(System.Text.Json.JsonElement jsonElement)
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
                    if (this.value is Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray> value)
                    {
                        return value.Length;
                    }
                    return 0;
                }
            }
            public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public SchemaArrayArray? AsOptional => this.IsNull ? default(SchemaArrayArray?) : this;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static implicit operator SchemaArrayArray(Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray> value)
            {
                return new SchemaArrayArray(value);
            }
            public static implicit operator Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>(SchemaArrayArray value)
            {
                if (value.value is Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray> clrValue)
                {
                    return clrValue;
                }
                return new Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>(value.JsonElement);
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>.IsConvertibleFrom(jsonElement);
            }
            public static SchemaArrayArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new SchemaArrayArray(property)
                        : Null)
                    : Null;
            public static SchemaArrayArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new SchemaArrayArray(property)
                        : Null)
                    : Null;
            public static SchemaArrayArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new SchemaArrayArray(property)
                        : Null)
                    : Null;
            public bool Equals(SchemaArrayArray other)
            {
                return this.Equals((Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>)other);
            }
            public bool Equals(Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray> other)
            {
                return ((Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>)this).Equals(other);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray> array = this;
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
                if (this.value is Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray> clrValue)
                {
                    clrValue.WriteTo(writer);
                }
            }
            public Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>.JsonArrayEnumerator GetEnumerator()
            {
                return ((Menes.JsonArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>)this).GetEnumerator();
            }
            System.Collections.Generic.IEnumerator<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray> System.Collections.Generic.IEnumerable<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            public SchemaArrayArray Add(params Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray[] items)
            {
                System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>();
                foreach (Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item in this)
                {
                    arrayBuilder.Add(item);
                }
                foreach (Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item in items)
                {
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaArrayArray Add(in Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item1)
            {
                System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>();
                foreach (Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaArrayArray Add(in Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item1, in Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item2)
            {
                System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>();
                foreach (Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaArrayArray Add(in Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item1, in Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item2, in Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item3)
            {
                System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>();
                foreach (Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                arrayBuilder.Add(item3);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaArrayArray Add(in Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item1, in Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item2, in Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item3, in Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item4)
            {
                System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>();
                foreach (Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                arrayBuilder.Add(item3);
                arrayBuilder.Add(item4);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaArrayArray Insert(int indexToInsert, params Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray[] items)
            {
                System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>();
                int index = 0;
                foreach (Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item in this)
                {
                    if (index == indexToInsert)
                    {
                        foreach (Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray itemToInsert in items)
                        {
                            arrayBuilder.Add(itemToInsert);
                        }
                    }
                    arrayBuilder.Add(item);
                    ++index;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaArrayArray Insert(int indexToInsert, in Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item1)
            {
                System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>();
                int index = 0;
                foreach (Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item in this)
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
            public SchemaArrayArray Insert(int indexToInsert, in Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item1, in Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item2)
            {
                System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>();
                int index = 0;
                foreach (Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item in this)
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
            public SchemaArrayArray Insert(int indexToInsert, in Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item1, in Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item2, in Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item3)
            {
                System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>();
                int index = 0;
                foreach (Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item in this)
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
            public SchemaArrayArray Insert(int indexToInsert, in Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item1, in Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item2, in Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item3, in Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item4)
            {
                System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>();
                int index = 0;
                foreach (Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item in this)
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
            public SchemaArrayArray Remove(params Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray[] items)
            {
                System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>();
                foreach (Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item in this)
                {
                    bool found = false;
                    foreach (Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray itemToRemove in items)
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
            public SchemaArrayArray Remove(Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item1)
            {
                System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>();
                foreach (Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item in this)
                {
                    if (item1.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaArrayArray Remove(Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item1, Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item2)
            {
                System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>();
                foreach (Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item in this)
                {
                    if (item1.Equals(item) || item2.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaArrayArray Remove(Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item1, Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item2, Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item3)
            {
                System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>();
                foreach (Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item in this)
                {
                    if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaArrayArray Remove(Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item1, Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item2, Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item3, Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item4)
            {
                System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>();
                foreach (Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item in this)
                {
                    if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item) || item4.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaArrayArray RemoveAt(int indexToRemove)
            {
                System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>();
                int index = 0;
                foreach (Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item in this)
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
            public SchemaArrayArray RemoveRange(int startIndex, int length)
            {
                if (startIndex < 0 || startIndex > this.Length - 1)
                {
                    throw new System.ArgumentOutOfRangeException(nameof(startIndex));
                }
                if (length < 1 || startIndex + length > this.Length - 1)
                {
                    throw new System.ArgumentOutOfRangeException(nameof(length));
                }
                System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>();
                int index = 0;
                foreach (Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item in this)
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
            public SchemaArrayArray Remove(System.Predicate<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray> removeIfTrue)
            {
                System.Collections.Immutable.ImmutableArray<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray>();
                foreach (Schema.SchemaArray.SchemaArrayArray.SchemaArrayArrayArray item in this)
                {
                    if (removeIfTrue(item))
                    {
                        continue;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public readonly struct SchemaArrayArrayArray : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Menes.JsonNumber>, System.Collections.IEnumerable, System.IEquatable<SchemaArrayArrayArray>, System.IEquatable<Menes.JsonArray<Menes.JsonNumber>>
            {
                public static readonly System.Func<System.Text.Json.JsonElement, SchemaArrayArrayArray> FromJsonElement = e => new SchemaArrayArrayArray(e);
                public static readonly SchemaArrayArrayArray Null = new SchemaArrayArrayArray(default(System.Text.Json.JsonElement));
                private readonly Menes.JsonArray<Menes.JsonNumber>? value;
                public SchemaArrayArrayArray(Menes.JsonArray<Menes.JsonNumber> jsonArray)
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
                public SchemaArrayArrayArray(System.Text.Json.JsonElement jsonElement)
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
                public SchemaArrayArrayArray? AsOptional => this.IsNull ? default(SchemaArrayArrayArray?) : this;
                public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
                public System.Text.Json.JsonElement JsonElement { get; }
                public static implicit operator SchemaArrayArrayArray(Menes.JsonArray<Menes.JsonNumber> value)
                {
                    return new SchemaArrayArrayArray(value);
                }
                public static implicit operator Menes.JsonArray<Menes.JsonNumber>(SchemaArrayArrayArray value)
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
                public static SchemaArrayArrayArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
                   parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                        (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                            ? new SchemaArrayArrayArray(property)
                            : Null)
                        : Null;
                public static SchemaArrayArrayArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
                   parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                        (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                            ? new SchemaArrayArrayArray(property)
                            : Null)
                        : Null;
                public static SchemaArrayArrayArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
                   parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                        (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                            ? new SchemaArrayArrayArray(property)
                            : Null)
                        : Null;
                public bool Equals(SchemaArrayArrayArray other)
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
                public SchemaArrayArrayArray Add(params Menes.JsonNumber[] items)
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
                public SchemaArrayArrayArray Add(in Menes.JsonNumber item1)
                {
                    System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNumber>();
                    foreach (Menes.JsonNumber item in this)
                    {
                        arrayBuilder.Add(item);
                    }
                    arrayBuilder.Add(item1);
                    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
                }
                public SchemaArrayArrayArray Add(in Menes.JsonNumber item1, in Menes.JsonNumber item2)
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
                public SchemaArrayArrayArray Add(in Menes.JsonNumber item1, in Menes.JsonNumber item2, in Menes.JsonNumber item3)
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
                public SchemaArrayArrayArray Add(in Menes.JsonNumber item1, in Menes.JsonNumber item2, in Menes.JsonNumber item3, in Menes.JsonNumber item4)
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
                public SchemaArrayArrayArray Insert(int indexToInsert, params Menes.JsonNumber[] items)
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
                public SchemaArrayArrayArray Insert(int indexToInsert, in Menes.JsonNumber item1)
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
                public SchemaArrayArrayArray Insert(int indexToInsert, in Menes.JsonNumber item1, in Menes.JsonNumber item2)
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
                public SchemaArrayArrayArray Insert(int indexToInsert, in Menes.JsonNumber item1, in Menes.JsonNumber item2, in Menes.JsonNumber item3)
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
                public SchemaArrayArrayArray Insert(int indexToInsert, in Menes.JsonNumber item1, in Menes.JsonNumber item2, in Menes.JsonNumber item3, in Menes.JsonNumber item4)
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
                public SchemaArrayArrayArray Remove(params Menes.JsonNumber[] items)
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
                public SchemaArrayArrayArray Remove(Menes.JsonNumber item1)
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
                public SchemaArrayArrayArray Remove(Menes.JsonNumber item1, Menes.JsonNumber item2)
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
                public SchemaArrayArrayArray Remove(Menes.JsonNumber item1, Menes.JsonNumber item2, Menes.JsonNumber item3)
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
                public SchemaArrayArrayArray Remove(Menes.JsonNumber item1, Menes.JsonNumber item2, Menes.JsonNumber item3, Menes.JsonNumber item4)
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
                public SchemaArrayArrayArray RemoveAt(int indexToRemove)
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
                public SchemaArrayArrayArray RemoveRange(int startIndex, int length)
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
                public SchemaArrayArrayArray Remove(System.Predicate<Menes.JsonNumber> removeIfTrue)
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
        var schema = new Schema(doc.RootElement);
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
        var schema = new Schema(doc.RootElement);
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
        var schema = new Schema(doc.RootElement);
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