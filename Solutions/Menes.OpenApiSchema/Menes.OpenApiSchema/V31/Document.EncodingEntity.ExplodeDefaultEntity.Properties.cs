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
    public readonly partial struct EncodingEntity
    {
        /// <summary>
        /// A type generated from a JsonSchema specification.
        /// </summary>
        public readonly partial struct ExplodeDefaultEntity
        {
            /// <summary>
            /// JSON property name for <see cref = "Explode"/>.
            /// </summary>
            public static readonly ReadOnlyMemory<byte> ExplodeUtf8JsonPropertyName = new byte[]{101, 120, 112, 108, 111, 100, 101};
            /// <summary>
            /// JSON property name for <see cref = "Explode"/>.
            /// </summary>
            public const string ExplodeJsonPropertyName = "explode";
            /// <summary>
            /// Gets Explode.
            /// </summary>
            public Menes.OpenApiSchema.V31.Document.EncodingEntity.ExplodeDefaultEntity.ElseEntity.ExplodeEntity Explode
            {
                get
                {
                    if ((this.backing & Backing.JsonElement) != 0)
                    {
                        if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                        {
                            return default;
                        }

                        if (this.jsonElementBacking.TryGetProperty(ExplodeUtf8JsonPropertyName.Span, out JsonElement result))
                        {
                            return new Menes.OpenApiSchema.V31.Document.EncodingEntity.ExplodeDefaultEntity.ElseEntity.ExplodeEntity(result);
                        }
                    }

                    if ((this.backing & Backing.Object) != 0)
                    {
                        if (this.objectBacking.TryGetValue(ExplodeJsonPropertyName, out JsonAny result))
                        {
                            return result.As<Menes.OpenApiSchema.V31.Document.EncodingEntity.ExplodeDefaultEntity.ElseEntity.ExplodeEntity>();
                        }
                    }

                    return default;
                }
            }

            /// <summary>
            /// Creates an instance of a <see cref = "ExplodeDefaultEntity"/>.
            /// </summary>
            public static ExplodeDefaultEntity Create(Menes.OpenApiSchema.V31.Document.EncodingEntity.ExplodeDefaultEntity.ElseEntity.ExplodeEntity? explode = null)
            {
                var builder = ImmutableDictionary.CreateBuilder<JsonPropertyName, JsonAny>();
                if (explode is Menes.OpenApiSchema.V31.Document.EncodingEntity.ExplodeDefaultEntity.ElseEntity.ExplodeEntity explode__)
                {
                    builder.Add(ExplodeJsonPropertyName, explode__.AsAny);
                }

                return builder.ToImmutable();
            }

            /// <summary>
            /// Sets explode.
            /// </summary>
            /// <param name = "value">The value to set.</param>
            /// <returns>The entity with the updated property.</returns>
            public ExplodeDefaultEntity WithExplode(in Menes.OpenApiSchema.V31.Document.EncodingEntity.ExplodeDefaultEntity.ElseEntity.ExplodeEntity value)
            {
                return this.SetProperty(ExplodeJsonPropertyName, value);
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