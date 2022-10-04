//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
using System.Buffers;
using System.ComponentModel;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Corvus.Json;
using Corvus.Json.Internal;

namespace Menes.Hal;
/// <summary>
/// A type generated from a JsonSchema specification.
/// </summary>
public readonly partial struct EmbeddedResourceProperty
{
    private readonly Backing backing;
    private readonly JsonElement jsonElementBacking;
    private readonly ImmutableList<JsonAny> arrayBacking;
    private readonly ImmutableDictionary<JsonPropertyName, JsonAny> objectBacking;
    /// <summary>
    /// Initializes a new instance of the <see cref = "EmbeddedResourceProperty"/> struct.
    /// </summary>
    public EmbeddedResourceProperty()
    {
        this.jsonElementBacking = default;
        this.backing = Backing.JsonElement;
        this.arrayBacking = ImmutableList<JsonAny>.Empty;
        this.objectBacking = ImmutableDictionary<JsonPropertyName, JsonAny>.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref = "EmbeddedResourceProperty"/> struct.
    /// </summary>
    /// <param name = "value">The value from which to construct the instance.</param>
    public EmbeddedResourceProperty(in JsonElement value)
    {
        this.jsonElementBacking = value;
        this.backing = Backing.JsonElement;
        this.arrayBacking = ImmutableList<JsonAny>.Empty;
        this.objectBacking = ImmutableDictionary<JsonPropertyName, JsonAny>.Empty;
    }

    /// <summary>
    /// Gets a Null instance.
    /// </summary>
    public static EmbeddedResourceProperty Null { get; } = new(JsonValueHelpers.NullElement);
    /// <summary>
    /// Gets an Undefined instance.
    /// </summary>
    public static EmbeddedResourceProperty Undefined { get; } = default;
    /// <inheritdoc/>
    public JsonAny AsAny
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                return new(this.jsonElementBacking);
            }

            if ((this.backing & Backing.Array) != 0)
            {
                return new(this.arrayBacking);
            }

            if ((this.backing & Backing.Object) != 0)
            {
                return new(this.objectBacking);
            }

            if ((this.backing & Backing.Null) != 0)
            {
                return JsonAny.Null;
            }

            return JsonAny.Undefined;
        }
    }

    /// <inheritdoc/>
    public JsonElement AsJsonElement
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                return this.jsonElementBacking;
            }

            if ((this.backing & Backing.Array) != 0)
            {
                return JsonValueHelpers.ArrayToJsonElement(this.arrayBacking);
            }

            if ((this.backing & Backing.Object) != 0)
            {
                return JsonValueHelpers.ObjectToJsonElement(this.objectBacking);
            }

            if ((this.backing & Backing.Null) != 0)
            {
                return JsonValueHelpers.NullElement;
            }

            return default;
        }
    }

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public JsonString AsString
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                return new(this.jsonElementBacking);
            }

            throw new InvalidOperationException();
        }
    }

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public JsonBoolean AsBoolean
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                return new(this.jsonElementBacking);
            }

            throw new InvalidOperationException();
        }
    }

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public JsonNumber AsNumber
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                return new(this.jsonElementBacking);
            }

            throw new InvalidOperationException();
        }
    }

    /// <inheritdoc/>
    public JsonObject AsObject
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                return new(this.jsonElementBacking);
            }

            if ((this.backing & Backing.Object) != 0)
            {
                return new(this.objectBacking);
            }

            throw new InvalidOperationException();
        }
    }

    /// <inheritdoc/>
    public JsonArray AsArray
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                return new(this.jsonElementBacking);
            }

            if ((this.backing & Backing.Array) != 0)
            {
                return new(this.arrayBacking);
            }

            throw new InvalidOperationException();
        }
    }

    /// <inheritdoc/>
    public bool HasJsonElementBacking
    {
        get
        {
            return (this.backing & Backing.JsonElement) != 0;
        }
    }

    /// <inheritdoc/>
    public bool HasDotnetBacking
    {
        get
        {
            return (this.backing & Backing.Dotnet) != 0;
        }
    }

    /// <inheritdoc/>
    public JsonValueKind ValueKind
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                return this.jsonElementBacking.ValueKind;
            }

            if ((this.backing & Backing.Array) != 0)
            {
                return JsonValueKind.Array;
            }

            if ((this.backing & Backing.Object) != 0)
            {
                return JsonValueKind.Object;
            }

            if ((this.backing & Backing.Null) != 0)
            {
                return JsonValueKind.Null;
            }

            return JsonValueKind.Undefined;
        }
    }

    /// <summary>
    /// Conversion from JsonAny.
    /// </summary>
    /// <param name = "value">The value from which to convert.</param>
    public static implicit operator EmbeddedResourceProperty(JsonAny value)
    {
        return EmbeddedResourceProperty.FromAny(value);
    }

    /// <summary>
    /// Conversion to JsonAny.
    /// </summary>
    /// <param name = "value">The value from which to convert.</param>
    /// <exception cref = "InvalidOperationException">The value was not compatible with this type.</exception>
    public static implicit operator JsonAny(in EmbeddedResourceProperty value)
    {
        return value.AsAny;
    }

    /// <summary>
    /// Equality operator.
    /// </summary>
    /// <param name = "left">The lhs.</param>
    /// <param name = "right">The rhs.</param>
    /// <returns><c>True</c> if the values are equal.</returns>
    public static bool operator ==(in EmbeddedResourceProperty left, in EmbeddedResourceProperty right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Inequality operator.
    /// </summary>
    /// <param name = "left">The lhs.</param>
    /// <param name = "right">The rhs.</param>
    /// <returns><c>True</c> if the values are equal.</returns>
    public static bool operator !=(in EmbeddedResourceProperty left, in EmbeddedResourceProperty right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    /// Gets an instance of the JSON value from a JsonAny value.
    /// </summary>
    /// <param name = "value">The <see cref = "JsonAny"/> value from which to instantiate the instance.</param>
    /// <returns>An instance of this type, initialized from the <see cref = "JsonAny"/>.</returns>
    /// <remarks>The returned value will have a <see cref = "IJsonValue.ValueKind"/> of <see cref = "JsonValueKind.Undefined"/> if the
    /// value cannot be constructed from the given instance (e.g. because they have an incompatible dotnet backing type.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EmbeddedResourceProperty FromAny(in JsonAny value)
    {
        if (value.HasJsonElementBacking)
        {
            return new(value.AsJsonElement);
        }

        JsonValueKind valueKind = value.ValueKind;
        return valueKind switch
        {
            JsonValueKind.Array => new((ImmutableList<JsonAny>)value),
            JsonValueKind.Object => new((ImmutableDictionary<JsonPropertyName, JsonAny>)value),
            JsonValueKind.Null => Null,
            _ => Undefined,
        };
    }

    /// <summary>
    /// Gets an instance of the JSON value from a <see cref = "JsonElement"/> value.
    /// </summary>
    /// <param name = "value">The <see cref = "JsonElement"/> value from which to instantiate the instance.</param>
    /// <returns>An instance of this type, initialized from the <see cref = "JsonElement"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EmbeddedResourceProperty FromJson(in JsonElement value)
    {
        return new(value);
    }

    /// <summary>
    /// Gets an instance of the JSON value from a boolean value.
    /// </summary>
    /// <typeparam name = "TValue">The type of the value.</typeparam>
    /// <param name = "value">The value from which to instantiate the instance.</param>
    /// <returns>An instance of this type, initialized from the value.</returns>
    /// <remarks>This will be EmbeddedResourceProperty.Undefined if the type is not compatible.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static EmbeddedResourceProperty FromBoolean<TValue>(in TValue value)
        where TValue : struct, IJsonBoolean<TValue>
    {
        if (value.HasJsonElementBacking)
        {
            return new(value.AsJsonElement);
        }

        return Undefined;
    }

    /// <summary>
    /// Gets an instance of the JSON value from a string value.
    /// </summary>
    /// <typeparam name = "TValue">The type of the value.</typeparam>
    /// <param name = "value">The value from which to instantiate the instance.</param>
    /// <returns>An instance of this type, initialized from the value.</returns>
    /// <remarks>This will be EmbeddedResourceProperty.Undefined if the type is not compatible.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static EmbeddedResourceProperty FromString<TValue>(in TValue value)
        where TValue : struct, IJsonString<TValue>
    {
        if (value.HasJsonElementBacking)
        {
            return new(value.AsJsonElement);
        }

        return Undefined;
    }

    /// <summary>
    /// Gets an instance of the JSON value from a number value.
    /// </summary>
    /// <typeparam name = "TValue">The type of the value.</typeparam>
    /// <param name = "value">The value from which to instantiate the instance.</param>
    /// <returns>An instance of this type, initialized from the value.</returns>
    /// <remarks>This will be EmbeddedResourceProperty.Undefined if the type is not compatible.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static EmbeddedResourceProperty FromNumber<TValue>(in TValue value)
        where TValue : struct, IJsonNumber<TValue>
    {
        if (value.HasJsonElementBacking)
        {
            return new(value.AsJsonElement);
        }

        return Undefined;
    }

    /// <summary>
    /// Gets an instance of the JSON value from an array value.
    /// </summary>
    /// <typeparam name = "TValue">The type of the value.</typeparam>
    /// <param name = "value">The value from which to instantiate the instance.</param>
    /// <returns>An instance of this type, initialized from the value.</returns>
    /// <remarks>This will be EmbeddedResourceProperty.Undefined if the type is not compatible.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EmbeddedResourceProperty FromArray<TValue>(in TValue value)
        where TValue : struct, IJsonArray<TValue>
    {
        if (value.HasJsonElementBacking)
        {
            return new(value.AsJsonElement);
        }

        if (value.ValueKind == JsonValueKind.Array)
        {
            return new((ImmutableList<JsonAny>)value);
        }

        return Undefined;
    }

    /// <summary>
    /// Gets an instance of the JSON value from an object value.
    /// </summary>
    /// <typeparam name = "TValue">The type of the value.</typeparam>
    /// <param name = "value">The value from which to instantiate the instance.</param>
    /// <returns>An instance of this type, initialized from the value.</returns>
    /// <remarks>This will be EmbeddedResourceProperty.Undefined if the type is not compatible.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EmbeddedResourceProperty FromObject<TValue>(in TValue value)
        where TValue : struct, IJsonObject<TValue>
    {
        if (value.HasJsonElementBacking)
        {
            return new(value.AsJsonElement);
        }

        if (value.ValueKind == JsonValueKind.Object)
        {
            return new((ImmutableDictionary<JsonPropertyName, JsonAny>)value);
        }

        return Undefined;
    }

    /// <summary>
    /// Parses a JSON string into a EmbeddedResourceProperty.
    /// </summary>
    /// <param name = "json">The json string to parse.</param>
    /// <param name = "options">The (optional) JsonDocumentOptions.</param>
    /// <returns>A <see cref = "EmbeddedResourceProperty"/> instance built from the JSON string.</returns>
    public static EmbeddedResourceProperty Parse(string json, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(json, options);
        return new EmbeddedResourceProperty(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses a JSON string into a EmbeddedResourceProperty.
    /// </summary>
    /// <param name = "utf8Json">The json string to parse.</param>
    /// <param name = "options">The (optional) JsonDocumentOptions.</param>
    /// <returns>A <see cref = "EmbeddedResourceProperty"/> instance built from the JSON string.</returns>
    public static EmbeddedResourceProperty Parse(Stream utf8Json, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(utf8Json, options);
        return new EmbeddedResourceProperty(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses a JSON string into a EmbeddedResourceProperty.
    /// </summary>
    /// <param name = "utf8Json">The json string to parse.</param>
    /// <param name = "options">The (optional) JsonDocumentOptions.</param>
    /// <returns>A <see cref = "EmbeddedResourceProperty"/> instance built from the JSON string.</returns>
    public static EmbeddedResourceProperty Parse(ReadOnlyMemory<byte> utf8Json, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(utf8Json, options);
        return new EmbeddedResourceProperty(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses a JSON string into a EmbeddedResourceProperty.
    /// </summary>
    /// <param name = "json">The json string to parse.</param>
    /// <param name = "options">The (optional) JsonDocumentOptions.</param>
    /// <returns>A <see cref = "EmbeddedResourceProperty"/> instance built from the JSON string.</returns>
    public static EmbeddedResourceProperty Parse(ReadOnlyMemory<char> json, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(json, options);
        return new EmbeddedResourceProperty(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses a JSON string into a EmbeddedResourceProperty.
    /// </summary>
    /// <param name = "utf8Json">The json string to parse.</param>
    /// <param name = "options">The (optional) JsonDocumentOptions.</param>
    /// <returns>A <see cref = "EmbeddedResourceProperty"/> instance built from the JSON string.</returns>
    public static EmbeddedResourceProperty Parse(ReadOnlySequence<byte> utf8Json, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(utf8Json, options);
        return new EmbeddedResourceProperty(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Gets the value as the target value.
    /// </summary>
    /// <typeparam name = "TTarget">The type of the target.</typeparam>
    /// <returns>An instance of the target type.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public TTarget As<TTarget>()
        where TTarget : struct, IJsonValue<TTarget>
    {
        if ((this.backing & Backing.JsonElement) != 0)
        {
            return TTarget.FromJson(this.jsonElementBacking);
        }

        if ((this.backing & Backing.Array) != 0)
        {
            return TTarget.FromArray(this);
        }

        if ((this.backing & Backing.Object) != 0)
        {
            return TTarget.FromObject(this);
        }

        if ((this.backing & Backing.Null) != 0)
        {
            return TTarget.Null;
        }

        return TTarget.Undefined;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return (obj is IJsonValue jv && this.Equals(jv.AsAny)) || (obj is null && this.IsNull());
    }

    /// <inheritdoc/>
    public bool Equals<T>(T other)
        where T : struct, IJsonValue<T>
    {
        return JsonValueHelpers.CompareValues(this, other);
    }

    /// <inheritdoc/>
    public bool Equals(EmbeddedResourceProperty other)
    {
        return JsonValueHelpers.CompareValues(this, other);
    }

    /// <inheritdoc/>
    public void WriteTo(Utf8JsonWriter writer)
    {
        if ((this.backing & Backing.JsonElement) != 0)
        {
            if (this.jsonElementBacking.ValueKind != JsonValueKind.Undefined)
            {
                this.jsonElementBacking.WriteTo(writer);
            }

            return;
        }

        if ((this.backing & Backing.Array) != 0)
        {
            JsonValueHelpers.WriteItems(this.arrayBacking, writer);
            return;
        }

        if ((this.backing & Backing.Object) != 0)
        {
            JsonValueHelpers.WriteProperties(this.objectBacking, writer);
            return;
        }

        if ((this.backing & Backing.Null) != 0)
        {
            writer.WriteNullValue();
            return;
        }
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return JsonValueHelpers.GetHashCode(this);
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return this.Serialize();
    }
}