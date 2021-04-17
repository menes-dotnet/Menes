
    //------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

namespace Menes.Json
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
    public readonly struct Format :
            IJsonObject<Format>,
                    IEquatable<Format>
    {
    
        
        /// <summary>
        /// JSON property name for <see cref="Format1"/>.
        /// </summary>
        public static readonly ReadOnlyMemory<byte> Format1Utf8JsonPropertyName = new byte[] { 102, 111, 114, 109, 97, 116 };

        /// <summary>
        /// JSON property name for <see cref="Format1"/>.
        /// </summary>
        public static readonly JsonEncodedText Format1JsonPropertyName = JsonEncodedText.Encode( Format1Utf8JsonPropertyName.Span);

        
    
    
    
    
    
            private static readonly ImmutableDictionary<JsonEncodedText, Func<Format, ValidationContext, ValidationLevel, ValidationContext>> __MenesLocalProperties = CreateLocalPropertyValidators();
    
    

    
        private readonly JsonElement jsonElementBacking;

            private readonly ImmutableDictionary<JsonEncodedText, JsonAny>? objectBacking;
    
    
    
    
            private readonly bool? booleanBacking;
    
        /// <summary>
        /// Initializes a new instance of the <see cref="Format"/> struct.
        /// </summary>
        /// <param name="value">The backing <see cref="JsonElement"/>.</param>
        public Format(JsonElement value)
        {
            this.jsonElementBacking = value;
                this.objectBacking = default;
                                this.booleanBacking = default;
            }

            /// <summary>
        /// Initializes a new instance of the <see cref="Format"/> struct.
        /// </summary>
        /// <param name="value">A property dictionary.</param>
        public Format(ImmutableDictionary<JsonEncodedText, JsonAny> value)
        {
            this.jsonElementBacking = default;
            this.objectBacking = value;
                                            this.booleanBacking = default;
                }

        /// <summary>
        /// Initializes a new instance of the <see cref="Format"/> struct.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JsonObject"/> from which to construct the value.</param>
        public Format(JsonObject jsonObject)
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
        /// Initializes a new instance of the <see cref="Format"/> struct.
        /// </summary>
        /// <param name="jsonBoolean">The <see cref="JsonBoolean"/> from which to construct the value.</param>
        public Format(JsonBoolean jsonBoolean)
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
        /// Initializes a new instance of the <see cref="Format"/> struct.
        /// </summary>
        /// <param name="boolean">The <see cref="bool"/> from which to construct the value.</param>
        public Format(bool boolean)
        {
            this.jsonElementBacking = default;
            this.booleanBacking = boolean;

                    this.objectBacking = default;
                                        }

    
    
    

    
            
        /// <summary>
        /// Gets Format1.
        /// </summary>
        /// <remarks>
        /// {Property title}.
        /// {Property description}.
        /// </remarks>
        /// <example>
        /// {Property examples}.
        /// </example>
        public Menes.Json.JsonString Format1
        {
            get
            {
                if (this.objectBacking is ImmutableDictionary<JsonEncodedText, JsonAny> properties)
                {
                    if(properties.TryGetValue(Format1JsonPropertyName, out JsonAny result))
                    {
                        return result;
                    }
                }

                if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
                {
                    if (this.jsonElementBacking.TryGetProperty(Format1Utf8JsonPropertyName.Span, out JsonElement result))
                    {
                        return new  Menes.Json.JsonString(result);
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
              
                if (this.objectBacking is ImmutableDictionary<JsonEncodedText, JsonAny> objectBacking)
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
                    if (this.objectBacking is ImmutableDictionary<JsonEncodedText, JsonAny>)
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
                    if (this.objectBacking is ImmutableDictionary<JsonEncodedText, JsonAny> objectBacking)
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
                    if (this.objectBacking is ImmutableDictionary<JsonEncodedText, JsonAny> objectBacking)
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
        public static implicit operator Format(JsonAny value)
        {
            if (value.HasJsonElement)
            {
                return new Format(value.AsJsonElement);
            }

            return value.As<Format>();
        }

        /// <summary>
        /// Conversion to any.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(Format value)
        {
            return value.AsAny;
        }

    
    
        /// <summary>
        /// Conversion from object.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Format(JsonObject value)
        {
            return new Format(value);
        }

        /// <summary>
        /// Conversion to object.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonObject(Format value)
        {
            return value.AsObject;
        }

                /// <summary>
        /// Implicit conversion to a property dictionary.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator ImmutableDictionary<JsonEncodedText, JsonAny>(Format  value)
        {
            return value.AsObject.AsPropertyDictionary;
        }

        /// <summary>
        /// Implicit conversion from a property dictionary.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Format (ImmutableDictionary<JsonEncodedText, JsonAny> value)
        {
            return new Format (value);
        }

    
    
    
    
        /// <summary>
        /// Conversion from bool.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Format(bool value)
        {
            return new Format(value);
        }

        /// <summary>
        /// Conversion to bool.
        /// </summary>
        /// <param name="boolean">The value from which to convert.</param>
        public static implicit operator bool(Format boolean)
        {
            return boolean.AsBoolean.GetBoolean();
        }

        /// <summary>
        /// Conversion from bool.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Format(JsonBoolean value)
        {
            return new Format(value);
        }

        /// <summary>
        /// Conversion to bool.
        /// </summary>
        /// <param name="boolean">The value from which to convert.</param>
        public static implicit operator JsonBoolean(Format boolean)
        {
            return boolean.AsBoolean;
        }

    
            /// <summary>
        /// Creates an instance of a <see cref="Format"/>.
        /// </summary>
        public static Format Create(
                            Menes.Json.JsonString? format1 = null
                )
        {
            var builder = ImmutableDictionary.CreateBuilder<JsonEncodedText, JsonAny>();
                            if (format1 is Menes.Json.JsonString format1__)
            {
                builder.Add(Format1JsonPropertyName, format1__);
            }
                    return builder.ToImmutable();
        }

        
        /// <summary>
        /// Sets format.
        /// </summary>
        /// <param name="value">The value to set.</param>
        /// <returns>The entity with the updated property.</returns>
        public Format WithFormat1(Menes.Json.JsonString value)
        {
            return this.SetProperty(Format1JsonPropertyName, value);
        }

        
    

        /// <summary>
        /// Writes the object to the <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The writer to which to write the object.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
                if (this.objectBacking is ImmutableDictionary<JsonEncodedText, JsonAny> objectBacking)
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
        public bool TryGetProperty(JsonEncodedText name, out JsonAny value)
        {
            return this.AsObject.TryGetProperty(name, out value);
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
        public bool Equals(Format other)
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
        public bool HasProperty(JsonEncodedText name)
        {
            if (this.objectBacking is ImmutableDictionary<JsonEncodedText, JsonAny> properties)
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
        public bool HasProperty(string name)
        {
            if (this.objectBacking is ImmutableDictionary<JsonEncodedText, JsonAny> properties)
            {
                return properties.TryGetValue(JsonEncodedText.Encode(name), out _);
            }

            if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
            {
                return this.jsonElementBacking.TryGetProperty(name, out JsonElement _);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool HasProperty(ReadOnlySpan<char> name)
        {
            if (this.objectBacking is ImmutableDictionary<JsonEncodedText, JsonAny> properties)
            {
                return properties.TryGetValue(JsonEncodedText.Encode(name), out _);
            }

            if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
            {
                return this.jsonElementBacking.TryGetProperty(name, out JsonElement _);
            }

            return false;        }

        /// <inheritdoc/>
        public bool HasProperty(ReadOnlySpan<byte> utf8name)
        {
            if (this.objectBacking is ImmutableDictionary<JsonEncodedText, JsonAny> properties)
            {
                return properties.TryGetValue(JsonEncodedText.Encode(utf8name), out _);
            }

            if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
            {
                return this.jsonElementBacking.TryGetProperty(utf8name, out JsonElement _);
            }

            return false;        }

        /// <inheritdoc/>
        public Format SetProperty<TValue>(JsonEncodedText name, TValue value)
            where TValue : IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Object || this.ValueKind == JsonValueKind.Undefined)
            {
                return this.AsObject.SetProperty(name, value);
            }

            return this;
        }

        /// <inheritdoc/>
        public Format SetProperty<TValue>(string name, TValue value)
            where TValue : IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Object || this.ValueKind == JsonValueKind.Undefined)
            {
                return this.AsObject.SetProperty(name, value);
            }

            return this;
        }

        /// <inheritdoc/>
        public Format SetProperty<TValue>(ReadOnlySpan<char> name, TValue value)
            where TValue : IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Object || this.ValueKind == JsonValueKind.Undefined)
            {
                return this.AsObject.SetProperty(name, value);
            }

            return this;
        }

        /// <inheritdoc/>
        public Format SetProperty<TValue>(ReadOnlySpan<byte> utf8name, TValue value)
            where TValue : IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Object || this.ValueKind == JsonValueKind.Undefined)
            {
                return this.AsObject.SetProperty(utf8name, value);
            }

            return this;
        }

        /// <inheritdoc/>
        public Format RemoveProperty(JsonEncodedText name)
        {
            if (this.ValueKind == JsonValueKind.Object)
            {
                return this.AsObject.RemoveProperty(name);
            }

            return this;
        }

        /// <inheritdoc/>
        public Format RemoveProperty(string name)
        {
            if (this.ValueKind == JsonValueKind.Object)
            {
                return this.AsObject.RemoveProperty(name);
            }

            return this;
        }

        /// <inheritdoc/>
        public Format RemoveProperty(ReadOnlySpan<char> name)
        {
            if (this.ValueKind == JsonValueKind.Object)
            {
                return this.AsObject.RemoveProperty(name);
            }

            return this;
        }

        /// <inheritdoc/>
        public Format RemoveProperty(ReadOnlySpan<byte> utf8Name)
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
            return this.As<Format, T>();
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

    
    
    
    
    
        private static ImmutableDictionary<JsonEncodedText, Func<Format, ValidationContext, ValidationLevel, ValidationContext>> CreateLocalPropertyValidators()
        {
            ImmutableDictionary<JsonEncodedText, Func<Format, ValidationContext, ValidationLevel, ValidationContext>>.Builder builder =
                ImmutableDictionary.CreateBuilder<JsonEncodedText, Func<Format, ValidationContext, ValidationLevel, ValidationContext>>();

                    builder.Add(
                Format1JsonPropertyName,
                (that, validationContext, level) =>
                {
                    JsonString property = that.Format1;
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
                JsonEncodedText propertyName = property.NameAsJsonEncodedText;

        
                        if (__MenesLocalProperties.TryGetValue(propertyName, out Func<Format, ValidationContext, ValidationLevel, ValidationContext>? propertyValidator))
                {
                    result = result.WithLocalProperty(propertyName);
                    result = propertyValidator(this, result, level);
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
    