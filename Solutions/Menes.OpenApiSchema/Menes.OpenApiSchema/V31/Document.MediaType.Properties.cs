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
    /// <summary>
    /// A type generated from a JsonSchema specification.
    /// </summary>
    public readonly partial struct MediaType
    {
        /// <summary>
        /// JSON property name for <see cref = "Example"/>.
        /// </summary>
        public static readonly ReadOnlyMemory<byte> ExampleUtf8JsonPropertyName = new byte[]{101, 120, 97, 109, 112, 108, 101};
        /// <summary>
        /// JSON property name for <see cref = "Example"/>.
        /// </summary>
        public const string ExampleJsonPropertyName = "example";
        /// <summary>
        /// JSON property name for <see cref = "Examples"/>.
        /// </summary>
        public static readonly ReadOnlyMemory<byte> ExamplesUtf8JsonPropertyName = new byte[]{101, 120, 97, 109, 112, 108, 101, 115};
        /// <summary>
        /// JSON property name for <see cref = "Examples"/>.
        /// </summary>
        public const string ExamplesJsonPropertyName = "examples";
        /// <summary>
        /// JSON property name for <see cref = "Schema"/>.
        /// </summary>
        public static readonly ReadOnlyMemory<byte> SchemaUtf8JsonPropertyName = new byte[]{115, 99, 104, 101, 109, 97};
        /// <summary>
        /// JSON property name for <see cref = "Schema"/>.
        /// </summary>
        public const string SchemaJsonPropertyName = "schema";
        /// <summary>
        /// JSON property name for <see cref = "EncodingValue"/>.
        /// </summary>
        public static readonly ReadOnlyMemory<byte> EncodingValueUtf8JsonPropertyName = new byte[]{101, 110, 99, 111, 100, 105, 110, 103};
        /// <summary>
        /// JSON property name for <see cref = "EncodingValue"/>.
        /// </summary>
        public const string EncodingValueJsonPropertyName = "encoding";
        /// <summary>
        /// Gets Example.
        /// </summary>
        public Corvus.Json.JsonAny Example
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                    {
                        return default;
                    }

                    if (this.jsonElementBacking.TryGetProperty(ExampleUtf8JsonPropertyName.Span, out JsonElement result))
                    {
                        return new Corvus.Json.JsonAny(result);
                    }
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    if (this.objectBacking.TryGetValue(ExampleJsonPropertyName, out JsonAny result))
                    {
                        return result.As<Corvus.Json.JsonAny>();
                    }
                }

                return default;
            }
        }

        /// <summary>
        /// Gets Examples.
        /// </summary>
        public Menes.OpenApiSchema.V31.Document.Examples.ExamplesEntity Examples
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                    {
                        return default;
                    }

                    if (this.jsonElementBacking.TryGetProperty(ExamplesUtf8JsonPropertyName.Span, out JsonElement result))
                    {
                        return new Menes.OpenApiSchema.V31.Document.Examples.ExamplesEntity(result);
                    }
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    if (this.objectBacking.TryGetValue(ExamplesJsonPropertyName, out JsonAny result))
                    {
                        return result.As<Menes.OpenApiSchema.V31.Document.Examples.ExamplesEntity>();
                    }
                }

                return default;
            }
        }

        /// <summary>
        /// Gets Schema.
        /// </summary>
        public Menes.OpenApiSchema.V31.Document.Schema Schema
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                    {
                        return default;
                    }

                    if (this.jsonElementBacking.TryGetProperty(SchemaUtf8JsonPropertyName.Span, out JsonElement result))
                    {
                        return new Menes.OpenApiSchema.V31.Document.Schema(result);
                    }
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    if (this.objectBacking.TryGetValue(SchemaJsonPropertyName, out JsonAny result))
                    {
                        return result.As<Menes.OpenApiSchema.V31.Document.Schema>();
                    }
                }

                return default;
            }
        }

        /// <summary>
        /// Gets EncodingValue.
        /// </summary>
        public Menes.OpenApiSchema.V31.Document.MediaType.EncodingEntity EncodingValue
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                    {
                        return default;
                    }

                    if (this.jsonElementBacking.TryGetProperty(EncodingValueUtf8JsonPropertyName.Span, out JsonElement result))
                    {
                        return new Menes.OpenApiSchema.V31.Document.MediaType.EncodingEntity(result);
                    }
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    if (this.objectBacking.TryGetValue(EncodingValueJsonPropertyName, out JsonAny result))
                    {
                        return result.As<Menes.OpenApiSchema.V31.Document.MediaType.EncodingEntity>();
                    }
                }

                return default;
            }
        }

        /// <summary>
        /// Creates an instance of a <see cref = "MediaType"/>.
        /// </summary>
        public static MediaType Create(Corvus.Json.JsonAny? example = null, Menes.OpenApiSchema.V31.Document.Examples.ExamplesEntity? examples = null, Menes.OpenApiSchema.V31.Document.Schema? schema = null, Menes.OpenApiSchema.V31.Document.MediaType.EncodingEntity? encodingValue = null)
        {
            var builder = ImmutableDictionary.CreateBuilder<JsonPropertyName, JsonAny>();
            if (example is Corvus.Json.JsonAny example__)
            {
                builder.Add(ExampleJsonPropertyName, example__.AsAny);
            }

            if (examples is Menes.OpenApiSchema.V31.Document.Examples.ExamplesEntity examples__)
            {
                builder.Add(ExamplesJsonPropertyName, examples__.AsAny);
            }

            if (schema is Menes.OpenApiSchema.V31.Document.Schema schema__)
            {
                builder.Add(SchemaJsonPropertyName, schema__.AsAny);
            }

            if (encodingValue is Menes.OpenApiSchema.V31.Document.MediaType.EncodingEntity encodingValue__)
            {
                builder.Add(EncodingValueJsonPropertyName, encodingValue__.AsAny);
            }

            return builder.ToImmutable();
        }

        /// <summary>
        /// Sets example.
        /// </summary>
        /// <param name = "value">The value to set.</param>
        /// <returns>The entity with the updated property.</returns>
        public MediaType WithExample(in Corvus.Json.JsonAny value)
        {
            return this.SetProperty(ExampleJsonPropertyName, value);
        }

        /// <summary>
        /// Sets examples.
        /// </summary>
        /// <param name = "value">The value to set.</param>
        /// <returns>The entity with the updated property.</returns>
        public MediaType WithExamples(in Menes.OpenApiSchema.V31.Document.Examples.ExamplesEntity value)
        {
            return this.SetProperty(ExamplesJsonPropertyName, value);
        }

        /// <summary>
        /// Sets schema.
        /// </summary>
        /// <param name = "value">The value to set.</param>
        /// <returns>The entity with the updated property.</returns>
        public MediaType WithSchema(in Menes.OpenApiSchema.V31.Document.Schema value)
        {
            return this.SetProperty(SchemaJsonPropertyName, value);
        }

        /// <summary>
        /// Sets encoding.
        /// </summary>
        /// <param name = "value">The value to set.</param>
        /// <returns>The entity with the updated property.</returns>
        public MediaType WithEncodingValue(in Menes.OpenApiSchema.V31.Document.MediaType.EncodingEntity value)
        {
            return this.SetProperty(EncodingValueJsonPropertyName, value);
        }

        private static ValidationContext __CorvusValidateSchema(in JsonObjectProperty property, in ValidationContext validationContext, ValidationLevel level)
        {
            return property.ValueAs<Menes.OpenApiSchema.V31.Document.Schema>().Validate(validationContext, level);
        }

        private static ValidationContext __CorvusValidateEncodingValue(in JsonObjectProperty property, in ValidationContext validationContext, ValidationLevel level)
        {
            return property.ValueAs<Menes.OpenApiSchema.V31.Document.MediaType.EncodingEntity>().Validate(validationContext, level);
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
                if (property.NameEquals(SchemaUtf8JsonPropertyName.Span))
                {
                    propertyValidator = __CorvusValidateSchema;
                    return true;
                }
                else if (property.NameEquals(EncodingValueUtf8JsonPropertyName.Span))
                {
                    propertyValidator = __CorvusValidateEncodingValue;
                    return true;
                }
            }
            else
            {
                if (property.NameEquals(SchemaJsonPropertyName))
                {
                    propertyValidator = __CorvusValidateSchema;
                    return true;
                }
                else if (property.NameEquals(EncodingValueJsonPropertyName))
                {
                    propertyValidator = __CorvusValidateEncodingValue;
                    return true;
                }
            }

            propertyValidator = null;
            return false;
        }
    }
}