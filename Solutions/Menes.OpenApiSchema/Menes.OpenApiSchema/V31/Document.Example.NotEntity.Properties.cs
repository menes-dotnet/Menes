//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Corvus.Json;
using Corvus.Json.Internal;

namespace Menes.OpenApiSchema.V31;
public readonly partial struct Document
{
    public readonly partial struct Example
    {
        /// <summary>
        /// A type generated from a JsonSchema specification.
        /// </summary>
        public readonly partial struct NotEntity
        {
            /// <summary>
            /// JSON property name for <see cref = "Value"/>.
            /// </summary>
            public static readonly ReadOnlyMemory<byte> ValueUtf8JsonPropertyName = new byte[]{118, 97, 108, 117, 101};
            /// <summary>
            /// JSON property name for <see cref = "Value"/>.
            /// </summary>
            public const string ValueJsonPropertyName = "value";
            /// <summary>
            /// JSON property name for <see cref = "ExternalValue"/>.
            /// </summary>
            public static readonly ReadOnlyMemory<byte> ExternalValueUtf8JsonPropertyName = new byte[]{101, 120, 116, 101, 114, 110, 97, 108, 86, 97, 108, 117, 101};
            /// <summary>
            /// JSON property name for <see cref = "ExternalValue"/>.
            /// </summary>
            public const string ExternalValueJsonPropertyName = "externalValue";
            /// <summary>
            /// Gets Value.
            /// </summary>
            public Corvus.Json.JsonAny Value
            {
                get
                {
                    if ((this.backing & Backing.JsonElement) != 0)
                    {
                        if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                        {
                            return default;
                        }

                        if (this.jsonElementBacking.TryGetProperty(ValueUtf8JsonPropertyName.Span, out JsonElement result))
                        {
                            return new Corvus.Json.JsonAny(result);
                        }
                    }

                    if ((this.backing & Backing.Object) != 0)
                    {
                        if (this.objectBacking.TryGetValue(ValueJsonPropertyName, out JsonAny result))
                        {
                            return result.As<Corvus.Json.JsonAny>();
                        }
                    }

                    return default;
                }
            }

            /// <summary>
            /// Gets ExternalValue.
            /// </summary>
            public Corvus.Json.JsonAny ExternalValue
            {
                get
                {
                    if ((this.backing & Backing.JsonElement) != 0)
                    {
                        if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                        {
                            return default;
                        }

                        if (this.jsonElementBacking.TryGetProperty(ExternalValueUtf8JsonPropertyName.Span, out JsonElement result))
                        {
                            return new Corvus.Json.JsonAny(result);
                        }
                    }

                    if ((this.backing & Backing.Object) != 0)
                    {
                        if (this.objectBacking.TryGetValue(ExternalValueJsonPropertyName, out JsonAny result))
                        {
                            return result.As<Corvus.Json.JsonAny>();
                        }
                    }

                    return default;
                }
            }

            /// <summary>
            /// Creates an instance of a <see cref = "NotEntity"/>.
            /// </summary>
            public static NotEntity Create(Corvus.Json.JsonAny value, Corvus.Json.JsonAny externalValue)
            {
                var builder = ImmutableDictionary.CreateBuilder<JsonPropertyName, JsonAny>();
                builder.Add(ValueJsonPropertyName, value.AsAny);
                builder.Add(ExternalValueJsonPropertyName, externalValue.AsAny);
                return builder.ToImmutable();
            }

            /// <summary>
            /// Sets value.
            /// </summary>
            /// <param name = "value">The value to set.</param>
            /// <returns>The entity with the updated property.</returns>
            public NotEntity WithValue(in Corvus.Json.JsonAny value)
            {
                return this.SetProperty(ValueJsonPropertyName, value);
            }

            /// <summary>
            /// Sets externalValue.
            /// </summary>
            /// <param name = "value">The value to set.</param>
            /// <returns>The entity with the updated property.</returns>
            public NotEntity WithExternalValue(in Corvus.Json.JsonAny value)
            {
                return this.SetProperty(ExternalValueJsonPropertyName, value);
            }

            private static ValidationContext __CorvusValidateValue(in JsonObjectProperty property, in ValidationContext validationContext, ValidationLevel level)
            {
                return property.ValueAs<Corvus.Json.JsonAny>().Validate(validationContext, level);
            }

            private static ValidationContext __CorvusValidateExternalValue(in JsonObjectProperty property, in ValidationContext validationContext, ValidationLevel level)
            {
                return property.ValueAs<Corvus.Json.JsonAny>().Validate(validationContext, level);
            }

            /// <summary>
            /// Tries to get the validator for the given property.
            /// </summary>
            /// <param name = "property">The property for which to get the validator.</param>
            /// <param name = "hasJsonElementBacking"><c>True</c> if the object containing the property has a JsonElement backing.</param>
            /// <param name = "propertyValidator">The validator for the property, if provided by this schema.</param>
            /// <returns><c>True</c> if the validator was found.</returns>
            private bool __TryGetCorvusLocalPropertiesValidator(in JsonObjectProperty property, bool hasJsonElementBacking, [NotNullWhen(true)] out ObjectPropertyValidator? propertyValidator)
            {
                if (hasJsonElementBacking)
                {
                    if (property.NameEquals(ValueUtf8JsonPropertyName.Span))
                    {
                        propertyValidator = __CorvusValidateValue;
                        return true;
                    }
                    else if (property.NameEquals(ExternalValueUtf8JsonPropertyName.Span))
                    {
                        propertyValidator = __CorvusValidateExternalValue;
                        return true;
                    }
                }
                else
                {
                    if (property.NameEquals(ValueJsonPropertyName))
                    {
                        propertyValidator = __CorvusValidateValue;
                        return true;
                    }
                    else if (property.NameEquals(ExternalValueJsonPropertyName))
                    {
                        propertyValidator = __CorvusValidateExternalValue;
                        return true;
                    }
                }

                propertyValidator = null;
                return false;
            }
        }
    }
}