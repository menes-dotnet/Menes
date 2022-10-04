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
using System.Text.Json;
using Corvus.Json;
using Corvus.Json.Internal;

namespace Menes.OpenApiSchema.V31;
public readonly partial struct Document
{
    /// <summary>
    /// A type generated from a JsonSchema specification.
    /// </summary>
    public readonly partial struct ParameterOrReference
    {
        /// <summary>
        /// Conversion from <see cref = "Menes.OpenApiSchema.V31.Document.Reference"/>.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator ParameterOrReference(Menes.OpenApiSchema.V31.Document.Reference value)
        {
            if (value.HasJsonElementBacking)
            {
                return new(value.AsJsonElement);
            }

            return value.ValueKind switch
            {
                JsonValueKind.Object => new((ImmutableDictionary<JsonPropertyName, JsonAny>)value),
                _ => Undefined
            };
        }

        /// <summary>
        /// Conversion to <see cref = "Menes.OpenApiSchema.V31.Document.Reference"/>.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator Menes.OpenApiSchema.V31.Document.Reference(ParameterOrReference value)
        {
            if ((value.backing & Backing.JsonElement) != 0)
            {
                return new(value.AsJsonElement);
            }

            if ((value.backing & Backing.Object) != 0)
            {
                return new(value.objectBacking);
            }

            return Menes.OpenApiSchema.V31.Document.Reference.Undefined;
        }

        /// <summary>
        /// Conversion from <see cref = "Menes.OpenApiSchema.V31.Document.Parameter"/>.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator ParameterOrReference(Menes.OpenApiSchema.V31.Document.Parameter value)
        {
            if (value.HasJsonElementBacking)
            {
                return new(value.AsJsonElement);
            }

            return value.ValueKind switch
            {
                JsonValueKind.Object => new((ImmutableDictionary<JsonPropertyName, JsonAny>)value),
                _ => Undefined
            };
        }

        /// <summary>
        /// Conversion to <see cref = "Menes.OpenApiSchema.V31.Document.Parameter"/>.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator Menes.OpenApiSchema.V31.Document.Parameter(ParameterOrReference value)
        {
            if ((value.backing & Backing.JsonElement) != 0)
            {
                return new(value.AsJsonElement);
            }

            if ((value.backing & Backing.Object) != 0)
            {
                return new(value.objectBacking);
            }

            return Menes.OpenApiSchema.V31.Document.Parameter.Undefined;
        }

        /// <summary>
        /// Conversion from <see cref = "Menes.OpenApiSchema.V31.Document.Parameter.OneOf0Entity"/>.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator ParameterOrReference(Menes.OpenApiSchema.V31.Document.Parameter.OneOf0Entity value)
        {
            if (value.HasJsonElementBacking)
            {
                return new(value.AsJsonElement);
            }

            return value.ValueKind switch
            {
                JsonValueKind.Object => new((ImmutableDictionary<JsonPropertyName, JsonAny>)value),
                _ => Undefined
            };
        }

        /// <summary>
        /// Conversion to <see cref = "Menes.OpenApiSchema.V31.Document.Parameter.OneOf0Entity"/>.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator Menes.OpenApiSchema.V31.Document.Parameter.OneOf0Entity(ParameterOrReference value)
        {
            if ((value.backing & Backing.JsonElement) != 0)
            {
                return new(value.AsJsonElement);
            }

            if ((value.backing & Backing.Object) != 0)
            {
                return new(value.objectBacking);
            }

            return Menes.OpenApiSchema.V31.Document.Parameter.OneOf0Entity.Undefined;
        }

        /// <summary>
        /// Conversion from <see cref = "Menes.OpenApiSchema.V31.Document.Parameter.OneOf1Entity"/>.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator ParameterOrReference(Menes.OpenApiSchema.V31.Document.Parameter.OneOf1Entity value)
        {
            if (value.HasJsonElementBacking)
            {
                return new(value.AsJsonElement);
            }

            return value.ValueKind switch
            {
                JsonValueKind.Object => new((ImmutableDictionary<JsonPropertyName, JsonAny>)value),
                _ => Undefined
            };
        }

        /// <summary>
        /// Conversion to <see cref = "Menes.OpenApiSchema.V31.Document.Parameter.OneOf1Entity"/>.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator Menes.OpenApiSchema.V31.Document.Parameter.OneOf1Entity(ParameterOrReference value)
        {
            if ((value.backing & Backing.JsonElement) != 0)
            {
                return new(value.AsJsonElement);
            }

            if ((value.backing & Backing.Object) != 0)
            {
                return new(value.objectBacking);
            }

            return Menes.OpenApiSchema.V31.Document.Parameter.OneOf1Entity.Undefined;
        }

        /// <summary>
        /// Conversion from <see cref = "Menes.OpenApiSchema.V31.Document.SpecificationExtensions"/>.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator ParameterOrReference(Menes.OpenApiSchema.V31.Document.SpecificationExtensions value)
        {
            if (value.HasJsonElementBacking)
            {
                return new(value.AsJsonElement);
            }

            return value.ValueKind switch
            {
                JsonValueKind.Object => new((ImmutableDictionary<JsonPropertyName, JsonAny>)value),
                _ => Undefined
            };
        }

        /// <summary>
        /// Conversion to <see cref = "Menes.OpenApiSchema.V31.Document.SpecificationExtensions"/>.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator Menes.OpenApiSchema.V31.Document.SpecificationExtensions(ParameterOrReference value)
        {
            if ((value.backing & Backing.JsonElement) != 0)
            {
                return new(value.AsJsonElement);
            }

            if ((value.backing & Backing.Object) != 0)
            {
                return new(value.objectBacking);
            }

            return Menes.OpenApiSchema.V31.Document.SpecificationExtensions.Undefined;
        }

        /// <summary>
        /// Conversion from <see cref = "Menes.OpenApiSchema.V31.Document.Parameter.ThenEntity"/>.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator ParameterOrReference(Menes.OpenApiSchema.V31.Document.Parameter.ThenEntity value)
        {
            if (value.HasJsonElementBacking)
            {
                return new(value.AsJsonElement);
            }

            return value.ValueKind switch
            {
                JsonValueKind.Object => new((ImmutableDictionary<JsonPropertyName, JsonAny>)value),
                _ => Undefined
            };
        }

        /// <summary>
        /// Conversion to <see cref = "Menes.OpenApiSchema.V31.Document.Parameter.ThenEntity"/>.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator Menes.OpenApiSchema.V31.Document.Parameter.ThenEntity(ParameterOrReference value)
        {
            if ((value.backing & Backing.JsonElement) != 0)
            {
                return new(value.AsJsonElement);
            }

            if ((value.backing & Backing.Object) != 0)
            {
                return new(value.objectBacking);
            }

            return Menes.OpenApiSchema.V31.Document.Parameter.ThenEntity.Undefined;
        }
    }
}