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
    public readonly partial struct License
    {
        /// <summary>
        /// A type generated from a JsonSchema specification.
        /// </summary>
        public readonly partial struct OneOf0Entity
        {
            /// <summary>
            /// JSON property name for <see cref = "Identifier"/>.
            /// </summary>
            public static readonly ReadOnlyMemory<byte> IdentifierUtf8JsonPropertyName = new byte[]{105, 100, 101, 110, 116, 105, 102, 105, 101, 114};
            /// <summary>
            /// JSON property name for <see cref = "Identifier"/>.
            /// </summary>
            public const string IdentifierJsonPropertyName = "identifier";
            /// <summary>
            /// Gets Identifier.
            /// </summary>
            public Corvus.Json.JsonAny Identifier
            {
                get
                {
                    if ((this.backing & Backing.JsonElement) != 0)
                    {
                        if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                        {
                            return default;
                        }

                        if (this.jsonElementBacking.TryGetProperty(IdentifierUtf8JsonPropertyName.Span, out JsonElement result))
                        {
                            return new Corvus.Json.JsonAny(result);
                        }
                    }

                    if ((this.backing & Backing.Object) != 0)
                    {
                        if (this.objectBacking.TryGetValue(IdentifierJsonPropertyName, out JsonAny result))
                        {
                            return result.As<Corvus.Json.JsonAny>();
                        }
                    }

                    return default;
                }
            }

            /// <summary>
            /// Creates an instance of a <see cref = "OneOf0Entity"/>.
            /// </summary>
            public static OneOf0Entity Create(Corvus.Json.JsonAny identifier)
            {
                var builder = ImmutableDictionary.CreateBuilder<JsonPropertyName, JsonAny>();
                builder.Add(IdentifierJsonPropertyName, identifier.AsAny);
                return builder.ToImmutable();
            }

            /// <summary>
            /// Sets identifier.
            /// </summary>
            /// <param name = "value">The value to set.</param>
            /// <returns>The entity with the updated property.</returns>
            public OneOf0Entity WithIdentifier(in Corvus.Json.JsonAny value)
            {
                return this.SetProperty(IdentifierJsonPropertyName, value);
            }

            private static ValidationContext __CorvusValidateIdentifier(in JsonObjectProperty property, in ValidationContext validationContext, ValidationLevel level)
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
                    if (property.NameEquals(IdentifierUtf8JsonPropertyName.Span))
                    {
                        propertyValidator = __CorvusValidateIdentifier;
                        return true;
                    }
                }
                else
                {
                    if (property.NameEquals(IdentifierJsonPropertyName))
                    {
                        propertyValidator = __CorvusValidateIdentifier;
                        return true;
                    }
                }

                propertyValidator = null;
                return false;
            }
        }
    }
}