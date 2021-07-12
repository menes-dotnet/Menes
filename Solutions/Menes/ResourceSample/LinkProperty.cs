//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Marain.LineOfBusiness
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Text.Json;
    using System.Text.RegularExpressions;
    using Menes.Json;

    /// <summary>
    /// A type generated from a JsonSchema specification.
    /// </summary>
    public readonly struct LinkProperty : IJsonObject<LinkProperty>, IJsonArray<LinkProperty>, IEquatable<LinkProperty>
    {
        private readonly JsonElement jsonElementBacking;
        private readonly ImmutableDictionary<string, JsonAny>? objectBacking;
        private readonly ImmutableList<JsonAny>? arrayBacking;
        /// <summary>
        /// Initializes a new instance of the <see cref = "LinkProperty"/> struct.
        /// </summary>
        /// <param name = "value">The backing <see cref = "JsonElement"/>.</param>
        public LinkProperty(JsonElement value)
        {
            this.jsonElementBacking = value;
            this.objectBacking = default;
            this.arrayBacking = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "LinkProperty"/> struct.
        /// </summary>
        /// <param name = "value">A property dictionary.</param>
        public LinkProperty(ImmutableDictionary<string, JsonAny> value)
        {
            this.jsonElementBacking = default;
            this.objectBacking = value;
            this.arrayBacking = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "LinkProperty"/> struct.
        /// </summary>
        /// <param name = "jsonObject">The <see cref = "JsonObject"/> from which to construct the value.</param>
        public LinkProperty(JsonObject jsonObject)
        {
            if (jsonObject.HasJsonElement)
            {
                this.jsonElementBacking = jsonObject.AsJsonElement;
                this.objectBacking = default;
            }
            else
            {
                this.jsonElementBacking = default;
                this.objectBacking = jsonObject.AsPropertyDictionary;
            }

            this.arrayBacking = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "LinkProperty"/> struct.
        /// </summary>
        /// <param name = "value">An array list.</param>
        public LinkProperty(ImmutableList<JsonAny> value)
        {
            this.jsonElementBacking = default;
            this.objectBacking = default;
            this.arrayBacking = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "LinkProperty"/> struct.
        /// </summary>
        /// <param name = "jsonArray">The <see cref = "JsonArray"/> from which to construct the value.</param>
        public LinkProperty(JsonArray jsonArray)
        {
            if (jsonArray.HasJsonElement)
            {
                this.jsonElementBacking = jsonArray.AsJsonElement;
                this.arrayBacking = default;
            }
            else
            {
                this.jsonElementBacking = default;
                this.arrayBacking = jsonArray.AsItemsList;
            }

            this.objectBacking = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "LinkProperty"/> struct.
        /// </summary>
        /// <param name = "conversion">The <see cref = "Marain.LineOfBusiness.Link"/> from which to construct the value.</param>
        public LinkProperty(Marain.LineOfBusiness.Link conversion)
        {
            if (conversion.HasJsonElement)
            {
                this.jsonElementBacking = conversion.AsJsonElement;
                this.objectBacking = default;
                this.arrayBacking = default;
            }
            else
            {
                this.jsonElementBacking = default;
                if (conversion.ValueKind == JsonValueKind.Object)
                {
                    this.objectBacking = conversion;
                }
                else
                {
                    this.objectBacking = default;
                }

                this.arrayBacking = default;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "LinkProperty"/> struct.
        /// </summary>
        /// <param name = "conversion">The <see cref = "Marain.LineOfBusiness.LinkArray"/> from which to construct the value.</param>
        public LinkProperty(Marain.LineOfBusiness.LinkArray conversion)
        {
            if (conversion.HasJsonElement)
            {
                this.jsonElementBacking = conversion.AsJsonElement;
                this.objectBacking = default;
                this.arrayBacking = default;
            }
            else
            {
                this.jsonElementBacking = default;
                this.objectBacking = default;
                if (conversion.ValueKind == JsonValueKind.Array)
                {
                    this.arrayBacking = conversion;
                }
                else
                {
                    this.arrayBacking = default;
                }
            }
        }

        /// <inheritdoc/>
        public int Length
        {
            get
            {
                if (this.arrayBacking is ImmutableList<JsonAny> items)
                {
                    return items.Count;
                }

                return this.jsonElementBacking.GetArrayLength();
            }
        }

        /// <summary>
        /// Gets the value as a <see cref = "Marain.LineOfBusiness.Link"/>.
        /// </summary>
        public Marain.LineOfBusiness.Link AsLink
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is a valid <see cref = "Marain.LineOfBusiness.Link"/>.
        /// </summary>
        public bool IsLink
        {
            get
            {
                return ((Marain.LineOfBusiness.Link)this).Validate().IsValid;
            }
        }

        /// <summary>
        /// Gets the value as a <see cref = "Marain.LineOfBusiness.LinkArray"/>.
        /// </summary>
        public Marain.LineOfBusiness.LinkArray AsLinkArray
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is a valid <see cref = "Marain.LineOfBusiness.LinkArray"/>.
        /// </summary>
        public bool IsLinkArray
        {
            get
            {
                return ((Marain.LineOfBusiness.LinkArray)this).Validate().IsValid;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is backed by a JSON element.
        /// </summary>
        public bool HasJsonElement => this.objectBacking is null && this.arrayBacking is null;
        /// <summary>
        /// Gets the value as a JsonElement.
        /// </summary>
        public JsonElement AsJsonElement
        {
            get
            {
                if (this.objectBacking is ImmutableDictionary<string, JsonAny> objectBacking)
                {
                    return JsonObject.PropertiesToJsonElement(objectBacking);
                }

                if (this.arrayBacking is ImmutableList<JsonAny> arrayBacking)
                {
                    return JsonArray.ItemsToJsonElement(arrayBacking);
                }

                return this.jsonElementBacking;
            }
        }

        /// <inheritdoc/>
        public JsonValueKind ValueKind
        {
            get
            {
                if (this.objectBacking is ImmutableDictionary<string, JsonAny>)
                {
                    return JsonValueKind.Object;
                }

                if (this.arrayBacking is ImmutableList<JsonAny>)
                {
                    return JsonValueKind.Array;
                }

                return this.jsonElementBacking.ValueKind;
            }
        }

        /// <inheritdoc/>
        public JsonAny AsAny
        {
            get
            {
                if (this.objectBacking is ImmutableDictionary<string, JsonAny> objectBacking)
                {
                    return new JsonAny(objectBacking);
                }

                if (this.arrayBacking is ImmutableList<JsonAny> arrayBacking)
                {
                    return new JsonAny(arrayBacking);
                }

                return new JsonAny(this.jsonElementBacking);
            }
        }

        /// <summary>
        /// Conversion from <see cref = "Marain.LineOfBusiness.Link"/>.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator LinkProperty(Marain.LineOfBusiness.Link value)
        {
            return new LinkProperty(value);
        }

        /// <summary>
        /// Conversion to <see cref = "Marain.LineOfBusiness.Link"/>.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator Marain.LineOfBusiness.Link(LinkProperty value)
        {
            if (value.ValueKind == JsonValueKind.Object)
            {
                return new Marain.LineOfBusiness.Link(value.AsObject);
            }

            return default;
        }

        /// <summary>
        /// Conversion from <see cref = "Marain.LineOfBusiness.LinkArray"/>.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator LinkProperty(Marain.LineOfBusiness.LinkArray value)
        {
            return new LinkProperty(value);
        }

        /// <summary>
        /// Conversion to <see cref = "Marain.LineOfBusiness.LinkArray"/>.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator Marain.LineOfBusiness.LinkArray(LinkProperty value)
        {
            if (value.ValueKind == JsonValueKind.Array)
            {
                return new Marain.LineOfBusiness.LinkArray(value.AsArray);
            }

            return default;
        }

        /// <summary>
        /// Conversion from any.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator LinkProperty(JsonAny value)
        {
            if (value.HasJsonElement)
            {
                return new LinkProperty(value.AsJsonElement);
            }

            return value.As<LinkProperty>();
        }

        /// <summary>
        /// Conversion to any.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator JsonAny(LinkProperty value)
        {
            return value.AsAny;
        }

        /// <summary>
        /// Conversion from array.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator LinkProperty(JsonArray value)
        {
            return new LinkProperty(value);
        }

        /// <summary>
        /// Conversion to array.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator JsonArray(LinkProperty value)
        {
            return value.AsArray;
        }

        /// <summary>
        /// Implicit conversion to an <see cref = "ImmutableList{T}"/> of <see cref = "JsonAny"/>.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator ImmutableList<JsonAny>(LinkProperty value)
        {
            return value.AsArray.AsItemsList;
        }

        /// <summary>
        /// Implicit conversion from an <see cref = "ImmutableList{T}"/> of <see cref = "JsonAny"/>.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator LinkProperty(ImmutableList<JsonAny> value)
        {
            return new LinkProperty(value);
        }

        /// <summary>
        /// Conversion from object.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator LinkProperty(JsonObject value)
        {
            return new LinkProperty(value);
        }

        /// <summary>
        /// Conversion to object.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator JsonObject(LinkProperty value)
        {
            return value.AsObject;
        }

        /// <summary>
        /// Implicit conversion to a property dictionary.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator ImmutableDictionary<string, JsonAny>(LinkProperty value)
        {
            return value.AsObject.AsPropertyDictionary;
        }

        /// <summary>
        /// Implicit conversion from a property dictionary.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator LinkProperty(ImmutableDictionary<string, JsonAny> value)
        {
            return new LinkProperty(value);
        }

        /// <summary>
        /// Standard equality operator.
        /// </summary>
        /// <param name = "lhs">The left hand side of the comparison.</param>
        /// <param name = "rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are equal.</returns>
        public static bool operator ==(LinkProperty lhs, LinkProperty rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Standard inequality operator.
        /// </summary>
        /// <param name = "lhs">The left hand side of the comparison.</param>
        /// <param name = "rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are not equal.</returns>
        public static bool operator !=(LinkProperty lhs, LinkProperty rhs)
        {
            return !lhs.Equals(rhs);
        }

        /// <summary>
        /// Create an array from the given items.
        /// </summary>
        /// <param name = "items">The items from which to create the array.</param>
        /// <returns>The new array created from the items.</returns>
        public static LinkProperty From(params JsonAny[] items)
        {
            return new LinkProperty(items.ToImmutableList());
        }

        /// <summary>
        /// Create an array from the given items.
        /// </summary>
        /// <param name = "item1">The items from which to create the array.</param>
        /// <returns>The new array created from the items.</returns>
        public static LinkProperty From(JsonAny item1)
        {
            return new LinkProperty(ImmutableList.Create(item1));
        }

        /// <summary>
        /// Create an array from the given items.
        /// </summary>
        /// <param name = "item1">The first item from which to create the array.</param>
        /// <param name = "item2">The second item from which to create the array.</param>
        /// <returns>The new array created from the items.</returns>
        public static LinkProperty From(JsonAny item1, JsonAny item2)
        {
            return new LinkProperty(ImmutableList.Create(item1, item2));
        }

        /// <summary>
        /// Create an array from the given items.
        /// </summary>
        /// <param name = "item1">The first item from which to create the array.</param>
        /// <param name = "item2">The second item from which to create the array.</param>
        /// <param name = "item3">The third item from which to create the array.</param>
        /// <returns>The new array created from the items.</returns>
        public static LinkProperty From(JsonAny item1, JsonAny item2, JsonAny item3)
        {
            return new LinkProperty(ImmutableList.Create(item1, item2, item3));
        }

        /// <summary>
        /// Create an array from the given items.
        /// </summary>
        /// <param name = "item1">The first item from which to create the array.</param>
        /// <param name = "item2">The second item from which to create the array.</param>
        /// <param name = "item3">The third item from which to create the array.</param>
        /// <param name = "item4">The fourth item from which to create the array.</param>
        /// <returns>The new array created from the items.</returns>
        public static LinkProperty From(JsonAny item1, JsonAny item2, JsonAny item3, JsonAny item4)
        {
            return new LinkProperty(ImmutableList.Create(item1, item2, item3, item4));
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is IJsonValue jv)
            {
                return this.Equals(jv.AsAny);
            }

            return obj is null && this.IsNull();
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            JsonValueKind valueKind = this.ValueKind;
            return valueKind switch
            {
            JsonValueKind.Object => this.AsObject.GetHashCode(), JsonValueKind.Array => this.AsArray.GetHashCode(), JsonValueKind.Number => this.AsNumber().GetHashCode(), JsonValueKind.String => this.AsString().GetHashCode(), JsonValueKind.True or JsonValueKind.False => this.AsBoolean().GetHashCode(), JsonValueKind.Null => JsonNull.NullHashCode, _ => JsonAny.UndefinedHashCode, }

            ;
        }

        /// <summary>
        /// Writes the object to the <see cref = "Utf8JsonWriter"/>.
        /// </summary>
        /// <param name = "writer">The writer to which to write the object.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.objectBacking is ImmutableDictionary<string, JsonAny> objectBacking)
            {
                JsonObject.WriteProperties(objectBacking, writer);
                return;
            }

            if (this.arrayBacking is ImmutableList<JsonAny> arrayBacking)
            {
                JsonArray.WriteItems(arrayBacking, writer);
                return;
            }

            if (this.jsonElementBacking.ValueKind != JsonValueKind.Undefined)
            {
                this.jsonElementBacking.WriteTo(writer);
                return;
            }

            writer.WriteNullValue();
        }

        /// <inheritdoc/>
        public JsonObjectEnumerator EnumerateObject()
        {
            return this.AsObject.EnumerateObject();
        }

        /// <inheritdoc/>
        public JsonArrayEnumerator EnumerateArray()
        {
            return this.AsArray.EnumerateArray();
        }

        /// <inheritdoc/>
        public bool TryGetProperty(string name, out JsonAny value)
        {
            return this.AsObject.TryGetProperty(name, out value);
        }

        /// <inheritdoc/>
        public bool TryGetProperty(ReadOnlySpan<char> name, out JsonAny value)
        {
            return this.AsObject.TryGetProperty(name, out value);
        }

        /// <inheritdoc/>
        public bool TryGetProperty(ReadOnlySpan<byte> utf8name, out JsonAny value)
        {
            return this.AsObject.TryGetProperty(utf8name, out value);
        }

        /// <inheritdoc/>
        public bool Equals<T>(T other)
            where T : struct, IJsonValue
        {
            JsonValueKind valueKind = this.ValueKind;
            if (other.ValueKind != valueKind)
            {
                return false;
            }

            return valueKind switch
            {
            JsonValueKind.Object => this.AsObject.Equals(other.AsObject()), JsonValueKind.Array => this.AsArray.Equals(other.AsArray()), JsonValueKind.Number => this.AsNumber().Equals(other.AsNumber()), JsonValueKind.String => this.AsString().Equals(other.AsString()), JsonValueKind.True or JsonValueKind.False => this.AsBoolean().Equals(other.AsBoolean()), JsonValueKind.Null => true, _ => false, }

            ;
        }

        /// <inheritdoc/>
        public bool Equals(LinkProperty other)
        {
            JsonValueKind valueKind = this.ValueKind;
            if (other.ValueKind != valueKind)
            {
                return false;
            }

            return valueKind switch
            {
            JsonValueKind.Object => this.AsObject.Equals(other.AsObject), JsonValueKind.Array => this.AsArray.Equals(other.AsArray), JsonValueKind.Number => this.AsNumber().Equals(other.AsNumber()), JsonValueKind.String => this.AsString().Equals(other.AsString()), JsonValueKind.True or JsonValueKind.False => this.AsBoolean().Equals(other.AsBoolean()), JsonValueKind.Null => true, _ => false, }

            ;
        }

        /// <inheritdoc/>
        public bool HasProperty(string name)
        {
            if (this.objectBacking is ImmutableDictionary<string, JsonAny> properties)
            {
                return properties.TryGetValue(name, out _);
            }

            if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
            {
                return this.jsonElementBacking.TryGetProperty(name.ToString(), out JsonElement _);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool HasProperty(ReadOnlySpan<char> name)
        {
            if (this.objectBacking is ImmutableDictionary<string, JsonAny> properties)
            {
                return properties.TryGetValue(name.ToString(), out _);
            }

            if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
            {
                return this.jsonElementBacking.TryGetProperty(name, out JsonElement _);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool HasProperty(ReadOnlySpan<byte> utf8name)
        {
            if (this.objectBacking is ImmutableDictionary<string, JsonAny> properties)
            {
                return properties.TryGetValue(System.Text.Encoding.UTF8.GetString(utf8name), out _);
            }

            if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
            {
                return this.jsonElementBacking.TryGetProperty(utf8name, out JsonElement _);
            }

            return false;
        }

        /// <inheritdoc/>
        public LinkProperty SetProperty<TValue>(string name, TValue value)
            where TValue : struct, IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Object || this.ValueKind == JsonValueKind.Undefined)
            {
                return this.AsObject.SetProperty(name, value);
            }

            return this;
        }

        /// <inheritdoc/>
        public LinkProperty SetProperty<TValue>(ReadOnlySpan<char> name, TValue value)
            where TValue : struct, IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Object || this.ValueKind == JsonValueKind.Undefined)
            {
                return this.AsObject.SetProperty(name, value);
            }

            return this;
        }

        /// <inheritdoc/>
        public LinkProperty SetProperty<TValue>(ReadOnlySpan<byte> utf8name, TValue value)
            where TValue : struct, IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Object || this.ValueKind == JsonValueKind.Undefined)
            {
                return this.AsObject.SetProperty(utf8name, value);
            }

            return this;
        }

        /// <inheritdoc/>
        public LinkProperty RemoveProperty(string name)
        {
            if (this.ValueKind == JsonValueKind.Object)
            {
                return this.AsObject.RemoveProperty(name);
            }

            return this;
        }

        /// <inheritdoc/>
        public LinkProperty RemoveProperty(ReadOnlySpan<char> name)
        {
            if (this.ValueKind == JsonValueKind.Object)
            {
                return this.AsObject.RemoveProperty(name);
            }

            return this;
        }

        /// <inheritdoc/>
        public LinkProperty RemoveProperty(ReadOnlySpan<byte> utf8Name)
        {
            if (this.ValueKind == JsonValueKind.Object)
            {
                return this.AsObject.RemoveProperty(utf8Name);
            }

            return this;
        }

        /// <inheritdoc/>
        public LinkProperty Add<TItem>(TItem item)
            where TItem : struct, IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Array || this.ValueKind == JsonValueKind.Undefined)
            {
                return this.AsArray.Add(item);
            }

            return this;
        }

        /// <inheritdoc/>
        public LinkProperty Insert<TItem>(int index, TItem item)
            where TItem : struct, IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Array || this.ValueKind == JsonValueKind.Undefined)
            {
                return this.AsArray.Insert(index, item);
            }

            return this;
        }

        /// <inheritdoc/>
        public LinkProperty Replace<TItem>(TItem oldValue, TItem newValue)
            where TItem : struct, IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Array)
            {
                return this.AsArray.Replace(oldValue, newValue);
            }

            return this;
        }

        /// <inheritdoc/>
        public LinkProperty RemoveAt(int index)
        {
            if (this.ValueKind == JsonValueKind.Array)
            {
                return this.AsArray.RemoveAt(index);
            }

            return this;
        }

        /// <inheritdoc/>
        public LinkProperty RemoveRange(int index, int count)
        {
            if (this.ValueKind == JsonValueKind.Array)
            {
                return this.AsArray.RemoveRange(index, count);
            }

            return this;
        }

        /// <inheritdoc/>
        public LinkProperty SetItem<TItem>(int index, TItem value)
            where TItem : struct, IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Array)
            {
                return this.AsArray.SetItem(index, value);
            }

            return this;
        }

        /// <inheritdoc/>
        public T As<T>()
            where T : struct, IJsonValue
        {
            return this.As<LinkProperty, T>();
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext? validationContext = null, ValidationLevel level = ValidationLevel.Flag)
        {
            ValidationContext result = validationContext ?? ValidationContext.ValidContext;
            if (level != ValidationLevel.Flag)
            {
                result = result.UsingStack();
            }

            JsonValueKind valueKind = this.ValueKind;
            result = this.ValidateAnyOf(result, level);
            if (level == ValidationLevel.Flag && !result.IsValid)
            {
                return result;
            }

            result = this.ValidateArray(valueKind, result, level);
            if (level == ValidationLevel.Flag && !result.IsValid)
            {
                return result;
            }

            return result;
        }

        /// <summary>
        /// Gets the value as a <see cref = "JsonObject"/>.
        /// </summary>
        private JsonObject AsObject
        {
            get
            {
                if (this.objectBacking is ImmutableDictionary<string, JsonAny> objectBacking)
                {
                    return new JsonObject(objectBacking);
                }

                return new JsonObject(this.jsonElementBacking);
            }
        }

        /// <summary>
        /// Gets the value as a <see cref = "JsonArray"/>.
        /// </summary>
        private JsonArray AsArray
        {
            get
            {
                if (this.arrayBacking is ImmutableList<JsonAny> arrayBacking)
                {
                    return new JsonArray(arrayBacking);
                }

                return new JsonArray(this.jsonElementBacking);
            }
        }

        private ValidationContext ValidateArray(JsonValueKind valueKind, in ValidationContext validationContext, ValidationLevel level)
        {
            ValidationContext result = validationContext;
            if (valueKind != JsonValueKind.Array)
            {
                return result;
            }

            int arrayLength = 0;
            JsonArrayEnumerator arrayEnumerator = this.EnumerateArray();
            while (arrayEnumerator.MoveNext())
            {
                JsonArrayEnumerator innerEnumerator = this.EnumerateArray();
                int innerIndex = -1;
                while (innerIndex < arrayLength && innerEnumerator.MoveNext())
                {
                    innerIndex++;
                }

                while (innerEnumerator.MoveNext())
                {
                    if (innerEnumerator.Current.Equals(arrayEnumerator.Current))
                    {
                        if (level >= ValidationLevel.Detailed)
                        {
                            result = result.WithResult(isValid: false, $"6.4.3. uniqueItems - duplicate items were found at indices {arrayLength} and {innerIndex}.");
                        }
                        else if (level >= ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, "6.4.3. uniqueItems - duplicate items were found.");
                        }
                        else
                        {
                            return result.WithResult(isValid: false);
                        }
                    }
                }

                arrayLength++;
            }

            return result;
        }

        private ValidationContext ValidateAnyOf(in ValidationContext validationContext, ValidationLevel level)
        {
            ValidationContext result = validationContext;
            bool foundValid = false;
            ValidationContext anyOfResult0 = this.As<Marain.LineOfBusiness.Link>().Validate(validationContext.CreateChildContext(), level);
            if (anyOfResult0.IsValid)
            {
                result = result.MergeChildContext(anyOfResult0, level >= ValidationLevel.Detailed);
                if (level == ValidationLevel.Flag)
                {
                    return result;
                }
                else
                {
                    foundValid = true;
                }
            }
            else
            {
                if (level >= ValidationLevel.Detailed)
                {
                    result = result.MergeResults(result.IsValid, level, anyOfResult0);
                }
                else if (level >= ValidationLevel.Basic)
                {
                    result = result.MergeResults(result.IsValid, level, anyOfResult0);
                }
            }

            ValidationContext anyOfResult1 = this.As<Marain.LineOfBusiness.LinkArray>().Validate(validationContext.CreateChildContext(), level);
            if (anyOfResult1.IsValid)
            {
                result = result.MergeChildContext(anyOfResult1, level >= ValidationLevel.Detailed);
                if (level == ValidationLevel.Flag)
                {
                    return result;
                }
                else
                {
                    foundValid = true;
                }
            }
            else
            {
                if (level >= ValidationLevel.Detailed)
                {
                    result = result.MergeResults(result.IsValid, level, anyOfResult1);
                }
                else if (level >= ValidationLevel.Basic)
                {
                    result = result.MergeResults(result.IsValid, level, anyOfResult1);
                }
            }

            if (foundValid)
            {
                if (level >= ValidationLevel.Detailed)
                {
                    result = result.WithResult(isValid: true, "Validation 10.2.1.2. anyOf - validated against the anyOf schema.");
                }
            }
            else
            {
                if (level >= ValidationLevel.Detailed)
                {
                    result = result.WithResult(isValid: false, "Validation 10.2.1.2. anyOf - failed to validate against the anyOf schema.");
                }
                else if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation 10.2.1.2. anyOf - failed to validate against the anyOf schema.");
                }
                else
                {
                    result = result.WithResult(isValid: false);
                }
            }

            return result;
        }
    }
}