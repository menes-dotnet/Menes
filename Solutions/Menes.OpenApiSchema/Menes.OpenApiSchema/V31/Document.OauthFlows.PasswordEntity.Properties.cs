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
    public readonly partial struct OauthFlows
    {
        /// <summary>
        /// A type generated from a JsonSchema specification.
        /// </summary>
        public readonly partial struct PasswordEntity
        {
            /// <summary>
            /// JSON property name for <see cref = "TokenUrl"/>.
            /// </summary>
            public static readonly ReadOnlyMemory<byte> TokenUrlUtf8JsonPropertyName = new byte[]{116, 111, 107, 101, 110, 85, 114, 108};
            /// <summary>
            /// JSON property name for <see cref = "TokenUrl"/>.
            /// </summary>
            public const string TokenUrlJsonPropertyName = "tokenUrl";
            /// <summary>
            /// JSON property name for <see cref = "Scopes"/>.
            /// </summary>
            public static readonly ReadOnlyMemory<byte> ScopesUtf8JsonPropertyName = new byte[]{115, 99, 111, 112, 101, 115};
            /// <summary>
            /// JSON property name for <see cref = "Scopes"/>.
            /// </summary>
            public const string ScopesJsonPropertyName = "scopes";
            /// <summary>
            /// JSON property name for <see cref = "RefreshUrl"/>.
            /// </summary>
            public static readonly ReadOnlyMemory<byte> RefreshUrlUtf8JsonPropertyName = new byte[]{114, 101, 102, 114, 101, 115, 104, 85, 114, 108};
            /// <summary>
            /// JSON property name for <see cref = "RefreshUrl"/>.
            /// </summary>
            public const string RefreshUrlJsonPropertyName = "refreshUrl";
            /// <summary>
            /// Gets TokenUrl.
            /// </summary>
            public Corvus.Json.JsonUri TokenUrl
            {
                get
                {
                    if ((this.backing & Backing.JsonElement) != 0)
                    {
                        if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                        {
                            return default;
                        }

                        if (this.jsonElementBacking.TryGetProperty(TokenUrlUtf8JsonPropertyName.Span, out JsonElement result))
                        {
                            return new Corvus.Json.JsonUri(result);
                        }
                    }

                    if ((this.backing & Backing.Object) != 0)
                    {
                        if (this.objectBacking.TryGetValue(TokenUrlJsonPropertyName, out JsonAny result))
                        {
                            return result.As<Corvus.Json.JsonUri>();
                        }
                    }

                    return default;
                }
            }

            /// <summary>
            /// Gets Scopes.
            /// </summary>
            public Menes.OpenApiSchema.V31.Document.MapOfStrings Scopes
            {
                get
                {
                    if ((this.backing & Backing.JsonElement) != 0)
                    {
                        if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                        {
                            return default;
                        }

                        if (this.jsonElementBacking.TryGetProperty(ScopesUtf8JsonPropertyName.Span, out JsonElement result))
                        {
                            return new Menes.OpenApiSchema.V31.Document.MapOfStrings(result);
                        }
                    }

                    if ((this.backing & Backing.Object) != 0)
                    {
                        if (this.objectBacking.TryGetValue(ScopesJsonPropertyName, out JsonAny result))
                        {
                            return result.As<Menes.OpenApiSchema.V31.Document.MapOfStrings>();
                        }
                    }

                    return default;
                }
            }

            /// <summary>
            /// Gets RefreshUrl.
            /// </summary>
            public Corvus.Json.JsonUri RefreshUrl
            {
                get
                {
                    if ((this.backing & Backing.JsonElement) != 0)
                    {
                        if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                        {
                            return default;
                        }

                        if (this.jsonElementBacking.TryGetProperty(RefreshUrlUtf8JsonPropertyName.Span, out JsonElement result))
                        {
                            return new Corvus.Json.JsonUri(result);
                        }
                    }

                    if ((this.backing & Backing.Object) != 0)
                    {
                        if (this.objectBacking.TryGetValue(RefreshUrlJsonPropertyName, out JsonAny result))
                        {
                            return result.As<Corvus.Json.JsonUri>();
                        }
                    }

                    return default;
                }
            }

            /// <summary>
            /// Creates an instance of a <see cref = "PasswordEntity"/>.
            /// </summary>
            public static PasswordEntity Create(Corvus.Json.JsonUri tokenUrl, Menes.OpenApiSchema.V31.Document.MapOfStrings scopes, Corvus.Json.JsonUri? refreshUrl = null)
            {
                var builder = ImmutableDictionary.CreateBuilder<JsonPropertyName, JsonAny>();
                builder.Add(TokenUrlJsonPropertyName, tokenUrl.AsAny);
                builder.Add(ScopesJsonPropertyName, scopes.AsAny);
                if (refreshUrl is Corvus.Json.JsonUri refreshUrl__)
                {
                    builder.Add(RefreshUrlJsonPropertyName, refreshUrl__.AsAny);
                }

                return builder.ToImmutable();
            }

            /// <summary>
            /// Sets tokenUrl.
            /// </summary>
            /// <param name = "value">The value to set.</param>
            /// <returns>The entity with the updated property.</returns>
            public PasswordEntity WithTokenUrl(in Corvus.Json.JsonUri value)
            {
                return this.SetProperty(TokenUrlJsonPropertyName, value);
            }

            /// <summary>
            /// Sets scopes.
            /// </summary>
            /// <param name = "value">The value to set.</param>
            /// <returns>The entity with the updated property.</returns>
            public PasswordEntity WithScopes(in Menes.OpenApiSchema.V31.Document.MapOfStrings value)
            {
                return this.SetProperty(ScopesJsonPropertyName, value);
            }

            /// <summary>
            /// Sets refreshUrl.
            /// </summary>
            /// <param name = "value">The value to set.</param>
            /// <returns>The entity with the updated property.</returns>
            public PasswordEntity WithRefreshUrl(in Corvus.Json.JsonUri value)
            {
                return this.SetProperty(RefreshUrlJsonPropertyName, value);
            }

            private static ValidationContext __CorvusValidateTokenUrl(in JsonObjectProperty property, in ValidationContext validationContext, ValidationLevel level)
            {
                return property.ValueAs<Corvus.Json.JsonUri>().Validate(validationContext, level);
            }

            private static ValidationContext __CorvusValidateScopes(in JsonObjectProperty property, in ValidationContext validationContext, ValidationLevel level)
            {
                return property.ValueAs<Menes.OpenApiSchema.V31.Document.MapOfStrings>().Validate(validationContext, level);
            }

            private static ValidationContext __CorvusValidateRefreshUrl(in JsonObjectProperty property, in ValidationContext validationContext, ValidationLevel level)
            {
                return property.ValueAs<Corvus.Json.JsonUri>().Validate(validationContext, level);
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
                    if (property.NameEquals(TokenUrlUtf8JsonPropertyName.Span))
                    {
                        propertyValidator = __CorvusValidateTokenUrl;
                        return true;
                    }
                    else if (property.NameEquals(ScopesUtf8JsonPropertyName.Span))
                    {
                        propertyValidator = __CorvusValidateScopes;
                        return true;
                    }
                    else if (property.NameEquals(RefreshUrlUtf8JsonPropertyName.Span))
                    {
                        propertyValidator = __CorvusValidateRefreshUrl;
                        return true;
                    }
                }
                else
                {
                    if (property.NameEquals(TokenUrlJsonPropertyName))
                    {
                        propertyValidator = __CorvusValidateTokenUrl;
                        return true;
                    }
                    else if (property.NameEquals(ScopesJsonPropertyName))
                    {
                        propertyValidator = __CorvusValidateScopes;
                        return true;
                    }
                    else if (property.NameEquals(RefreshUrlJsonPropertyName))
                    {
                        propertyValidator = __CorvusValidateRefreshUrl;
                        return true;
                    }
                }

                propertyValidator = null;
                return false;
            }
        }
    }
}