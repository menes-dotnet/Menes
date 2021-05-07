
    //------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

namespace PropertiesDraft201909Feature.PropertiesWithEscapedCharacters
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
    public readonly struct Schema :
            IJsonObject<Schema>,
                    IEquatable<Schema>
    {

        
    
        
        /// <summary>
        /// JSON property name for <see cref="FooBar"/>.
        /// </summary>
        public static readonly ReadOnlyMemory<byte> FooBarUtf8JsonPropertyName = new byte[] { 102, 111, 111, 10, 98, 97, 114 };

        /// <summary>
        /// JSON property name for <see cref="FooBar"/>.
        /// </summary>
        public static readonly string FooBarJsonPropertyName = "foo\nbar";

        
        /// <summary>
        /// JSON property name for <see cref="FooBar1"/>.
        /// </summary>
        public static readonly ReadOnlyMemory<byte> FooBar1Utf8JsonPropertyName = new byte[] { 102, 111, 111, 34, 98, 97, 114 };

        /// <summary>
        /// JSON property name for <see cref="FooBar1"/>.
        /// </summary>
        public static readonly string FooBar1JsonPropertyName = "foo\"bar";

        
        /// <summary>
        /// JSON property name for <see cref="FooBar2"/>.
        /// </summary>
        public static readonly ReadOnlyMemory<byte> FooBar2Utf8JsonPropertyName = new byte[] { 102, 111, 111, 92, 98, 97, 114 };

        /// <summary>
        /// JSON property name for <see cref="FooBar2"/>.
        /// </summary>
        public static readonly string FooBar2JsonPropertyName = "foo\\bar";

        
        /// <summary>
        /// JSON property name for <see cref="FooBar3"/>.
        /// </summary>
        public static readonly ReadOnlyMemory<byte> FooBar3Utf8JsonPropertyName = new byte[] { 102, 111, 111, 13, 98, 97, 114 };

        /// <summary>
        /// JSON property name for <see cref="FooBar3"/>.
        /// </summary>
        public static readonly string FooBar3JsonPropertyName = "foo\rbar";

        
        /// <summary>
        /// JSON property name for <see cref="FooBar4"/>.
        /// </summary>
        public static readonly ReadOnlyMemory<byte> FooBar4Utf8JsonPropertyName = new byte[] { 102, 111, 111, 9, 98, 97, 114 };

        /// <summary>
        /// JSON property name for <see cref="FooBar4"/>.
        /// </summary>
        public static readonly string FooBar4JsonPropertyName = "foo\tbar";

        
        /// <summary>
        /// JSON property name for <see cref="FooBar5"/>.
        /// </summary>
        public static readonly ReadOnlyMemory<byte> FooBar5Utf8JsonPropertyName = new byte[] { 102, 111, 111, 12, 98, 97, 114 };

        /// <summary>
        /// JSON property name for <see cref="FooBar5"/>.
        /// </summary>
        public static readonly string FooBar5JsonPropertyName = "foo\fbar";

        
    
    
    
    
    
            private static readonly ImmutableDictionary<string, PropertyValidator<Schema>> __MenesLocalProperties = CreateLocalPropertyValidators();
    
    

    
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
        /// Gets FooBar.
        /// </summary>
        /// <remarks>
        /// {Property title}.
        /// {Property description}.
        /// </remarks>
        /// <example>
        /// {Property examples}.
        /// </example>
        public Menes.Json.JsonNumber FooBar
        {
            get
            {
                if (this.objectBacking is ImmutableDictionary<string, JsonAny> properties)
                {
                    if(properties.TryGetValue(FooBarJsonPropertyName, out JsonAny result))
                    {
                        return result;
                    }
                }

                if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
                {
                    if (this.jsonElementBacking.TryGetProperty(FooBarUtf8JsonPropertyName.Span, out JsonElement result))
                    {
                        return new  Menes.Json.JsonNumber(result);
                    }
                }

                return default;
            }
        }

        
        /// <summary>
        /// Gets FooBar1.
        /// </summary>
        /// <remarks>
        /// {Property title}.
        /// {Property description}.
        /// </remarks>
        /// <example>
        /// {Property examples}.
        /// </example>
        public Menes.Json.JsonNumber FooBar1
        {
            get
            {
                if (this.objectBacking is ImmutableDictionary<string, JsonAny> properties)
                {
                    if(properties.TryGetValue(FooBar1JsonPropertyName, out JsonAny result))
                    {
                        return result;
                    }
                }

                if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
                {
                    if (this.jsonElementBacking.TryGetProperty(FooBar1Utf8JsonPropertyName.Span, out JsonElement result))
                    {
                        return new  Menes.Json.JsonNumber(result);
                    }
                }

                return default;
            }
        }

        
        /// <summary>
        /// Gets FooBar2.
        /// </summary>
        /// <remarks>
        /// {Property title}.
        /// {Property description}.
        /// </remarks>
        /// <example>
        /// {Property examples}.
        /// </example>
        public Menes.Json.JsonNumber FooBar2
        {
            get
            {
                if (this.objectBacking is ImmutableDictionary<string, JsonAny> properties)
                {
                    if(properties.TryGetValue(FooBar2JsonPropertyName, out JsonAny result))
                    {
                        return result;
                    }
                }

                if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
                {
                    if (this.jsonElementBacking.TryGetProperty(FooBar2Utf8JsonPropertyName.Span, out JsonElement result))
                    {
                        return new  Menes.Json.JsonNumber(result);
                    }
                }

                return default;
            }
        }

        
        /// <summary>
        /// Gets FooBar3.
        /// </summary>
        /// <remarks>
        /// {Property title}.
        /// {Property description}.
        /// </remarks>
        /// <example>
        /// {Property examples}.
        /// </example>
        public Menes.Json.JsonNumber FooBar3
        {
            get
            {
                if (this.objectBacking is ImmutableDictionary<string, JsonAny> properties)
                {
                    if(properties.TryGetValue(FooBar3JsonPropertyName, out JsonAny result))
                    {
                        return result;
                    }
                }

                if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
                {
                    if (this.jsonElementBacking.TryGetProperty(FooBar3Utf8JsonPropertyName.Span, out JsonElement result))
                    {
                        return new  Menes.Json.JsonNumber(result);
                    }
                }

                return default;
            }
        }

        
        /// <summary>
        /// Gets FooBar4.
        /// </summary>
        /// <remarks>
        /// {Property title}.
        /// {Property description}.
        /// </remarks>
        /// <example>
        /// {Property examples}.
        /// </example>
        public Menes.Json.JsonNumber FooBar4
        {
            get
            {
                if (this.objectBacking is ImmutableDictionary<string, JsonAny> properties)
                {
                    if(properties.TryGetValue(FooBar4JsonPropertyName, out JsonAny result))
                    {
                        return result;
                    }
                }

                if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
                {
                    if (this.jsonElementBacking.TryGetProperty(FooBar4Utf8JsonPropertyName.Span, out JsonElement result))
                    {
                        return new  Menes.Json.JsonNumber(result);
                    }
                }

                return default;
            }
        }

        
        /// <summary>
        /// Gets FooBar5.
        /// </summary>
        /// <remarks>
        /// {Property title}.
        /// {Property description}.
        /// </remarks>
        /// <example>
        /// {Property examples}.
        /// </example>
        public Menes.Json.JsonNumber FooBar5
        {
            get
            {
                if (this.objectBacking is ImmutableDictionary<string, JsonAny> properties)
                {
                    if(properties.TryGetValue(FooBar5JsonPropertyName, out JsonAny result))
                    {
                        return result;
                    }
                }

                if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
                {
                    if (this.jsonElementBacking.TryGetProperty(FooBar5Utf8JsonPropertyName.Span, out JsonElement result))
                    {
                        return new  Menes.Json.JsonNumber(result);
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

    
            /// <summary>
        /// Creates an instance of a <see cref="Schema"/>.
        /// </summary>
        public static Schema Create(
                            Menes.Json.JsonNumber? fooBar = null
        ,             Menes.Json.JsonNumber? fooBar1 = null
        ,             Menes.Json.JsonNumber? fooBar2 = null
        ,             Menes.Json.JsonNumber? fooBar3 = null
        ,             Menes.Json.JsonNumber? fooBar4 = null
        ,             Menes.Json.JsonNumber? fooBar5 = null
        
        )
        {
            var builder = ImmutableDictionary.CreateBuilder<string, JsonAny>();
                            if (fooBar is Menes.Json.JsonNumber fooBar__)
            {
                builder.Add(FooBarJsonPropertyName, fooBar__);
            }
                    if (fooBar1 is Menes.Json.JsonNumber fooBar1__)
            {
                builder.Add(FooBar1JsonPropertyName, fooBar1__);
            }
                    if (fooBar2 is Menes.Json.JsonNumber fooBar2__)
            {
                builder.Add(FooBar2JsonPropertyName, fooBar2__);
            }
                    if (fooBar3 is Menes.Json.JsonNumber fooBar3__)
            {
                builder.Add(FooBar3JsonPropertyName, fooBar3__);
            }
                    if (fooBar4 is Menes.Json.JsonNumber fooBar4__)
            {
                builder.Add(FooBar4JsonPropertyName, fooBar4__);
            }
                    if (fooBar5 is Menes.Json.JsonNumber fooBar5__)
            {
                builder.Add(FooBar5JsonPropertyName, fooBar5__);
            }
                    return builder.ToImmutable();
        }

        
        /// <summary>
        /// Sets foo\nbar.
        /// </summary>
        /// <param name="value">The value to set.</param>
        /// <returns>The entity with the updated property.</returns>
        public Schema WithFooBar(Menes.Json.JsonNumber value)
        {
            return this.SetProperty(FooBarJsonPropertyName, value);
        }

        
        /// <summary>
        /// Sets foo\"bar.
        /// </summary>
        /// <param name="value">The value to set.</param>
        /// <returns>The entity with the updated property.</returns>
        public Schema WithFooBar1(Menes.Json.JsonNumber value)
        {
            return this.SetProperty(FooBar1JsonPropertyName, value);
        }

        
        /// <summary>
        /// Sets foo\\bar.
        /// </summary>
        /// <param name="value">The value to set.</param>
        /// <returns>The entity with the updated property.</returns>
        public Schema WithFooBar2(Menes.Json.JsonNumber value)
        {
            return this.SetProperty(FooBar2JsonPropertyName, value);
        }

        
        /// <summary>
        /// Sets foo\rbar.
        /// </summary>
        /// <param name="value">The value to set.</param>
        /// <returns>The entity with the updated property.</returns>
        public Schema WithFooBar3(Menes.Json.JsonNumber value)
        {
            return this.SetProperty(FooBar3JsonPropertyName, value);
        }

        
        /// <summary>
        /// Sets foo\tbar.
        /// </summary>
        /// <param name="value">The value to set.</param>
        /// <returns>The entity with the updated property.</returns>
        public Schema WithFooBar4(Menes.Json.JsonNumber value)
        {
            return this.SetProperty(FooBar4JsonPropertyName, value);
        }

        
        /// <summary>
        /// Sets foo\fbar.
        /// </summary>
        /// <param name="value">The value to set.</param>
        /// <returns>The entity with the updated property.</returns>
        public Schema WithFooBar5(Menes.Json.JsonNumber value)
        {
            return this.SetProperty(FooBar5JsonPropertyName, value);
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

                        
        
        
    
                JsonValueKind valueKind = this.ValueKind;
    
    
    
    
        
    
    
    
    
    
    
                result = this.ValidateObject(valueKind, result, level);
            if (level == ValidationLevel.Flag && !result.IsValid)
            {
                return result;
            }

    

                return result;
        }


    
    
    
    
    
        private static ImmutableDictionary<string, PropertyValidator<Schema>> CreateLocalPropertyValidators()
        {
            ImmutableDictionary<string, PropertyValidator<Schema>>.Builder builder =
                ImmutableDictionary.CreateBuilder<string, PropertyValidator<Schema>>();

                    builder.Add(
                FooBarJsonPropertyName, __MenesValidateFooBar);
                    builder.Add(
                FooBar1JsonPropertyName, __MenesValidateFooBar1);
                    builder.Add(
                FooBar2JsonPropertyName, __MenesValidateFooBar2);
                    builder.Add(
                FooBar3JsonPropertyName, __MenesValidateFooBar3);
                    builder.Add(
                FooBar4JsonPropertyName, __MenesValidateFooBar4);
                    builder.Add(
                FooBar5JsonPropertyName, __MenesValidateFooBar5);
        
            return builder.ToImmutable();
        }

                private static ValidationContext __MenesValidateFooBar(in Schema that, in ValidationContext validationContext, ValidationLevel level)
        {
            Menes.Json.JsonNumber property = that.FooBar;
            return property.Validate(validationContext, level);
        }
                private static ValidationContext __MenesValidateFooBar1(in Schema that, in ValidationContext validationContext, ValidationLevel level)
        {
            Menes.Json.JsonNumber property = that.FooBar1;
            return property.Validate(validationContext, level);
        }
                private static ValidationContext __MenesValidateFooBar2(in Schema that, in ValidationContext validationContext, ValidationLevel level)
        {
            Menes.Json.JsonNumber property = that.FooBar2;
            return property.Validate(validationContext, level);
        }
                private static ValidationContext __MenesValidateFooBar3(in Schema that, in ValidationContext validationContext, ValidationLevel level)
        {
            Menes.Json.JsonNumber property = that.FooBar3;
            return property.Validate(validationContext, level);
        }
                private static ValidationContext __MenesValidateFooBar4(in Schema that, in ValidationContext validationContext, ValidationLevel level)
        {
            Menes.Json.JsonNumber property = that.FooBar4;
            return property.Validate(validationContext, level);
        }
                private static ValidationContext __MenesValidateFooBar5(in Schema that, in ValidationContext validationContext, ValidationLevel level)
        {
            Menes.Json.JsonNumber property = that.FooBar5;
            return property.Validate(validationContext, level);
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

        
                        if (__MenesLocalProperties.TryGetValue(propertyName, out PropertyValidator<Schema>? propertyValidator))
                {
                    result = result.WithLocalProperty(propertyCount);
                    var propertyResult = propertyValidator(this, result.CreateChildContext(), level);
                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);
                    if (level == ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }

            
                }
        
        
        
        
        
        
                
                propertyCount++;

                    }

        
        
        
            return result;
        }

    
            

            

            

            

    
    
    
    
    
    
    }
    }
    