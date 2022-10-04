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
            /// <summary>
            /// A type generated from a JsonSchema specification.
            /// </summary>
            public readonly partial struct StylesForQueryEntity
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
                /// JSON property name for <see cref = "AllowReserved"/>.
                /// </summary>
                public static readonly ReadOnlyMemory<byte> AllowReservedUtf8JsonPropertyName = new byte[]{97, 108, 108, 111, 119, 82, 101, 115, 101, 114, 118, 101, 100};
                /// <summary>
                /// JSON property name for <see cref = "AllowReserved"/>.
                /// </summary>
                public const string AllowReservedJsonPropertyName = "allowReserved";
                /// <summary>
                /// Gets Style.
                /// </summary>
                public Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForQueryEntity.ThenEntity.StyleEntity Style
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
                                return new Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForQueryEntity.ThenEntity.StyleEntity(result);
                            }
                        }

                        if ((this.backing & Backing.Object) != 0)
                        {
                            if (this.objectBacking.TryGetValue(StyleJsonPropertyName, out JsonAny result))
                            {
                                return result.As<Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForQueryEntity.ThenEntity.StyleEntity>();
                            }
                        }

                        return default;
                    }
                }

                /// <summary>
                /// Gets AllowReserved.
                /// </summary>
                public Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForQueryEntity.ThenEntity.AllowReservedEntity AllowReserved
                {
                    get
                    {
                        if ((this.backing & Backing.JsonElement) != 0)
                        {
                            if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                            {
                                return default;
                            }

                            if (this.jsonElementBacking.TryGetProperty(AllowReservedUtf8JsonPropertyName.Span, out JsonElement result))
                            {
                                return new Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForQueryEntity.ThenEntity.AllowReservedEntity(result);
                            }
                        }

                        if ((this.backing & Backing.Object) != 0)
                        {
                            if (this.objectBacking.TryGetValue(AllowReservedJsonPropertyName, out JsonAny result))
                            {
                                return result.As<Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForQueryEntity.ThenEntity.AllowReservedEntity>();
                            }
                        }

                        return default;
                    }
                }

                /// <summary>
                /// Creates an instance of a <see cref = "StylesForQueryEntity"/>.
                /// </summary>
                public static StylesForQueryEntity Create(Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForQueryEntity.ThenEntity.StyleEntity? style = null, Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForQueryEntity.ThenEntity.AllowReservedEntity? allowReserved = null)
                {
                    var builder = ImmutableDictionary.CreateBuilder<JsonPropertyName, JsonAny>();
                    if (style is Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForQueryEntity.ThenEntity.StyleEntity style__)
                    {
                        builder.Add(StyleJsonPropertyName, style__.AsAny);
                    }

                    if (allowReserved is Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForQueryEntity.ThenEntity.AllowReservedEntity allowReserved__)
                    {
                        builder.Add(AllowReservedJsonPropertyName, allowReserved__.AsAny);
                    }

                    return builder.ToImmutable();
                }

                /// <summary>
                /// Sets style.
                /// </summary>
                /// <param name = "value">The value to set.</param>
                /// <returns>The entity with the updated property.</returns>
                public StylesForQueryEntity WithStyle(in Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForQueryEntity.ThenEntity.StyleEntity value)
                {
                    return this.SetProperty(StyleJsonPropertyName, value);
                }

                /// <summary>
                /// Sets allowReserved.
                /// </summary>
                /// <param name = "value">The value to set.</param>
                /// <returns>The entity with the updated property.</returns>
                public StylesForQueryEntity WithAllowReserved(in Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForQueryEntity.ThenEntity.AllowReservedEntity value)
                {
                    return this.SetProperty(AllowReservedJsonPropertyName, value);
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
                    }
                    else
                    {
                    }

                    propertyValidator = null;
                    return false;
                }
            }
        }
    }
}