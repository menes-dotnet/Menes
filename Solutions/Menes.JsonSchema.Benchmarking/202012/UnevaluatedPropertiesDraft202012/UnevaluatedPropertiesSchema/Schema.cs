
    //------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

namespace UnevaluatedPropertiesDraft202012Feature.UnevaluatedPropertiesSchema
{
    using System;
    using System.Collections.Immutable;
    using System.Text;
    using System.Text.Json;
    using System.Text.RegularExpressions;
    using Menes.Json;

        /// <summary>
    /// A type generated from a JsonSchema specification.
    /// </summary>
    public readonly struct Schema :
            IJsonObject<Schema>,
                    IEquatable<Schema>
    {

        
    
    
    
    
    
    
    

    
        private readonly JsonElement jsonElementBacking;

            private readonly ImmutableDictionary<string, JsonAny>? objectBacking;
    
    
    
    
    
        /// <summary>
        /// Initializes a new instance of the <see cref="Schema"/> struct.
        /// </summary>
        /// <param name="value">The backing <see cref="JsonElement"/>.</param>
        public Schema(JsonElement value)
        {
            this.jsonElementBacking = value;
                this.objectBacking = default;
                            }

            /// <summary>
        /// Initializes a new instance of the <see cref="Schema"/> struct.
        /// </summary>
        /// <param name="value">A property dictionary.</param>
        public Schema(ImmutableDictionary<string, JsonAny> value)
        {
            this.jsonElementBacking = default;
            this.objectBacking = value;
                                        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Schema"/> struct.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JsonObject"/> from which to construct the value.</param>
        public Schema(JsonObject jsonObject)
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

                                        }
    
    
    
    
    
    
    

    
    
    
            /// <summary>
        /// Gets a value indicating whether this is backed by a JSON element.
        /// </summary>
        public bool HasJsonElement =>
    
                this.objectBacking is null
            
    
                
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

    
    
    
    
    
                return new JsonAny(this.jsonElementBacking);
            }
        }

    
        
        /// <summary>
        /// Conversion from any.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Schema(JsonAny value)
        {
            if (value.HasJsonElement)
            {
                return new Schema(value.AsJsonElement);
            }

            return value.As<Schema>();
        }

        /// <summary>
        /// Conversion to any.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(Schema value)
        {
            return value.AsAny;
        }

    
    
        /// <summary>
        /// Conversion from object.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Schema(JsonObject value)
        {
            return new Schema(value);
        }

        /// <summary>
        /// Conversion to object.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonObject(Schema value)
        {
            return value.AsObject;
        }

                /// <summary>
        /// Implicit conversion to a property dictionary.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator ImmutableDictionary<string, JsonAny>(Schema  value)
        {
            return value.AsObject.AsPropertyDictionary;
        }

        /// <summary>
        /// Implicit conversion from a property dictionary.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Schema (ImmutableDictionary<string, JsonAny> value)
        {
            return new Schema (value);
        }

    
    
    
    
        /// <summary>
        /// Standard equality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are equal.</returns>
        public static bool operator ==(Schema lhs, Schema rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Standard inequality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are not equal.</returns>
        public static bool operator !=(Schema lhs, Schema rhs)
        {
            return !lhs.Equals(rhs);
        }

    
    
        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is Schema entity)
            {
                return this.Equals(entity);
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            JsonValueKind valueKind = this.ValueKind;

            return valueKind switch
            {
                    JsonValueKind.Object => this.AsObject.GetHashCode(),
                        JsonValueKind.Array => this.AsArray().GetHashCode(),
                        JsonValueKind.Number => this.AsNumber().GetHashCode(),
                        JsonValueKind.String => this.AsString().GetHashCode(),
                        JsonValueKind.True or JsonValueKind.False => this.AsBoolean().GetHashCode(),
                    JsonValueKind.Null => JsonNull.NullHashCode,
                _ => 0,
            };
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

    
    
    
    
    
            if (this.jsonElementBacking.ValueKind != JsonValueKind.Undefined)
            {
                this.jsonElementBacking.WriteTo(writer);
                return;
            }

            writer.WriteNullValue();
        }

    
        
                /// <summary>
        /// Enumerate the object as the given item type
        /// </summary>
        public JsonObjectEnumerator<UnevaluatedPropertiesDraft202012Feature.UnevaluatedPropertiesSchema.Schema.UnevaluatedPropertiesValue> EnumerateProperties()
        {
            if (this.objectBacking is ImmutableDictionary<string, JsonAny> properties)
            {
                return new JsonObjectEnumerator<UnevaluatedPropertiesDraft202012Feature.UnevaluatedPropertiesSchema.Schema.UnevaluatedPropertiesValue>(properties);
            }

            if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
            {
                return new JsonObjectEnumerator<UnevaluatedPropertiesDraft202012Feature.UnevaluatedPropertiesSchema.Schema.UnevaluatedPropertiesValue>(this.jsonElementBacking);
            }

            return default;

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
                        JsonValueKind.Array => this.AsArray().Equals(other.AsArray()),
                        JsonValueKind.Number => this.AsNumber().Equals(other.AsNumber()),
                        JsonValueKind.String => this.AsString().Equals(other.AsString()),
                        JsonValueKind.True or JsonValueKind.False => this.AsBoolean().Equals(other.AsBoolean()),
                    JsonValueKind.Null => true,
                _ => false,
            };
        }

        /// <inheritdoc/>
        public bool Equals(Schema other)
        {
            JsonValueKind valueKind = this.ValueKind;

            if (other.ValueKind != valueKind)
            {
                return false;
            }

            return valueKind switch
            {
                                JsonValueKind.Object => this.AsObject.Equals(other.AsObject),
                        JsonValueKind.Array => this.AsArray().Equals(other.AsArray()),
                        JsonValueKind.Number => this.AsNumber().Equals(other.AsNumber()),
                        JsonValueKind.String => this.AsString().Equals(other.AsString()),
                        JsonValueKind.True or JsonValueKind.False => this.AsBoolean().Equals(other.AsBoolean()),
                    JsonValueKind.Null => true,
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
                return properties.TryGetValue(System.Text.Encoding.UTF8.GetString(utf8name), out _);
            }

            if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
            {
                return this.jsonElementBacking.TryGetProperty(utf8name, out JsonElement _);
            }

            return false;        }

        /// <inheritdoc/>
        public Schema SetProperty<TValue>(string name, TValue value)
            where TValue : struct, IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Object || this.ValueKind == JsonValueKind.Undefined)
            {
                return this.AsObject.SetProperty(name, value);
            }

            return this;
        }

        /// <inheritdoc/>
        public Schema SetProperty<TValue>(ReadOnlySpan<char> name, TValue value)
            where TValue : struct, IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Object || this.ValueKind == JsonValueKind.Undefined)
            {
                return this.AsObject.SetProperty(name, value);
            }

            return this;
        }

        /// <inheritdoc/>
        public Schema SetProperty<TValue>(ReadOnlySpan<byte> utf8name, TValue value)
            where TValue : struct, IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Object || this.ValueKind == JsonValueKind.Undefined)
            {
                return this.AsObject.SetProperty(utf8name, value);
            }

            return this;
        }

        /// <inheritdoc/>
        public Schema RemoveProperty(string name)
        {
            if (this.ValueKind == JsonValueKind.Object)
            {
                return this.AsObject.RemoveProperty(name);
            }

            return this;
        }

        /// <inheritdoc/>
        public Schema RemoveProperty(ReadOnlySpan<char> name)
        {
            if (this.ValueKind == JsonValueKind.Object)
            {
                return this.AsObject.RemoveProperty(name);
            }

            return this;
        }

        /// <inheritdoc/>
        public Schema RemoveProperty(ReadOnlySpan<byte> utf8Name)
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
            return this.As<Schema, T>();
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext? validationContext = null, ValidationLevel level = ValidationLevel.Flag)
        {
            ValidationContext result = validationContext ?? ValidationContext.ValidContext;
            if (level != ValidationLevel.Flag)
            {
                result = result.UsingStack();
            }
                    result = result.UsingEvaluatedProperties();
        
        

    
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

            /// <summary>
        /// Gets the value as a <see cref="JsonObject"/>.
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
    
    
    
    
    
    
    
    
    
    
    
    
            private ValidationContext ValidateObject(JsonValueKind valueKind, in ValidationContext validationContext, ValidationLevel level)
        {
            ValidationContext result = validationContext;

            if (valueKind != JsonValueKind.Object)
            {
                return result;
            }

                    int propertyCount = 0;
        
        
            foreach (Property property in this.EnumerateObject())
            {
                string propertyName = property.Name;

        
        
        
        
        
                
                if (!result.HasEvaluatedLocalOrAppliedProperty(propertyCount))
                {

                    result = property.ValueAs<UnevaluatedPropertiesDraft202012Feature.UnevaluatedPropertiesSchema.Schema.UnevaluatedPropertiesValue>().Validate(result, level);
                    if (level == ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }

                    result = result.WithLocalProperty(propertyCount);
                }
        
        
                
                propertyCount++;

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

        
        
        
        
        
        
            result = result.MergeResults(
                isValid,
                level
        
                
                , localResultObject
        
        
        
        
        
                        );

            return result;
        }

    
    
    
    
        /// <summary>
    /// A type generated from a JsonSchema specification.
    /// </summary>
    public readonly struct UnevaluatedPropertiesValue :
                    IJsonValue,
            IEquatable<UnevaluatedPropertiesValue>
    {

        
    
    
    
    
    
    
    

    
        private readonly JsonElement jsonElementBacking;

    
    
    
            private readonly string? stringBacking;
    
    
        /// <summary>
        /// Initializes a new instance of the <see cref="UnevaluatedPropertiesValue"/> struct.
        /// </summary>
        /// <param name="value">The backing <see cref="JsonElement"/>.</param>
        public UnevaluatedPropertiesValue(JsonElement value)
        {
            this.jsonElementBacking = value;
                            this.stringBacking = default;
                }

    
    
    
            /// <summary>
        /// Initializes a new instance of the <see cref="UnevaluatedPropertiesValue"/> struct.
        /// </summary>
        /// <param name="value">A string value.</param>
        public UnevaluatedPropertiesValue(string value)
        {
            this.jsonElementBacking = default;
                                            this.stringBacking = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnevaluatedPropertiesValue"/> struct.
        /// </summary>
        /// <param name="value">A string value.</param>
        public UnevaluatedPropertiesValue(ReadOnlySpan<char> value)
        {
            this.jsonElementBacking = default;
                                            this.stringBacking = value.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnevaluatedPropertiesValue"/> struct.
        /// </summary>
        /// <param name="value">A string value.</param>
        public UnevaluatedPropertiesValue(ReadOnlySpan<byte> value)
        {
            this.jsonElementBacking = default;
                                            this.stringBacking = System.Text.Encoding.UTF8.GetString(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnevaluatedPropertiesValue"/> struct.
        /// </summary>
        /// <param name="jsonString">The <see cref="JsonString"/> from which to construct the value.</param>
        public UnevaluatedPropertiesValue(JsonString jsonString)
        {
            if (jsonString.HasJsonElement)
            {
                this.jsonElementBacking = jsonString.AsJsonElement;
                this.stringBacking = default;
            }
            else
            {
                this.jsonElementBacking = default;
                this.stringBacking = jsonString;
            }

                                        }
    
    
    
    

    
    
    
            /// <summary>
        /// Gets a value indicating whether this is backed by a JSON element.
        /// </summary>
        public bool HasJsonElement =>
    
    
                                this.stringBacking is null
        
                ;

        /// <summary>
        /// Gets the value as a JsonElement.
        /// </summary>
        public JsonElement AsJsonElement
        {
            get
            {
    
    
    
                    if (this.stringBacking is string stringBacking)
                {
                    return JsonString.StringToJsonElement(stringBacking);
                }

    
    
                return this.jsonElementBacking;
            }
        }

        /// <inheritdoc/>
        public JsonValueKind ValueKind
        {
            get
            {
    
    
    
                    if (this.stringBacking is string)
                {
                    return JsonValueKind.String;
                }

    
    
                return this.jsonElementBacking.ValueKind;
            }
        }

        /// <inheritdoc/>
        public JsonAny AsAny
        {
            get
            {
    
    
    
                    if (this.stringBacking is string stringBacking)
                {
                    return new JsonAny(stringBacking);
                }

    
    
                return new JsonAny(this.jsonElementBacking);
            }
        }

    
        
        /// <summary>
        /// Conversion from any.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator UnevaluatedPropertiesValue(JsonAny value)
        {
            if (value.HasJsonElement)
            {
                return new UnevaluatedPropertiesValue(value.AsJsonElement);
            }

            return value.As<UnevaluatedPropertiesValue>();
        }

        /// <summary>
        /// Conversion to any.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(UnevaluatedPropertiesValue value)
        {
            return value.AsAny;
        }

    
    
    
        /// <summary>
        /// Conversion from string.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator UnevaluatedPropertiesValue(string value)
        {
            return new UnevaluatedPropertiesValue(value);
        }

        /// <summary>
        /// Conversion to string.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator string(UnevaluatedPropertiesValue value)
        {
            return value.AsString;
        }

        /// <summary>
        /// Conversion from string.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator UnevaluatedPropertiesValue(ReadOnlySpan<char> value)
        {
            return new UnevaluatedPropertiesValue(value);
        }

        /// <summary>
        /// Conversion to string.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator ReadOnlySpan<char>(UnevaluatedPropertiesValue value)
        {
            return value.AsString;
        }

        /// <summary>
        /// Conversion from utf8 bytes.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator UnevaluatedPropertiesValue(ReadOnlySpan<byte> value)
        {
            return new UnevaluatedPropertiesValue(value);
        }

        /// <summary>
        /// Conversion to utf8 bytes.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator ReadOnlySpan<byte>(UnevaluatedPropertiesValue value)
        {
            return value.AsString;
        }

        /// <summary>
        /// Conversion from string.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator UnevaluatedPropertiesValue(JsonString value)
        {
            return new UnevaluatedPropertiesValue(value);
        }

        /// <summary>
        /// Conversion to string.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonString(UnevaluatedPropertiesValue value)
        {
            return value.AsString;
        }

    
    
    
        /// <summary>
        /// Standard equality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are equal.</returns>
        public static bool operator ==(UnevaluatedPropertiesValue lhs, UnevaluatedPropertiesValue rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Standard inequality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are not equal.</returns>
        public static bool operator !=(UnevaluatedPropertiesValue lhs, UnevaluatedPropertiesValue rhs)
        {
            return !lhs.Equals(rhs);
        }

    
    
        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is UnevaluatedPropertiesValue entity)
            {
                return this.Equals(entity);
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            JsonValueKind valueKind = this.ValueKind;

            return valueKind switch
            {
                    JsonValueKind.Object => this.AsObject().GetHashCode(),
                        JsonValueKind.Array => this.AsArray().GetHashCode(),
                        JsonValueKind.Number => this.AsNumber().GetHashCode(),
                        JsonValueKind.String => this.AsString.GetHashCode(),
                        JsonValueKind.True or JsonValueKind.False => this.AsBoolean().GetHashCode(),
                    JsonValueKind.Null => JsonNull.NullHashCode,
                _ => 0,
            };
        }

        /// <summary>
        /// Writes the object to the <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The writer to which to write the object.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
    
    
    
                if (this.stringBacking is string stringBacking)
            {
                writer.WriteStringValue(stringBacking);
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
                    JsonValueKind.Object => this.AsObject().Equals(other.AsObject()),
                        JsonValueKind.Array => this.AsArray().Equals(other.AsArray()),
                        JsonValueKind.Number => this.AsNumber().Equals(other.AsNumber()),
                        JsonValueKind.String => this.AsString.Equals(other.AsString()),
                        JsonValueKind.True or JsonValueKind.False => this.AsBoolean().Equals(other.AsBoolean()),
                    JsonValueKind.Null => true,
                _ => false,
            };
        }

        /// <inheritdoc/>
        public bool Equals(UnevaluatedPropertiesValue other)
        {
            JsonValueKind valueKind = this.ValueKind;

            if (other.ValueKind != valueKind)
            {
                return false;
            }

            return valueKind switch
            {
                                JsonValueKind.Object => this.AsObject().Equals(other.AsObject()),
                        JsonValueKind.Array => this.AsArray().Equals(other.AsArray()),
                        JsonValueKind.Number => this.AsNumber().Equals(other.AsNumber()),
                        JsonValueKind.String => this.AsString.Equals(other.AsString),
                        JsonValueKind.True or JsonValueKind.False => this.AsBoolean().Equals(other.AsBoolean()),
                    JsonValueKind.Null => true,
                _ => false,
            };
        }

    
    
        /// <inheritdoc/>
        public T As<T>()
            where T : struct, IJsonValue
        {
            return this.As<UnevaluatedPropertiesValue, T>();
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
        
        
        
        
    
    
    
        
                result = Menes.Json.Validate.ValidateString(
                this,
                result,
                level,
                        null,
                                 3,
                                null
                        );

            if (level == ValidationLevel.Flag && !result.IsValid)
            {
                return result;
            }
    
    
    
    
    
    
    

                return result;
        }

    
    
    
            /// <summary>
        /// Gets the value as a <see cref="JsonString"/>.
        /// </summary>
        private JsonString AsString
        {
            get
            {
                if (this.stringBacking is string stringBacking)
                {
                    return new JsonString(stringBacking);
                }

                return new JsonString(this.jsonElementBacking);
            }
        }
    
    
    
    
    
    
    
    
    
    
            

            

            

            

    
    
    
            
        private ValidationContext ValidateType(JsonValueKind valueKind, in ValidationContext validationContext, ValidationLevel level)
        {
            ValidationContext result = validationContext;
            bool isValid = false;

                
            ValidationContext localResultString = Menes.Json.Validate.TypeString(valueKind, result, level);
            if (level == ValidationLevel.Flag && localResultString.IsValid)
            {
                return validationContext;
            }

            if (localResultString.IsValid)
            {
                isValid = true;
            }

        
        
        
        
        
        
        
            result = result.MergeResults(
                isValid,
                level
                
                , localResultString
        
        
        
        
        
        
                        );

            return result;
        }

    
    
    
    }
    

    
    }
    }
    