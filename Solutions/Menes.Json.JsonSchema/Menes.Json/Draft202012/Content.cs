
    //------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

namespace Menes.Json.Draft202012
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Text.RegularExpressions;
    using Menes.Json;

        /// <summary>
    /// A type generated from a JsonSchema specification.
    /// </summary>
    public readonly struct Content :
            IJsonObject<Content>,
                    IEquatable<Content>
    {

        
    
        
        /// <summary>
        /// JSON property name for <see cref="ContentEncoding"/>.
        /// </summary>
        public static readonly ReadOnlyMemory<byte> ContentEncodingUtf8JsonPropertyName = new byte[] { 99, 111, 110, 116, 101, 110, 116, 69, 110, 99, 111, 100, 105, 110, 103 };

        /// <summary>
        /// JSON property name for <see cref="ContentEncoding"/>.
        /// </summary>
        public static readonly string ContentEncodingJsonPropertyName = "contentEncoding";

        
        /// <summary>
        /// JSON property name for <see cref="ContentMediaType"/>.
        /// </summary>
        public static readonly ReadOnlyMemory<byte> ContentMediaTypeUtf8JsonPropertyName = new byte[] { 99, 111, 110, 116, 101, 110, 116, 77, 101, 100, 105, 97, 84, 121, 112, 101 };

        /// <summary>
        /// JSON property name for <see cref="ContentMediaType"/>.
        /// </summary>
        public static readonly string ContentMediaTypeJsonPropertyName = "contentMediaType";

        
        /// <summary>
        /// JSON property name for <see cref="ContentSchema"/>.
        /// </summary>
        public static readonly ReadOnlyMemory<byte> ContentSchemaUtf8JsonPropertyName = new byte[] { 99, 111, 110, 116, 101, 110, 116, 83, 99, 104, 101, 109, 97 };

        /// <summary>
        /// JSON property name for <see cref="ContentSchema"/>.
        /// </summary>
        public static readonly string ContentSchemaJsonPropertyName = "contentSchema";

        
    
    
    
    
    
            private static readonly ImmutableDictionary<string, Func<Content, ValidationContext, ValidationLevel, ValidationContext>> __MenesLocalProperties = CreateLocalPropertyValidators();
    
    

    
        private readonly JsonElement jsonElementBacking;

            private readonly ImmutableDictionary<string, JsonAny>? objectBacking;
    
    
    
    
            private readonly bool? booleanBacking;
    
        /// <summary>
        /// Initializes a new instance of the <see cref="Content"/> struct.
        /// </summary>
        /// <param name="value">The backing <see cref="JsonElement"/>.</param>
        public Content(JsonElement value)
        {
            this.jsonElementBacking = value;
                this.objectBacking = default;
                                this.booleanBacking = default;
            }

            /// <summary>
        /// Initializes a new instance of the <see cref="Content"/> struct.
        /// </summary>
        /// <param name="value">A property dictionary.</param>
        public Content(ImmutableDictionary<string, JsonAny> value)
        {
            this.jsonElementBacking = default;
            this.objectBacking = value;
                                            this.booleanBacking = default;
                }

        /// <summary>
        /// Initializes a new instance of the <see cref="Content"/> struct.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JsonObject"/> from which to construct the value.</param>
        public Content(JsonObject jsonObject)
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

                                            this.booleanBacking = default;
                }
    
    
    
    
            /// <summary>
        /// Initializes a new instance of the <see cref="Content"/> struct.
        /// </summary>
        /// <param name="jsonBoolean">The <see cref="JsonBoolean"/> from which to construct the value.</param>
        public Content(JsonBoolean jsonBoolean)
        {
            if (jsonBoolean.HasJsonElement)
            {
                this.jsonElementBacking = jsonBoolean.AsJsonElement;
                this.booleanBacking = default;
            }
            else
            {
                this.jsonElementBacking = default;
                this.booleanBacking = jsonBoolean.GetBoolean();
            }

                    this.objectBacking = default;
                                        }

                /// <summary>
        /// Initializes a new instance of the <see cref="Content"/> struct.
        /// </summary>
        /// <param name="boolean">The <see cref="bool"/> from which to construct the value.</param>
        public Content(bool boolean)
        {
            this.jsonElementBacking = default;
            this.booleanBacking = boolean;

                    this.objectBacking = default;
                                        }

    
    
    

    
    
            
        /// <summary>
        /// Gets ContentEncoding.
        /// </summary>
        /// <remarks>
        /// {Property title}.
        /// {Property description}.
        /// </remarks>
        /// <example>
        /// {Property examples}.
        /// </example>
        public Menes.Json.JsonString ContentEncoding
        {
            get
            {
                if (this.objectBacking is ImmutableDictionary<string, JsonAny> properties)
                {
                    if(properties.TryGetValue(ContentEncodingJsonPropertyName, out JsonAny result))
                    {
                        return result;
                    }
                }

                if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
                {
                    if (this.jsonElementBacking.TryGetProperty(ContentEncodingUtf8JsonPropertyName.Span, out JsonElement result))
                    {
                        return new  Menes.Json.JsonString(result);
                    }
                }

                return default;
            }
        }

        
        /// <summary>
        /// Gets ContentMediaType.
        /// </summary>
        /// <remarks>
        /// {Property title}.
        /// {Property description}.
        /// </remarks>
        /// <example>
        /// {Property examples}.
        /// </example>
        public Menes.Json.JsonString ContentMediaType
        {
            get
            {
                if (this.objectBacking is ImmutableDictionary<string, JsonAny> properties)
                {
                    if(properties.TryGetValue(ContentMediaTypeJsonPropertyName, out JsonAny result))
                    {
                        return result;
                    }
                }

                if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
                {
                    if (this.jsonElementBacking.TryGetProperty(ContentMediaTypeUtf8JsonPropertyName.Span, out JsonElement result))
                    {
                        return new  Menes.Json.JsonString(result);
                    }
                }

                return default;
            }
        }

        
        /// <summary>
        /// Gets ContentSchema.
        /// </summary>
        /// <remarks>
        /// {Property title}.
        /// {Property description}.
        /// </remarks>
        /// <example>
        /// {Property examples}.
        /// </example>
        public Menes.Json.Draft202012.Schema ContentSchema
        {
            get
            {
                if (this.objectBacking is ImmutableDictionary<string, JsonAny> properties)
                {
                    if(properties.TryGetValue(ContentSchemaJsonPropertyName, out JsonAny result))
                    {
                        return result;
                    }
                }

                if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
                {
                    if (this.jsonElementBacking.TryGetProperty(ContentSchemaUtf8JsonPropertyName.Span, out JsonElement result))
                    {
                        return new  Menes.Json.Draft202012.Schema(result);
                    }
                }

                return default;
            }
        }

                    /// <summary>
        /// Gets a value indicating whether this is backed by a JSON element.
        /// </summary>
        public bool HasJsonElement =>
    
                this.objectBacking is null
            
    
                                    &&
                    this.booleanBacking is null
    
                ;

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

    
    
    
    
                    if (this.booleanBacking is bool booleanBacking)
                {
                    return JsonBoolean.BoolToJsonElement(booleanBacking);
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

    
    
    
    
                    if (this.booleanBacking is bool booleanBacking)
                {
                    return booleanBacking ? JsonValueKind.True : JsonValueKind.False;
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

    
    
    
    
                    if (this.booleanBacking is bool booleanBacking)
                {
                    return new JsonAny(booleanBacking);
                }

    
                return new JsonAny(this.jsonElementBacking);
            }
        }

        /// <summary>
        /// Gets the value as a <see cref="JsonObject"/>.
        /// </summary>
        public JsonObject AsObject
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
        /// Gets the value as a <see cref="JsonArray"/>.
        /// </summary>
        public JsonArray AsArray
        {
            get
            {
    
                return new JsonArray(this.jsonElementBacking);
            }
        }

        /// <summary>
        /// Gets the value as a <see cref="JsonNumber"/>.
        /// </summary>
        public JsonNumber AsNumber
        {
            get
            {
                    return new JsonNumber(this.jsonElementBacking);
            }
        }

        /// <summary>
        /// Gets the value as a <see cref="JsonString"/>.
        /// </summary>
        public JsonString AsString
        {
            get
            {
                    return new JsonString(this.jsonElementBacking);
            }
        }

        /// <summary>
        /// Gets the value as a <see cref="JsonBoolean"/>.
        /// </summary>
        public JsonBoolean AsBoolean
        {
            get
            {
                    if (this.booleanBacking is bool booleanBacking)
                {
                    return new JsonBoolean(booleanBacking);
                }
                    return new JsonBoolean(this.jsonElementBacking);
            }
        }

        /// <summary>
        /// Gets the value as a <see cref="JsonNull"/>.
        /// </summary>
        public JsonNull AsNull
        {
            get
            {
                return default;
            }
        }

    
        
        /// <summary>
        /// Conversion from any.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Content(JsonAny value)
        {
            if (value.HasJsonElement)
            {
                return new Content(value.AsJsonElement);
            }

            return value.As<Content>();
        }

        /// <summary>
        /// Conversion to any.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(Content value)
        {
            return value.AsAny;
        }

    
    
        /// <summary>
        /// Conversion from object.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Content(JsonObject value)
        {
            return new Content(value);
        }

        /// <summary>
        /// Conversion to object.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonObject(Content value)
        {
            return value.AsObject;
        }

                /// <summary>
        /// Implicit conversion to a property dictionary.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator ImmutableDictionary<string, JsonAny>(Content  value)
        {
            return value.AsObject.AsPropertyDictionary;
        }

        /// <summary>
        /// Implicit conversion from a property dictionary.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Content (ImmutableDictionary<string, JsonAny> value)
        {
            return new Content (value);
        }

    
    
    
    
        /// <summary>
        /// Conversion from bool.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Content(bool value)
        {
            return new Content(value);
        }

        /// <summary>
        /// Conversion to bool.
        /// </summary>
        /// <param name="boolean">The value from which to convert.</param>
        public static implicit operator bool(Content boolean)
        {
            return boolean.AsBoolean.GetBoolean();
        }

        /// <summary>
        /// Conversion from bool.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Content(JsonBoolean value)
        {
            return new Content(value);
        }

        /// <summary>
        /// Conversion to bool.
        /// </summary>
        /// <param name="boolean">The value from which to convert.</param>
        public static implicit operator JsonBoolean(Content boolean)
        {
            return boolean.AsBoolean;
        }

    
    
            /// <summary>
        /// Creates an instance of a <see cref="Content"/>.
        /// </summary>
        public static Content Create(
                            Menes.Json.JsonString? contentEncoding = null
        ,             Menes.Json.JsonString? contentMediaType = null
        ,             Menes.Json.Draft202012.Schema? contentSchema = null
        
        )
        {
            var builder = ImmutableDictionary.CreateBuilder<string, JsonAny>();
                            if (contentEncoding is Menes.Json.JsonString contentEncoding__)
            {
                builder.Add(ContentEncodingJsonPropertyName, contentEncoding__);
            }
                    if (contentMediaType is Menes.Json.JsonString contentMediaType__)
            {
                builder.Add(ContentMediaTypeJsonPropertyName, contentMediaType__);
            }
                    if (contentSchema is Menes.Json.Draft202012.Schema contentSchema__)
            {
                builder.Add(ContentSchemaJsonPropertyName, contentSchema__);
            }
                    return builder.ToImmutable();
        }

        
        /// <summary>
        /// Sets contentEncoding.
        /// </summary>
        /// <param name="value">The value to set.</param>
        /// <returns>The entity with the updated property.</returns>
        public Content WithContentEncoding(Menes.Json.JsonString value)
        {
            return this.SetProperty(ContentEncodingJsonPropertyName, value);
        }

        
        /// <summary>
        /// Sets contentMediaType.
        /// </summary>
        /// <param name="value">The value to set.</param>
        /// <returns>The entity with the updated property.</returns>
        public Content WithContentMediaType(Menes.Json.JsonString value)
        {
            return this.SetProperty(ContentMediaTypeJsonPropertyName, value);
        }

        
        /// <summary>
        /// Sets contentSchema.
        /// </summary>
        /// <param name="value">The value to set.</param>
        /// <returns>The entity with the updated property.</returns>
        public Content WithContentSchema(Menes.Json.Draft202012.Schema value)
        {
            return this.SetProperty(ContentSchemaJsonPropertyName, value);
        }

        
    

        /// <summary>
        /// Writes the object to the <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The writer to which to write the object.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
                if (this.objectBacking is ImmutableDictionary<string, JsonAny> objectBacking)
            {
                JsonObject.WriteProperties(objectBacking, writer);
                return;
            }

    
    
    
    
                if (this.booleanBacking is bool booleanBacking)
            {
                writer.WriteBooleanValue(booleanBacking);
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
                JsonValueKind.Object => this.AsObject.Equals(other.AsObject()),
                JsonValueKind.Array => this.AsArray.Equals(other.AsArray()),
                JsonValueKind.Number => this.AsNumber.Equals(other.AsNumber()),
                JsonValueKind.String => this.AsString.Equals(other.AsString()),
                JsonValueKind.Null => true,
                JsonValueKind.True or JsonValueKind.False => this.AsBoolean.Equals(other.AsBoolean()),
                _ => false,
            };
        }

        /// <inheritdoc/>
        public bool Equals(Content other)
        {
            JsonValueKind valueKind = this.ValueKind;

            if (other.ValueKind != valueKind)
            {
                return false;
            }

            return valueKind switch
            {
                JsonValueKind.Object => this.AsObject.Equals(other.AsObject),
                JsonValueKind.Array => this.AsArray.Equals(other.AsArray),
                JsonValueKind.Number => this.AsNumber.Equals(other.AsNumber),
                JsonValueKind.String => this.AsString.Equals(other.AsString),
                JsonValueKind.Null => true,
                JsonValueKind.True or JsonValueKind.False => this.AsBoolean.Equals(other.AsBoolean),
                _ => false,
            };
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

            return false;        }

        /// <inheritdoc/>
        public bool HasProperty(ReadOnlySpan<byte> utf8name)
        {
            if (this.objectBacking is ImmutableDictionary<string, JsonAny> properties)
            {
                return properties.TryGetValue(Encoding.UTF8.GetString(utf8name), out _);
            }

            if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
            {
                return this.jsonElementBacking.TryGetProperty(utf8name, out JsonElement _);
            }

            return false;        }

        /// <inheritdoc/>
        public Content SetProperty<TValue>(string name, TValue value)
            where TValue : IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Object || this.ValueKind == JsonValueKind.Undefined)
            {
                return this.AsObject.SetProperty(name, value);
            }

            return this;
        }

        /// <inheritdoc/>
        public Content SetProperty<TValue>(ReadOnlySpan<char> name, TValue value)
            where TValue : IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Object || this.ValueKind == JsonValueKind.Undefined)
            {
                return this.AsObject.SetProperty(name, value);
            }

            return this;
        }

        /// <inheritdoc/>
        public Content SetProperty<TValue>(ReadOnlySpan<byte> utf8name, TValue value)
            where TValue : IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Object || this.ValueKind == JsonValueKind.Undefined)
            {
                return this.AsObject.SetProperty(utf8name, value);
            }

            return this;
        }

        /// <inheritdoc/>
        public Content RemoveProperty(string name)
        {
            if (this.ValueKind == JsonValueKind.Object)
            {
                return this.AsObject.RemoveProperty(name);
            }

            return this;
        }

        /// <inheritdoc/>
        public Content RemoveProperty(ReadOnlySpan<char> name)
        {
            if (this.ValueKind == JsonValueKind.Object)
            {
                return this.AsObject.RemoveProperty(name);
            }

            return this;
        }

        /// <inheritdoc/>
        public Content RemoveProperty(ReadOnlySpan<byte> utf8Name)
        {
            if (this.ValueKind == JsonValueKind.Object)
            {
                return this.AsObject.RemoveProperty(utf8Name);
            }

            return this;
        }

    
    
        /// <inheritdoc/>
        public T As<T>()
            where T : struct, IJsonValue
        {
            return this.As<Content, T>();
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
    
    
                    result = this.ValidateType(valueKind, result, level);
            if (level == ValidationLevel.Flag && !result.IsValid)
            {
                return result;
            }
        
        
        
        
    
    
    
        
    
    
    
    
    
    
                result = this.ValidateObject(valueKind, result, level);
            if (level == ValidationLevel.Flag && !result.IsValid)
            {
                return result;
            }

    

                return result;
        }

    
    
    
    
    
        private static ImmutableDictionary<string, Func<Content, ValidationContext, ValidationLevel, ValidationContext>> CreateLocalPropertyValidators()
        {
            ImmutableDictionary<string, Func<Content, ValidationContext, ValidationLevel, ValidationContext>>.Builder builder =
                ImmutableDictionary.CreateBuilder<string, Func<Content, ValidationContext, ValidationLevel, ValidationContext>>();

                    builder.Add(
                ContentEncodingJsonPropertyName,
                (that, validationContext, level) =>
                {
                    Menes.Json.JsonString property = that.ContentEncoding;
                    return property.Validate(validationContext, level);
                });
                    builder.Add(
                ContentMediaTypeJsonPropertyName,
                (that, validationContext, level) =>
                {
                    Menes.Json.JsonString property = that.ContentMediaType;
                    return property.Validate(validationContext, level);
                });
                    builder.Add(
                ContentSchemaJsonPropertyName,
                (that, validationContext, level) =>
                {
                    Menes.Json.Draft202012.Schema property = that.ContentSchema;
                    return property.Validate(validationContext, level);
                });
        
            return builder.ToImmutable();
        }

    
    
    
            private ValidationContext ValidateObject(JsonValueKind valueKind, in ValidationContext validationContext, ValidationLevel level)
        {
            ValidationContext result = validationContext;

            if (valueKind != JsonValueKind.Object)
            {
                return result;
            }

        
        
        
            foreach (Property property in this.EnumerateObject())
            {
                string propertyName = property.Name;

        
                        if (__MenesLocalProperties.TryGetValue(propertyName, out Func<Content, ValidationContext, ValidationLevel, ValidationContext>? propertyValidator))
                {
                    result = result.WithLocalProperty(propertyName);
                    var propertyResult = propertyValidator(this, result, level);
                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);
                    if (level == ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }

            
                }
        
        
        
        
        
        
                    }

        
        
        
            return result;
        }

    
            

            

            

            

    
    
    
            
        private ValidationContext ValidateType(JsonValueKind valueKind, in ValidationContext validationContext, ValidationLevel level)
        {
            ValidationContext result = validationContext;
            bool isValid = false;

        
                
            ValidationContext localResultObject = Menes.Json.Validate.TypeObject(valueKind, result, level);
            if (level == ValidationLevel.Flag && localResultObject.IsValid)
            {
                return validationContext;
            }

            if (localResultObject.IsValid)
            {
                isValid = true;
            }

        
        
        
        
                
            ValidationContext localResultBoolean = Menes.Json.Validate.TypeBoolean(valueKind, result, level);
            if (level == ValidationLevel.Flag && localResultBoolean.IsValid)
            {
                return validationContext;
            }

            if (localResultBoolean.IsValid)
            {
                isValid = true;
            }

        
        
            result = result.MergeResults(
                isValid,
                level
        
                
                , localResultObject
        
        
        
                
                , localResultBoolean
        
                        );

            return result;
        }

    
    
    
    }
    }
    