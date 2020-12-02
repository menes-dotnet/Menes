// <copyright file="Draft201909MetaContent.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace IdFeature.UnnormalizedIdsAreAllowedButDiscouraged
{
public readonly struct Draft201909MetaContent : Menes.IJsonObject<Draft201909MetaContent>
{
public static readonly Draft201909MetaContent Null = default(Draft201909MetaContent);
private static readonly System.ReadOnlyMemory<char> _MenesContentMediaTypeJsonPropertyName = System.MemoryExtensions.AsMemory("contentMediaType");
private static readonly System.ReadOnlyMemory<char> _MenesContentEncodingJsonPropertyName = System.MemoryExtensions.AsMemory("contentEncoding");
private static readonly System.ReadOnlyMemory<char> _MenesContentSchemaJsonPropertyName = System.MemoryExtensions.AsMemory("contentSchema");
private static readonly System.ReadOnlyMemory<byte>  _MenesContentMediaTypeUtf8JsonPropertyName = new byte[] { 99, 111, 110, 116, 101, 110, 116, 77, 101, 100, 105, 97, 84, 121, 112, 101 };
private static readonly System.ReadOnlyMemory<byte>  _MenesContentEncodingUtf8JsonPropertyName = new byte[] { 99, 111, 110, 116, 101, 110, 116, 69, 110, 99, 111, 100, 105, 110, 103 };
private static readonly System.ReadOnlyMemory<byte>  _MenesContentSchemaUtf8JsonPropertyName = new byte[] { 99, 111, 110, 116, 101, 110, 116, 83, 99, 104, 101, 109, 97 };
private static readonly  System.Text.Json.JsonEncodedText _MenesContentMediaTypeEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesContentMediaTypeUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesContentEncodingEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesContentEncodingUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesContentSchemaEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesContentSchemaUtf8JsonPropertyName.Span);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking;
private readonly Menes.JsonBoolean? _menesBooleanTypeBacking;
private readonly Menes.JsonString? contentMediaType;
private readonly Menes.JsonString? contentEncoding;
private readonly Draft201909Schema? contentSchema;
public Draft201909MetaContent(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
this._menesBooleanTypeBacking = default;
this.contentMediaType = default;
this.contentEncoding = default;
this.contentSchema = default;
}
public Draft201909MetaContent(Menes.JsonString? contentMediaType = null, Menes.JsonString? contentEncoding = null, Draft201909Schema? contentSchema = null)
{
    this._menesJsonElementBacking = default;
this.contentMediaType = contentMediaType;
this.contentEncoding = contentEncoding;
this.contentSchema = contentSchema;
this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
this._menesBooleanTypeBacking = default;
}
public Draft201909MetaContent(Menes.JsonBoolean value)
{
    this._menesJsonElementBacking = default;
    this._menesBooleanTypeBacking = value;
this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
this.contentMediaType = default;
this.contentEncoding = default;
this.contentSchema = default;
}
private Draft201909MetaContent(Menes.JsonString? contentMediaType, Menes.JsonString? contentEncoding, Draft201909Schema? contentSchema, Menes.JsonBoolean? _menesBooleanTypeBacking, in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking)
{
    this._menesJsonElementBacking = default;
this.contentMediaType = contentMediaType;
this.contentEncoding = contentEncoding;
this.contentSchema = contentSchema;
this._menesBooleanTypeBacking = _menesBooleanTypeBacking;
this._menesAdditionalPropertiesBacking = _menesAdditionalPropertiesBacking;
}
public static implicit operator Menes.JsonBoolean(Draft201909MetaContent value)
{
    return value.As<Menes.JsonBoolean>();
}
public static implicit operator Draft201909MetaContent(Menes.JsonBoolean value)
{
    return value.As<Draft201909MetaContent>();
}
public static implicit operator bool(Draft201909MetaContent value)
{
    return (bool)(Menes.JsonBoolean)value;
}
public static implicit operator Draft201909MetaContent(bool value)
{
    return (Draft201909MetaContent)(Menes.JsonBoolean)value;
}
/// <inheritdoc />
public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
/// <inheritdoc />
public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
/// <inheritdoc />
public bool IsNumber => false;
/// <inheritdoc />
public bool IsInteger=> false;
/// <inheritdoc />
public bool IsString => false;
/// <inheritdoc />
public bool IsObject => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object) || (!this.HasJsonElement && !this.AllBackingFieldsAreNull());
/// <inheritdoc />
public bool IsBoolean => (this.HasJsonElement && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.True || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.False)) || (!this.HasJsonElement && _menesBooleanTypeBacking is not null);
/// <inheritdoc />
public bool IsArray => false;
/// <inheritdoc />
public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
/// <inheritdoc />
public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
public Menes.JsonString? ContentMediaType => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonString>(_MenesContentMediaTypeUtf8JsonPropertyName.Span) : this.contentMediaType;
public Menes.JsonString? ContentEncoding => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonString>(_MenesContentEncodingUtf8JsonPropertyName.Span) : this.contentEncoding;
public Draft201909Schema? ContentSchema => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909Schema>(_MenesContentSchemaUtf8JsonPropertyName.Span) : this.contentSchema;
public int PropertyCount
{
   get
   {
       if (this.HasJsonElement)
       {
           int jsonPropertyIndex = 0;
           foreach (var property in this.JsonElement.EnumerateObject())
           {
               jsonPropertyIndex++;
           }
           return jsonPropertyIndex;
       }
       else
       {
           return 3 + this._menesAdditionalPropertiesBacking.Length;
       }
   }
}
/// <inheritdoc />
public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
{
Menes.ValidationContext result = validationContext;
if (level != Menes.ValidationLevel.Flag)
{
    result = result.UsingStack();
}
if (!this.IsObject && !this.IsBoolean)
{
if (level >= Menes.ValidationLevel.Basic)
{
    result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of object,boolean");
}
else
{
    result = result.WithResult(isValid: false);
}
        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
        {
            return result;
        }
}
if (this.IsObject)
{
    result = result.WithLocalProperty("contentMediaType");
    if (this.TryGetProperty<Menes.JsonString>(_MenesContentMediaTypeJsonPropertyName.Span, out Menes.JsonString value0))
    {
        result = value0.Validate(result, level);
        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
        {
            return result;
        }
    }
    else
    {
if (level == Menes.ValidationLevel.Verbose)
{
    result = result.WithResult(isValid: true);
}
    }
    result = result.WithLocalProperty("contentEncoding");
    if (this.TryGetProperty<Menes.JsonString>(_MenesContentEncodingJsonPropertyName.Span, out Menes.JsonString value1))
    {
        result = value1.Validate(result, level);
        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
        {
            return result;
        }
    }
    else
    {
if (level == Menes.ValidationLevel.Verbose)
{
    result = result.WithResult(isValid: true);
}
    }
    result = result.WithLocalProperty("contentSchema");
    if (this.TryGetProperty<Draft201909Schema>(_MenesContentSchemaJsonPropertyName.Span, out Draft201909Schema value2))
    {
        result = value2.Validate(result, level);
        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
        {
            return result;
        }
    }
    else
    {
if (level == Menes.ValidationLevel.Verbose)
{
    result = result.WithResult(isValid: true);
}
    }
}
return result;
}
/// <inheritdoc />
public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
{
    if (this.HasJsonElement)
    {
        this.JsonElement.WriteTo(writer);
        return;
    }
writer.WriteStartObject();
    if (this.contentMediaType is Menes.JsonString contentMediaType)
    {
        writer.WritePropertyName(_MenesContentMediaTypeEncodedJsonPropertyName);
        contentMediaType.WriteTo(writer);
    }
    if (this.contentEncoding is Menes.JsonString contentEncoding)
    {
        writer.WritePropertyName(_MenesContentEncodingEncodedJsonPropertyName);
        contentEncoding.WriteTo(writer);
    }
    if (this.contentSchema is Draft201909Schema contentSchema)
    {
        writer.WritePropertyName(_MenesContentSchemaEncodedJsonPropertyName);
        contentSchema.WriteTo(writer);
    }
    foreach (var property in this._menesAdditionalPropertiesBacking)
    {
        property.WriteTo(writer);
    }
writer.WriteEndObject();
}
/// <inheritdoc />
public T As<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(Draft201909MetaContent))
{
    return Corvus.Extensions.CastTo<T>.From(this);
}
    return Menes.JsonValue.As<Draft201909MetaContent, T>(this);
}
/// <inheritdoc />
public bool Is<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(Draft201909MetaContent))
{
    return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
}
    return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
}
/// <inheritdoc/>
public bool Equals<T>(in T other)
    where T : struct, Menes.IJsonValue
{
return false;
}
/// <inheritdoc/>
public bool HasProperty(System.ReadOnlySpan<char> propertyName)
{
    if (this.HasJsonElement && this.JsonElement.TryGetProperty(propertyName, out _))
    {
        return true;
    }
    else
    {
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentMediaTypeJsonPropertyName.Span))
    {
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentEncodingJsonPropertyName.Span))
    {
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentSchemaJsonPropertyName.Span))
    {
        return true;
    }
    foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
    {
        if (additionalProperty.NameEquals(propertyName))
        {
            return true;
        }
    }
    }
    return false;
}
/// <inheritdoc/>
public bool HasProperty(string propertyName)
{
    if (this.HasJsonElement && this.JsonElement.TryGetProperty(propertyName, out _))
    {
        return true;
    }
    else
    {
    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesContentMediaTypeJsonPropertyName.Span))
    {
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesContentEncodingJsonPropertyName.Span))
    {
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesContentSchemaJsonPropertyName.Span))
    {
        return true;
    }
    foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
    {
        if (additionalProperty.NameEquals(propertyName))
        {
            return true;
        }
    }
    }
    return false;
}
/// <inheritdoc/>
public bool HasProperty(System.ReadOnlySpan<byte> propertyName)
{
    if (this.HasJsonElement && this.JsonElement.TryGetProperty(propertyName, out _))
    {
        return true;
    }
    else
    {
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentMediaTypeUtf8JsonPropertyName.Span))
    {
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentEncodingUtf8JsonPropertyName.Span))
    {
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentSchemaUtf8JsonPropertyName.Span))
    {
        return true;
    }
    foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
    {
        if (additionalProperty.NameEquals(propertyName))
        {
            return true;
        }
    }
    }
    return false;
}
/// <inheritdoc />
public bool TryGetProperty<T>(System.ReadOnlySpan<char> propertyName, out T property)
    where T : struct, Menes.IJsonValue
{
    if (this.HasJsonElement)
    {
        if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
        {
            property = Menes.JsonValue.As<T>(value);
            return true;
        }
        property = default;
        return false;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentMediaTypeJsonPropertyName.Span))
    {
        if (!(this.ContentMediaType?.As<T>() is T result))
        {
            property = default;
            return false;
        }
        property = result;
        return true;
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentEncodingJsonPropertyName.Span))
    {
        if (!(this.ContentEncoding?.As<T>() is T result))
        {
            property = default;
            return false;
        }
        property = result;
        return true;
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentSchemaJsonPropertyName.Span))
    {
        if (!(this.ContentSchema?.As<T>() is T result))
        {
            property = default;
            return false;
        }
        property = result;
        return true;
        return true;
    }
    foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
    {
        if (additionalProperty.NameEquals(propertyName))
        {
            property = additionalProperty.Value.As<T>();
            return true;
        }
    }
        property = default;
        return false;
}
/// <inheritdoc />
public bool TryGetProperty<T>(string propertyName, out T property)
    where T : struct, Menes.IJsonValue
{
    if (this.HasJsonElement)
    {
        if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
        {
            property = Menes.JsonValue.As<T>(value);
            return true;
        }
        property = default;
        return false;
    }
    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesContentMediaTypeJsonPropertyName.Span))
    {
        if (!(this.ContentMediaType?.As<T>() is T result))
        {
            property = default;
            return false;
        }
        property = result;
        return true;
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesContentEncodingJsonPropertyName.Span))
    {
        if (!(this.ContentEncoding?.As<T>() is T result))
        {
            property = default;
            return false;
        }
        property = result;
        return true;
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesContentSchemaJsonPropertyName.Span))
    {
        if (!(this.ContentSchema?.As<T>() is T result))
        {
            property = default;
            return false;
        }
        property = result;
        return true;
        return true;
    }
    foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
    {
        if (additionalProperty.NameEquals(propertyName))
        {
            property = additionalProperty.Value.As<T>();
            return true;
        }
    }
        property = default;
        return false;
}
/// <inheritdoc />
public bool TryGetProperty<T>(System.ReadOnlySpan<byte> propertyName, out T property)
    where T : struct, Menes.IJsonValue
{
    if (this.HasJsonElement)
    {
        if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
        {
            property = Menes.JsonValue.As<T>(value);
            return true;
        }
        property = default;
        return false;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentMediaTypeUtf8JsonPropertyName.Span))
    {
        if (!(this.ContentMediaType?.As<T>() is T result))
        {
            property = default;
            return false;
        }
        property = result;
        return true;
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentEncodingUtf8JsonPropertyName.Span))
    {
        if (!(this.ContentEncoding?.As<T>() is T result))
        {
            property = default;
            return false;
        }
        property = result;
        return true;
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentSchemaUtf8JsonPropertyName.Span))
    {
        if (!(this.ContentSchema?.As<T>() is T result))
        {
            property = default;
            return false;
        }
        property = result;
        return true;
        return true;
    }
    foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
    {
        if (additionalProperty.NameEquals(propertyName))
        {
            property = additionalProperty.Value.As<T>();
            return true;
        }
    }
        property = default;
        return false;
}
/// <inheritdoc />
public bool TryGetPropertyAtIndex(int index, out Menes.IProperty result)
{
    var rc = this.TryGetPropertyAtIndex(index, out Menes.Property<Draft201909MetaContent> prop);
    result = prop;
    return rc;
}
public Draft201909MetaContent RemoveProperty(string propertyName)
{
    return this.SetProperty(propertyName, Menes.JsonNull.Instance);
}
public Draft201909MetaContent RemoveProperty(System.ReadOnlySpan<char> propertyName)
{
    return this.SetProperty(propertyName, Menes.JsonNull.Instance);
}
public Draft201909MetaContent RemoveProperty(System.ReadOnlySpan<byte> propertyName)
{
    return this.SetProperty(propertyName, Menes.JsonNull.Instance);
}
public Draft201909MetaContent SetProperty<T>(string name, T value)
where T : struct, Menes.IJsonValue
{
    var propertyName = System.MemoryExtensions.AsSpan(name);
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentMediaTypeJsonPropertyName.Span))
{
    return this.WithContentMediaType(value.As<Menes.JsonString>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentEncodingJsonPropertyName.Span))
{
    return this.WithContentEncoding(value.As<Menes.JsonString>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentSchemaJsonPropertyName.Span))
{
    return this.WithContentSchema(value.As<Draft201909Schema>());
}
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty<Menes.JsonAny>>();
bool added = false;
foreach (var property in this._menesAdditionalPropertiesBacking)
{
    if (!property.NameEquals(propertyName))
    {
        arrayBuilder.Add(property);
    }
    else
    {
        arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
        added = true;
    }
}
if (!added)
{
        arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
}
return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
return this;
}
public Draft201909MetaContent SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)
where T : struct, Menes.IJsonValue
{
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentMediaTypeJsonPropertyName.Span))
{
    return this.WithContentMediaType(value.As<Menes.JsonString>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentEncodingJsonPropertyName.Span))
{
    return this.WithContentEncoding(value.As<Menes.JsonString>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentSchemaJsonPropertyName.Span))
{
    return this.WithContentSchema(value.As<Draft201909Schema>());
}
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty<Menes.JsonAny>>();
bool added = false;
foreach (var property in this._menesAdditionalPropertiesBacking)
{
    if (!property.NameEquals(propertyName))
    {
        arrayBuilder.Add(property);
    }
    else
    {
        arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
        added = true;
    }
}
if (!added)
{
        arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
}
return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
return this;
}
public Draft201909MetaContent SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)
where T : struct, Menes.IJsonValue
{
    System.Span<char> name = stackalloc char[utf8Name.Length];
    int writtenCount = System.Text.Encoding.UTF8.GetChars(utf8Name, name);
    var propertyName = name.Slice(0, writtenCount);
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentMediaTypeJsonPropertyName.Span))
{
    return this.WithContentMediaType(value.As<Menes.JsonString>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentEncodingJsonPropertyName.Span))
{
    return this.WithContentEncoding(value.As<Menes.JsonString>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentSchemaJsonPropertyName.Span))
{
    return this.WithContentSchema(value.As<Draft201909Schema>());
}
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty<Menes.JsonAny>>();
bool added = false;
foreach (var property in this._menesAdditionalPropertiesBacking)
{
    if (!property.NameEquals(propertyName))
    {
        arrayBuilder.Add(property);
    }
    else
    {
        arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
        added = true;
    }
}
if (!added)
{
        arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
}
return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
return this;
}
public Draft201909MetaContent.MenesPropertyEnumerator GetEnumerator()
{
    return new MenesPropertyEnumerator(this);
}
/// <summary>
/// Enumerate the properties in the object.
/// </summary>
/// <returns>The object enumerator.</returns>
public MenesPropertyEnumerator EnumerateObject()
{
    return new MenesPropertyEnumerator(this);
}
System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
{
    return this.GetEnumerator();
}
System.Collections.Generic.IEnumerator<Menes.Property<Draft201909MetaContent>> System.Collections.Generic.IEnumerable<Menes.Property<Draft201909MetaContent>>.GetEnumerator()
{
    return this.GetEnumerator();
}
public Draft201909MetaContent WithContentMediaType(Menes.JsonString value)
{
    return new Draft201909MetaContent(value, this.contentEncoding, this.contentSchema, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
}
public Draft201909MetaContent WithContentEncoding(Menes.JsonString value)
{
    return new Draft201909MetaContent(this.contentMediaType, value, this.contentSchema, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
}
public Draft201909MetaContent WithContentSchema(Draft201909Schema value)
{
    return new Draft201909MetaContent(this.contentMediaType, this.contentEncoding, value, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
}
private TPropertyValue GetPropertyFromJsonElement<TPropertyValue>(System.ReadOnlySpan<byte> propertyName)
    where TPropertyValue : struct, Menes.IJsonValue
{
    return this.GetOptionalPropertyFromJsonElement<TPropertyValue>(propertyName) ?? default;
}
private TPropertyValue? GetOptionalPropertyFromJsonElement<TPropertyValue>(System.ReadOnlySpan<byte> propertyName)
    where TPropertyValue : struct, Menes.IJsonValue
{
    return this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object ?
         (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
             ? Menes.JsonValue.As<TPropertyValue>(property)
             : null)
         : null;
}
private bool AllBackingFieldsAreNull()
{
if (this.contentMediaType is not null)
{
    return false;
}
if (this.contentEncoding is not null)
{
    return false;
}
if (this.contentSchema is not null)
{
    return false;
}
if (this._menesAdditionalPropertiesBacking.Length > 0)
{
    return false;
}
if (this._menesBooleanTypeBacking is not null)
{
    return false;
}
return true;
}
/// <inheritdoc />
private bool TryGetPropertyAtIndex(int index, out Menes.Property<Draft201909MetaContent> result)
{
if (this.HasJsonElement)
{
    int jsonPropertyIndex = 0;
    foreach (var property in this.JsonElement.EnumerateObject())
    {
        if (jsonPropertyIndex == index)
        {
            result = new Menes.Property<Draft201909MetaContent>(property);
            return true;
        }
        jsonPropertyIndex++;
    }
}
int currentIndex = 0;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaContent>(this, _MenesContentMediaTypeJsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaContent>(this, _MenesContentEncodingJsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaContent>(this, _MenesContentSchemaJsonPropertyName);
      return true;
    }
    currentIndex++;
foreach (var property in this._menesAdditionalPropertiesBacking)
{
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaContent>(this, property.NameAsMemory);
        return true;
    }
    currentIndex++;
}
    result = default;;
    return false;
}
private Draft201909MetaContent WithAdditionalProperties(System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> value)
{
    return new Draft201909MetaContent(this.contentMediaType, this.contentEncoding, this.contentSchema, this._menesBooleanTypeBacking, value);
}
/// <summary>
/// An enumerator for the properties in a <see cref="Draft201909MetaContent"/>.
/// </summary>
public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.Property<Draft201909MetaContent>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.Property<Draft201909MetaContent>>, System.Collections.IEnumerator
{
    private Draft201909MetaContent instance;
    private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
    private bool hasJsonEnumerator;
    private int index;
    private int propertyCount;
    internal MenesPropertyEnumerator(Draft201909MetaContent instance)
    {
        this.instance = instance;
        this.propertyCount = instance.PropertyCount;
        if (this.instance.HasJsonElement)
        {
            this.index = -2;
            this.hasJsonEnumerator = true;
            this.jsonEnumerator = this.instance.JsonElement.EnumerateObject();
        }
        else
        {
            this.index = -1;
            this.hasJsonEnumerator = false;
            this.jsonEnumerator = default;
        }
    }
    /// <inheritdoc/>
    public Menes.Property<Draft201909MetaContent> Current
    {
        get
        {
            if (this.hasJsonEnumerator)
            {
                return new Menes.Property<Draft201909MetaContent>(this.jsonEnumerator.Current);
            }
            else if (this.index >= 0)
            {
                if (this.instance.TryGetPropertyAtIndex(this.index, out Menes.Property<Draft201909MetaContent> result))
                {
                    return result;
                }
                throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
            }
            return new Menes.Property<Draft201909MetaContent>(this.instance, default);
        }
    }
    /// <inheritdoc/>
    object System.Collections.IEnumerator.Current => this.Current;
    /// <summary>
    /// Returns a fresh copy of the enumerator
    /// </summary>
    /// <returns>An enumerator for the properties in a <see cref="Draft201909MetaContent"/>.</returns>
    public MenesPropertyEnumerator GetEnumerator()
    {
        MenesPropertyEnumerator result = this;
        result.Reset();
        return result;
    }
    /// <inheritdoc/>
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    /// <inheritdoc/>
    System.Collections.Generic.IEnumerator<Menes.Property<Draft201909MetaContent>> System.Collections.Generic.IEnumerable<Menes.Property<Draft201909MetaContent>>.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    /// <inheritdoc/>
    public void Dispose()
    {
        if (this.hasJsonEnumerator)
        {
            this.jsonEnumerator.Dispose();
        }
    }
    /// <inheritdoc/>
    public void Reset()
    {
        if (this.hasJsonEnumerator)
        {
            this.jsonEnumerator.Reset();
        }
    }
    /// <inheritdoc/>
    public bool MoveNext()
    {
        if (this.hasJsonEnumerator)
        {
            return this.jsonEnumerator.MoveNext();
        }
        else
        {
            if (this.index + 1 < this.propertyCount)
            {
                this.index++;
                return true;
            }
            return false;
        }
    }
}
}
}
