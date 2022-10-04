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
    public readonly partial struct Link
    {
        /// <summary>
        /// A type generated from a JsonSchema specification.
        /// </summary>
        public readonly partial struct OneOf1Entity
        {
            /// <summary>
            /// JSON property name for <see cref = "OperationId"/>.
            /// </summary>
            public static readonly ReadOnlyMemory<byte> OperationIdUtf8JsonPropertyName = new byte[]{111, 112, 101, 114, 97, 116, 105, 111, 110, 73, 100};
            /// <summary>
            /// JSON property name for <see cref = "OperationId"/>.
            /// </summary>
            public const string OperationIdJsonPropertyName = "operationId";
            /// <summary>
            /// Gets OperationId.
            /// </summary>
            public Corvus.Json.JsonAny OperationId
            {
                get
                {
                    if ((this.backing & Backing.JsonElement) != 0)
                    {
                        if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                        {
                            return default;
                        }

                        if (this.jsonElementBacking.TryGetProperty(OperationIdUtf8JsonPropertyName.Span, out JsonElement result))
                        {
                            return new Corvus.Json.JsonAny(result);
                        }
                    }

                    if ((this.backing & Backing.Object) != 0)
                    {
                        if (this.objectBacking.TryGetValue(OperationIdJsonPropertyName, out JsonAny result))
                        {
                            return result.As<Corvus.Json.JsonAny>();
                        }
                    }

                    return default;
                }
            }

            /// <summary>
            /// Creates an instance of a <see cref = "OneOf1Entity"/>.
            /// </summary>
            public static OneOf1Entity Create(Corvus.Json.JsonAny operationId)
            {
                var builder = ImmutableDictionary.CreateBuilder<JsonPropertyName, JsonAny>();
                builder.Add(OperationIdJsonPropertyName, operationId.AsAny);
                return builder.ToImmutable();
            }

            /// <summary>
            /// Sets operationId.
            /// </summary>
            /// <param name = "value">The value to set.</param>
            /// <returns>The entity with the updated property.</returns>
            public OneOf1Entity WithOperationId(in Corvus.Json.JsonAny value)
            {
                return this.SetProperty(OperationIdJsonPropertyName, value);
            }

            private static ValidationContext __CorvusValidateOperationId(in JsonObjectProperty property, in ValidationContext validationContext, ValidationLevel level)
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
                    if (property.NameEquals(OperationIdUtf8JsonPropertyName.Span))
                    {
                        propertyValidator = __CorvusValidateOperationId;
                        return true;
                    }
                }
                else
                {
                    if (property.NameEquals(OperationIdJsonPropertyName))
                    {
                        propertyValidator = __CorvusValidateOperationId;
                        return true;
                    }
                }

                propertyValidator = null;
                return false;
            }
        }
    }
}