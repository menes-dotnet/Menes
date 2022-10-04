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
            public readonly partial struct StylesForPathEntity
            {
                /// <summary>
                /// A type generated from a JsonSchema specification.
                /// </summary>
                public readonly partial struct IfEntity
                {
                    /// <summary>
                    /// JSON property name for <see cref = "In"/>.
                    /// </summary>
                    public static readonly ReadOnlyMemory<byte> InUtf8JsonPropertyName = new byte[]{105, 110};
                    /// <summary>
                    /// JSON property name for <see cref = "In"/>.
                    /// </summary>
                    public const string InJsonPropertyName = "in";
                    /// <summary>
                    /// Gets In.
                    /// </summary>
                    public Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForPathEntity.IfEntity.InEntity In
                    {
                        get
                        {
                            if ((this.backing & Backing.JsonElement) != 0)
                            {
                                if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                                {
                                    return default;
                                }

                                if (this.jsonElementBacking.TryGetProperty(InUtf8JsonPropertyName.Span, out JsonElement result))
                                {
                                    return new Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForPathEntity.IfEntity.InEntity(result);
                                }
                            }

                            if ((this.backing & Backing.Object) != 0)
                            {
                                if (this.objectBacking.TryGetValue(InJsonPropertyName, out JsonAny result))
                                {
                                    return result.As<Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForPathEntity.IfEntity.InEntity>();
                                }
                            }

                            return default;
                        }
                    }

                    /// <summary>
                    /// Creates an instance of a <see cref = "IfEntity"/>.
                    /// </summary>
                    public static IfEntity Create()
                    {
                        var builder = ImmutableDictionary.CreateBuilder<JsonPropertyName, JsonAny>();
                        builder.Add(InJsonPropertyName, new Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForPathEntity.IfEntity.InEntity().AsAny);
                        return builder.ToImmutable();
                    }

                    private static ValidationContext __CorvusValidateIn(in JsonObjectProperty property, in ValidationContext validationContext, ValidationLevel level)
                    {
                        return property.ValueAs<Menes.OpenApiSchema.V31.Document.Parameter.SchemaEntity.StylesForPathEntity.IfEntity.InEntity>().Validate(validationContext, level);
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
                            if (property.NameEquals(InUtf8JsonPropertyName.Span))
                            {
                                propertyValidator = __CorvusValidateIn;
                                return true;
                            }
                        }
                        else
                        {
                            if (property.NameEquals(InJsonPropertyName))
                            {
                                propertyValidator = __CorvusValidateIn;
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