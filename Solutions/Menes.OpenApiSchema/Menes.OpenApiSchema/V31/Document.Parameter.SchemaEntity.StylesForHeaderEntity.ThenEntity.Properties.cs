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
    public readonly partial struct Parameter
    {
        public readonly partial struct SchemaEntity
        {
            public readonly partial struct StylesForHeaderEntity
            {
                /// <summary>
                /// A type generated from a JsonSchema specification.
                /// </summary>
                public readonly partial struct ThenEntity
                {
                    /// <summary>
                    /// JSON property name for <see cref = "Style"/>.
                    /// </summary>
                    public static readonly ReadOnlyMemory<byte> StyleUtf8JsonPropertyName = new byte[]{115, 116, 121, 108, 101};
                    /// <summary>
                    /// JSON property name for <see cref = "Style"/>.
                    /// </summary>
                    public const string StyleJsonPropertyName = "style";
                    /// <summary>
                    /// Gets Style.
                    /// </summary>
                    public Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForHeaderEntity.ThenEntity.StyleEntity Style
                    {
                        get
                        {
                            if ((this.backing & Backing.JsonElement) != 0)
                            {
                                if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                                {
                                    return default;
                                }

                                if (this.jsonElementBacking.TryGetProperty(StyleUtf8JsonPropertyName.Span, out JsonElement result))
                                {
                                    return new Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForHeaderEntity.ThenEntity.StyleEntity(result);
                                }
                            }

                            if ((this.backing & Backing.Object) != 0)
                            {
                                if (this.objectBacking.TryGetValue(StyleJsonPropertyName, out JsonAny result))
                                {
                                    return result.As<Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForHeaderEntity.ThenEntity.StyleEntity>();
                                }
                            }

                            return default;
                        }
                    }

                    /// <summary>
                    /// Creates an instance of a <see cref = "ThenEntity"/>.
                    /// </summary>
                    public static ThenEntity Create(Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForHeaderEntity.ThenEntity.StyleEntity? style = null)
                    {
                        var builder = ImmutableDictionary.CreateBuilder<JsonPropertyName, JsonAny>();
                        if (style is Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForHeaderEntity.ThenEntity.StyleEntity style__)
                        {
                            builder.Add(StyleJsonPropertyName, style__.AsAny);
                        }

                        return builder.ToImmutable();
                    }

                    private static ValidationContext __CorvusValidateStyle(in JsonObjectProperty property, in ValidationContext validationContext, ValidationLevel level)
                    {
                        return property.ValueAs<Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForHeaderEntity.ThenEntity.StyleEntity>().Validate(validationContext, level);
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
                            if (property.NameEquals(StyleUtf8JsonPropertyName.Span))
                            {
                                propertyValidator = __CorvusValidateStyle;
                                return true;
                            }
                        }
                        else
                        {
                            if (property.NameEquals(StyleJsonPropertyName))
                            {
                                propertyValidator = __CorvusValidateStyle;
                                return true;
                            }
                        }

                        propertyValidator = null;
                        return false;
                    }
                }
            }
        }
    }
}