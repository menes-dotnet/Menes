
    //------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

namespace ConstDraft202012Feature.ConstWithTrueDoesNotMatch1
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Text.Json;
    using System.Text.RegularExpressions;
    using Menes.Json;

        /// <summary>
    /// A type generated from a JsonSchema specification.
    /// </summary>
    public readonly struct Schema :
                    IJsonValue,
            IEquatable<Schema>
    {

        
    
            private static readonly Schema __MenesConstValue = JsonAny.Parse("true");
    
    
    
    
    
    

    
        private readonly JsonElement jsonElementBacking;

    
    
    
    
            private readonly bool? booleanBacking;
    
        /// <summary>
        /// Initializes a new instance of the <see cref="Schema"/> struct.
        /// </summary>
        /// <param name="value">The backing <see cref="JsonElement"/>.</param>
        public Schema(JsonElement value)
        {
            this.jsonElementBacking = value;
                                this.booleanBacking = default;
            }

    
    
    
    
            /// <summary>
        /// Initializes a new instance of the <see cref="Schema"/> struct.
        /// </summary>
        /// <param name="jsonBoolean">The <see cref="JsonBoolean"/> from which to construct the value.</param>
        public Schema(JsonBoolean jsonBoolean)
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

                                        }

                /// <summary>
        /// Initializes a new instance of the <see cref="Schema"/> struct.
        /// </summary>
        /// <param name="boolean">The <see cref="bool"/> from which to construct the value.</param>
        public Schema(bool boolean)
        {
            this.jsonElementBacking = default;
            this.booleanBacking = boolean;

                                        }

    
    
    

    
    
    
            /// <summary>
        /// Gets a value indicating whether this is backed by a JSON element.
        /// </summary>
        public bool HasJsonElement =>
    
    
                                    this.booleanBacking is null
    
                ;

        /// <summary>
        /// Gets the value as a JsonElement.
        /// </summary>
        public JsonElement AsJsonElement
        {
            get
            {
    
    
    
    
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
        /// Conversion from bool.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Schema(bool value)
        {
            return new Schema(value);
        }

        /// <summary>
        /// Conversion to bool.
        /// </summary>
        /// <param name="boolean">The value from which to convert.</param>
        public static implicit operator bool(Schema boolean)
        {
            return boolean.AsBoolean.GetBoolean();
        }

        /// <summary>
        /// Conversion from bool.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Schema(JsonBoolean value)
        {
            return new Schema(value);
        }

        /// <summary>
        /// Conversion to bool.
        /// </summary>
        /// <param name="boolean">The value from which to convert.</param>
        public static implicit operator JsonBoolean(Schema boolean)
        {
            return boolean.AsBoolean;
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
                JsonValueKind.Array => this.AsArray.GetHashCode(),
                JsonValueKind.Number => this.AsNumber.GetHashCode(),
                JsonValueKind.String => this.AsString.GetHashCode(),
                JsonValueKind.True or JsonValueKind.False => this.AsBoolean.GetHashCode(),
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
                JsonValueKind.Array => this.AsArray.Equals(other.AsArray),
                JsonValueKind.Number => this.AsNumber.Equals(other.AsNumber),
                JsonValueKind.String => this.AsString.Equals(other.AsString),
                JsonValueKind.Null => true,
                JsonValueKind.True or JsonValueKind.False => this.AsBoolean.Equals(other.AsBoolean),
                _ => false,
            };
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

    
    
    
                result = Menes.Json.Validate.ValidateConst(this, result, level, __MenesConstValue);
            if (level == ValidationLevel.Flag && !result.IsValid)
            {
                return result;
            }

    
    
        
    
    
    
    
    
    
    

                return result;
        }

    
    
    
    
    
    
    
    
            

            

            

            

    
    
    
    
    
    
    }
    }
    